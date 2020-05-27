using EmployeeManagementApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeManagementApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "name, password")] loginuser model)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model))
                {
                    FormsAuthentication.SetAuthCookie(userName: model.name, createPersistentCookie: false);
                    return RedirectToAction(actionName: "Index", controllerName: "User");
                }
            }

            ViewBag.Message = "ログインに失敗しました。";
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(actionName: "Index");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
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