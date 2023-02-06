using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_5_2.Models;

namespace Mvc_5_2.Controllers
{
    public class EmployeesController : Controller
    {
        private mvc2Entities db = new mvc2Entities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Img,CV")] Employee employee
            ,HttpPostedFileBase Img, HttpPostedFileBase CV)
        {

            if (ModelState.IsValid)
            {
                if (Img != null && Img.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                  Path.GetFileName(Img.FileName)) ;
                        Img.SaveAs(path);
                       employee.Img = "../Images/" + Path.GetFileName(Img.FileName);

                }

                if (CV != null && CV.ContentLength > 0)
                {
                    string folderPath = Server.MapPath("~/CVs");
                    string path = Path.Combine(Server.MapPath("~/CVs"),
                                  Path.GetFileName(CV.FileName));
                    CV.SaveAs(path);
                    employee.CV = "../CVs/" + Path.GetFileName(CV.FileName);

                }





                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        public ActionResult Search(string check, string searchQuery)

        {
            if (check == "First_Name")
            {
                var x1 = db.Employees.Where(x => x.First_Name.Contains(searchQuery));
                return View("Index", x1.ToList());
            }
            if (check == "E_mail")
            {
                var x2 = db.Employees.Where(x => x.E_mail.Contains(searchQuery));
                return View("Index", x2.ToList());
            }
            if (check == "Last_Name")
            {
                var x3 = db.Employees.Where(x => x.Last_Name.Contains(searchQuery));
                return View("Index", x3.ToList());
            }

            else
            {
                return View();
            }


        }
        // GET: infoes/Edit/5



        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Img,CV")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
