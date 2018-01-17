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
using TechTalk.Models;

namespace TechTalk.Controllers
{
    public class RegisterController : ApiController
    {
        private TechtalkDbEntities db = new TechtalkDbEntities();

        // GET: api/Register
        public IQueryable<Admin_Register> GetAdmin_Register()
        {
            return db.Admin_Register;
        }

        // GET: api/Register/5
        [ResponseType(typeof(Admin_Register))]
        public IHttpActionResult GetAdmin_Register(int id)
        {
            Admin_Register admin_Register = db.Admin_Register.Find(id);
            if (admin_Register == null)
            {
                return NotFound();
            }

            return Ok(admin_Register);
        }

        // PUT: api/Register/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdmin_Register(int id, Admin_Register admin_Register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin_Register.AId)
            {
                return BadRequest();
            }

            db.Entry(admin_Register).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Admin_RegisterExists(id))
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

        // POST: api/Register
        [ResponseType(typeof(Admin_Register))]
        public IHttpActionResult PostAdmin_Register(Admin_Register admin_Register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Admin_Register.Add(admin_Register);
            db.SaveChanges();

            return CreatedAtRoute("/api/Admin_Registration", new { id = admin_Register.AId }, admin_Register);
        }

        // DELETE: api/Register/5
        [ResponseType(typeof(Admin_Register))]
        public IHttpActionResult DeleteAdmin_Register(int id)
        {
            Admin_Register admin_Register = db.Admin_Register.Find(id);
            if (admin_Register == null)
            {
                return NotFound();
            }

            db.Admin_Register.Remove(admin_Register);
            db.SaveChanges();

            return Ok(admin_Register);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Admin_RegisterExists(int id)
        {
            return db.Admin_Register.Count(e => e.AId == id) > 0;
        }
    }
}