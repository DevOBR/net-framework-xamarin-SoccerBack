﻿namespace API.Controllers
{
    using Domain;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    [Authorize]
    public class LeaguesController : ApiController
    {
        private readonly DataContext db = new DataContext();

        // GET: api/Leagues
        public IQueryable<League> GetLeagues()
        {
            return db.Leagues;
        }

        // GET: api/Leagues/5
        [ResponseType(typeof(League))]
        public async Task<IHttpActionResult> GetLeague(int id)
        {
            League league = await db.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            return Ok(league);
        }

        // PUT: api/Leagues/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLeague(int id, League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != league.LeagueId)
            {
                return BadRequest();
            }

            db.Entry(league).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueExists(id))
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

        // POST: api/Leagues
        [ResponseType(typeof(League))]
        public async Task<IHttpActionResult> PostLeague(League league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leagues.Add(league);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = league.LeagueId }, league);
        }

        // DELETE: api/Leagues/5
        [ResponseType(typeof(League))]
        public async Task<IHttpActionResult> DeleteLeague(int id)
        {
            League league = await db.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            db.Leagues.Remove(league);
            await db.SaveChangesAsync();

            return Ok(league);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeagueExists(int id)
        {
            return db.Leagues.Count(e => e.LeagueId == id) > 0;
        }
    }
}