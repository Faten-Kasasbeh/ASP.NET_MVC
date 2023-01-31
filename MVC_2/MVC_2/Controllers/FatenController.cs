using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVC_2.Controllers
{
    public class FatenController : Controller
    {
        // GET: Faten
        public ActionResult Index()
        {
            return View();
        }
        public string name()
        {
            return "<h1>Faten Kasasbeh</h1>";
         }
        public string Age() {
            return "29 year";
        }
        public string image() {
            return " <img src=\"../images/faten.jpeg\" alt=\"Girl in a jacket\" width=\"500\" height=\"600\">";
        }
        public string adress() {
            return "Jordan / Irbid"; 
        }
    }
}