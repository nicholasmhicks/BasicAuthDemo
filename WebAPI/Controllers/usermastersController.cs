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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class usermastersController : ApiController
    {
        private AuthenticationDemoEntities db = new AuthenticationDemoEntities();

        // GET: api/usermasters
        [BasicAuthentication]
        public IQueryable<usermaster> Getusermasters()
        {
            return db.usermasters;
        }

        // GET: api/usermasters/5
        [ResponseType(typeof(usermaster))]
        public IHttpActionResult Getusermaster(int id)
        {
            usermaster usermaster = db.usermasters.Find(id);
            if (usermaster == null)
            {
                return NotFound();
            }

            return Ok(usermaster);
        }

        // PUT: api/usermasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putusermaster(int id, usermaster usermaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usermaster.Id)
            {
                return BadRequest();
            }

            db.Entry(usermaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usermasterExists(id))
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

        // POST: api/usermasters
        [ResponseType(typeof(usermaster))]
        public IHttpActionResult Postusermaster(usermaster usermaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usermasters.Add(usermaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (usermasterExists(usermaster.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usermaster.Id }, usermaster);
        }

        // DELETE: api/usermasters/5
        [ResponseType(typeof(usermaster))]
        public IHttpActionResult Deleteusermaster(int id)
        {
            usermaster usermaster = db.usermasters.Find(id);
            if (usermaster == null)
            {
                return NotFound();
            }

            db.usermasters.Remove(usermaster);
            db.SaveChanges();

            return Ok(usermaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usermasterExists(int id)
        {
            return db.usermasters.Count(e => e.Id == id) > 0;
        }
    }
}