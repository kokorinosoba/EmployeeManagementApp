using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeManagementApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        readonly LoginMembershipProvider loginMembership = new LoginMembershipProvider();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "username, password")] loginuser model)
        {
            if (ModelState.IsValid)
            {
                if (loginMembership.ValidateUser(username:model.name, password:model.password))
                {
                    FormsAuthentication.SetAuthCookie(userName:model.name, createPersistentCookie:false);
                    return RedirectToAction(actionName: "Index", controllerName: "Employee");
                }
            }

            ViewBag.Message = "ログインに失敗しました。";
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(actionName:"Index");
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
    }
}