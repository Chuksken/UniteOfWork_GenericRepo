using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniteOfWork.Data.Infrastracture;
using UniteOfWork.Data.Repository;

namespace UniteOfWork.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepo _repo;
        public HomeController()
        {
            _repo = new EmployeeRepo ();
        }
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult Index()
        //{

        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}