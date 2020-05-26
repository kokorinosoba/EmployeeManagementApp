using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add2(decimal Id, string Name, int? Salary, DateTime? Birthday, DateTime? EntryDay, int? DepartmentId)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Salary = Salary;
            ViewBag.BirthDay = Birthday;
            ViewBag.EntryDay = EntryDay;
            ViewBag.DepartmentId = DepartmentId;
            using (var db = new DatabaseEntities())
            {
                var e = new employee
                {
                    id = Id,
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