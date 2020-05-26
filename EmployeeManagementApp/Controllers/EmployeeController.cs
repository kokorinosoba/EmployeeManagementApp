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
        public ActionResult Add2(string Name, int Salary, DateTime Birthday, DateTime EntryDay, int DepartmentId)
        {
            ViewBag.Name = Name;
            ViewBag.Salary = Salary;
            ViewBag.BirthDay = Birthday;
            ViewBag.EntryDay = EntryDay;
            ViewBag.DepartmentId = DepartmentId;
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