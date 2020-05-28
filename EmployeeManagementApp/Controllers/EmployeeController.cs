using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();

        public ActionResult List()
        {
            ViewBag.list = db.employees.ToList();
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.model = db.employees.Find(id);
            return View();
        }

        public ActionResult Add()
        {

            return View();
        }
        public ActionResult Add2(string Name, int? Salary, DateTime? Birthday, DateTime? EntryDay, int? DepartmentId)
        {
            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.auth = false;
                return View("Add");
            }

            ViewBag.Name = Name;
            ViewBag.Salary = Salary;
            ViewBag.BirthDay = Birthday;
            ViewBag.EntryDay = EntryDay;
            ViewBag.DepartmentId = DepartmentId;
            using (var db = new DatabaseEntities())
            {
                var e = new employee
                {
                    name = Name,
                    salary = Salary,
                    birthday = Birthday,
                    entryday = EntryDay,
                    departmentid = DepartmentId
                };
                db.employees.Add(e);
                db.SaveChanges();
                ViewBag.register = e;
                return View();
            }
        }

        public ActionResult Update1(decimal id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Update2(int id, string name, int? salary, DateTime? birthday, DateTime? entryday, int? departmentid)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.auth = false;
                return View("Update1");
            }
            using (var db = new DatabaseEntities())
            {
                var u = db.employees.Find(id);
                u.name = name;
                u.salary = salary;
                u.birthday = birthday;
                u.entryday = entryday;
                u.departmentid = departmentid;
                db.SaveChanges();
                var v = db.employees.Find(id);
                return View(v);
            }
        }

        public ActionResult Delete1(int id)
        {
            ViewBag.model = db.employees.Find(id);
            return View();
        }
        public ActionResult Delete2(int id)
        {
            ViewBag.model = db.employees.Find(id);
            db.employees.Remove(ViewBag.model);
            db.SaveChanges();
            return View();
        }
    }
}