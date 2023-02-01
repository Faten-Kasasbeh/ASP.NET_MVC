using MVC_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Entity.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            List<Models.Student> stu = new List<Student>();
            stu.Add(new Student { ID = 1, Name = "Faten", Major = "Communication Engineering" , Faculity= "Engineering" });
            stu.Add(new Student { ID = 2, Name = "Mohammad", Major = "CS", Faculity = " IT" });
            stu.Add(new Student { ID = 3, Name = "Razan", Major = " Mathmatic", Faculity = "Sciences" });

            return View(stu);
        }
    }
}