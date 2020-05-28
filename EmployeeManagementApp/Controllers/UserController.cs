using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.loginusers.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,password")] loginuser model)
        {
            bool isValidName = model.name != null && !Regex.IsMatch(model.name, @"[^a-zA-Z0-9]");
            bool isValidPassword = model.password != null && !Regex.IsMatch(model.password, @"[^a-zA-Z0-9]");

            if (ModelState.IsValid && isValidName && isValidPassword)
            {
                model.password = loginuser.GeneratePasswordHash(model.name, model.password);
                db.loginusers.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Message = "ユーザ名とパスワードは半角英数で入力してください。";
            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: User/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,password")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginuser);
        }

        // GET: User/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            loginuser loginuser = db.loginusers.Find(id);
            db.loginusers.Remove(loginuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
