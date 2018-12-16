using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DemoWebApi.Models;

namespace DemoWebApi.Controllers
{
    public class LinkRoomReservationsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/LinkRoomReservations
        public IQueryable<LinkRoomReservation> GetLinkRoomReservations()
        {
            return db.LinkRoomReservations;
        }

        // GET: api/LinkRoomReservations/5
        [ResponseType(typeof(LinkRoomReservation))]
        public async Task<IHttpActionResult> GetLinkRoomReservation(int id)
        {
            LinkRoomReservation linkRoomReservation = await db.LinkRoomReservations.FindAsync(id);
            if (linkRoomReservation == null)
            {
                return NotFound();
            }

            return Ok(linkRoomReservation);
        }

        // PUT: api/LinkRoomReservations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLinkRoomReservation(int id, LinkRoomReservation linkRoomReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linkRoomReservation.IdLinkRoomReservation)
            {
                return BadRequest();
            }

            db.Entry(linkRoomReservation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkRoomReservationExists(id))
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

        // POST: api/LinkRoomReservations
        [ResponseType(typeof(LinkRoomReservation))]
        public async Task<IHttpActionResult> PostLinkRoomReservation(LinkRoomReservation linkRoomReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LinkRoomReservations.Add(linkRoomReservation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = linkRoomReservation.IdLinkRoomReservation }, linkRoomReservation);
        }

        // DELETE: api/LinkRoomReservations/5
        [ResponseType(typeof(LinkRoomReservation))]
        public async Task<IHttpActionResult> DeleteLinkRoomReservation(int id)
        {
            LinkRoomReservation linkRoomReservation = await db.LinkRoomReservations.FindAsync(id);
            if (linkRoomReservation == null)
            {
                return NotFound();
            }

            db.LinkRoomReservations.Remove(linkRoomReservation);
            await db.SaveChangesAsync();

            return Ok(linkRoomReservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinkRoomReservationExists(int id)
        {
            return db.LinkRoomReservations.Count(e => e.IdLinkRoomReservation == id) > 0;
        }
    }
}