using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default



        public ActionResult Index()
        {
            showImg();
            return View();
        }

       public string showImg()
        {
            return "<h1>Download Image</h1> <a href= \"GetImage\"> <img src=\"../images/mvc.png\" alt=\"Girl in a jacket\" width=\"500\" height=\"600\"></a>";
        }

        public FileResult GetImage()
        {
            var filePath = Server.MapPath("~/images/" + "mvc.png");
            return File(filePath, "image/jpeg", "mvc.png");


        }
        public string contact()
        {
            return "<h4>CONTACT US</h4><h1>If You Have Any Query, Please Contact Us</h1> <p>The contact form is currently inactive. Get a functional and working contact form with Ajax & PHP in a few minutes. Just copy and paste the files, add a little code and you're done. Download Now. </p>  ";
        }
        public string About()
        {
            return "<h4>About US</h4><h1>If You Have Any Query, Please Contact Us</h1> <p>The contact form is currently inactive. Get a functional and working contact form with Ajax & PHP in a few minutes. Just copy and paste the files, add a little code and you're done. Download Now. </p>  ";
        }

    }
}