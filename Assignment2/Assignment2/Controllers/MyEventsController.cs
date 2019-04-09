using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    public class MyEventsController : Controller
    {

        //connect
        DbModel db;

        public MyEventsController(DbModel db)
        {
            this.db = db;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MyEvent> Get()
        {
            return db.MyEvents.OrderBy(e => e.EventId).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var myevent = db.MyEvents.SingleOrDefault(e => e.EventId == id);

            if (myevent == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(myevent);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]MyEvent myevent)
        {
            if (!ModelState.IsValid)

            {
                return BadRequest();
            }
            else
            {
                db.MyEvents.Add(myevent);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = myevent.EventId }, myevent);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]MyEvent myevent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(myevent).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = myevent.EventId }, myevent);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var myevent = db.MyEvents.SingleOrDefault(e => e.EventId == id);
            if (myevent == null)
            {
                return NotFound();
            }
            else
            {
                db.MyEvents.Remove(myevent);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}