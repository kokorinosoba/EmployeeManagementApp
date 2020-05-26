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

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Update2()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}