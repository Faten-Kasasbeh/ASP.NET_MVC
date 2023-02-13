using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api_test.Models;

namespace Api_test.Controllers
{
    public class collegesController : ApiController
    {
        private UniversityEntities1 db = new UniversityEntities1();

        // GET: api/colleges
        public IQueryable<college> Getcolleges()
        {
            return db.colleges;
        }

        // GET: api/colleges/5
        [ResponseType(typeof(college))]
        public IHttpActionResult Getcollege(int id)
        {
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return NotFound();
            }

            return Ok(college);
        }

        // PUT: api/colleges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcollege(int id, college college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != college.ID)
            {
                return BadRequest();
            }

            db.Entry(college).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!collegeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/colleges
        [ResponseType(typeof(college))]
        public IHttpActionResult Postcollege(college college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.colleges.Add(college);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (collegeExists(college.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = college.ID }, college);
        }

        // DELETE: api/colleges/5
        [ResponseType(typeof(college))]
        public IHttpActionResult Deletecollege(int id)
        {
            college college = db.colleges.Find(id);
            if (college == null)
            {
                return NotFound();
            }

            db.colleges.Remove(college);
            db.SaveChanges();

            return Ok(college);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool collegeExists(int id)
        {
            return db.colleges.Count(e => e.ID == id) > 0;
        }
    }
}