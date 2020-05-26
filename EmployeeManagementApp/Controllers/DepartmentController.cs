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
            return View();
        }

        public ActionResult Add1()
        {
            return View();
        }
        public ActionResult Add2(int id, string name, int salarybase,string phonenumber, int leaderid)
        {

            if (name == null)
            {
                return View("Add1");
            }
            using (var db = new DatabaseEntities()) ;
            var u = new department
            {
                id = id,
                name = name,
                salarybase = salarybase,
                phonenumber = phonenumber,
                leaderid = leaderid
            };
            var v=db.departments.Add(u);
            db.SaveChanges();
           return View(v);
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