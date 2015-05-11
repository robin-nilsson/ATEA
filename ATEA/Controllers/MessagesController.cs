using ATEA.Context;
using ATEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ATEA.console;

namespace ATEA.Controllers
{
    public class MessagesController : ApiController
    {
        private ATEAContext _db = new ATEAContext();

        public IQueryable<Message> Get()
        {
            return _db.Messages;
        }

        // Expect a response type of Message
        [ResponseType(typeof(Message))]
        public IHttpActionResult Get(int id)
        {
            Message message = _db.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        [HttpPost]
        [ResponseType(typeof(Message))]
        public IHttpActionResult Post(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Messages.Add(message);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = message.MessageId }, message);
        }
    }
}
