using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public ActionResult Update1()
        {
            return View();
        }

        public ActionResult Update2(int id,string name, int? salary, DateTime birthday, DateTime entryday, int? departmentid)
        {
            if (string.IsNullOrEmpty(name)) 
            {
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

        public ActionResult Delete()
        {
            return View();
        }
    }
}