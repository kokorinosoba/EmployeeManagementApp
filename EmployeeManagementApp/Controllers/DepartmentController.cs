using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewBag.model = db.departments.ToList();
            return View();
        }

        public ActionResult Add1()
        {
            return View();
        }
        public ActionResult Add2(int id, string name, int? salarybase, string phonenumber, int? leaderid)
        {

            if (string.IsNullOrEmpty(name))
            {
                return View("Add1");
            }
            using (var db = new DatabaseEntities())
            {
                var u = new department
                {
                    id = id,
                    name = name,
                    salarybase = salarybase,
                    phonenumber = phonenumber,
                    leaderid = leaderid
                };
                var v = db.departments.Add(u);
                db.SaveChanges();
                return View(v);
            }
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Update2()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            ViewBag.model = db.departments.Find(id);
            return View();
        }

        public ActionResult Delete2(int id)
        {   
            var model = db.departments.Find(id);
            db.departments.Remove(model);
            db.SaveChanges();
            return Redirect("/ / /"); 
        }
    }
}