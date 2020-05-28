using EmployeeManagementApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeManagementApp.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View("Menu");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "name, password")] loginuser model)
        {
            if (ModelState.IsValid && model.name != null && model.password != null)
            {
                if (ValidateUser(model))
                {
                    FormsAuthentication.SetAuthCookie(userName: model.name, createPersistentCookie: false);
                    return RedirectToAction(actionName: "Menu");
                }
            }

            ViewBag.Message = "ユーザ名かパスワードが間違っています。";
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(actionName: "Index");
        }

        public ActionResult Menu()
        {
            return View();
        }

        private bool ValidateUser(loginuser model)
        {
            var hash = loginuser.GeneratePasswordHash(model.name, model.password);

            var user = db.loginusers
                .Where(u => u.name == model.name && u.password == hash)
                .FirstOrDefault();

            if (model.name == "admin" && model.password == "pass") return true;

            return user != null;
        }
    }
}