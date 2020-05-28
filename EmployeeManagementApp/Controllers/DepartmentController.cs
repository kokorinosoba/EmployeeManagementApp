using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();

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
        public ActionResult Update2(decimal Id, string Name, int? SalaryBase, string PhoneNumber, int? LeaderId)
        {
            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.auth = false;
                return View("Update");
            }
                ViewBag.Id = Id;
                ViewBag.Name = Name;
                ViewBag.SalaryBase = SalaryBase;
                ViewBag.PhoneNumber = PhoneNumber;
                ViewBag.LeaderId = LeaderId;
                using (var db = new DatabaseEntities())
                {
                    var d = db.departments.Find(Id);
                    d.name = Name;
                    d.salarybase = SalaryBase;
                    d.phonenumber = PhoneNumber;
                    d.leaderid = LeaderId;
                    db.SaveChanges();
                    return View();
                }
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
            return View(); 
        }
    }
}