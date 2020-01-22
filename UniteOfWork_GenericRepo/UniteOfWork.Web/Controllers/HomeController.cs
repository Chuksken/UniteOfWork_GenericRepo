using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniteOfWork.Data.Infrastracture;
using UniteOfWork.Data.Models;
using UniteOfWork.Data.Repository;
using UniteOfWork.Web.ViewModels;

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


        [HttpPost]
        public ActionResult Index(EmployeeVM em)
        {
            if(ModelState.IsValid)
            {
                Employee newEmployee = new Employee()
                {
                    Name = em.Name,
                    Address = em.Address,
                    Age = em.Age
                };
                _repo.Add(newEmployee);

               
            }
            return View();
        }

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