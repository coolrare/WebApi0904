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
using WebApi0904.Models;

namespace WebApi0904.Controllers
{
    [RoutePrefix("clients")]
    public class ClientsController : ApiController
    {
        private FabricsEntities db = new FabricsEntities();

        public ClientsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: api/Clients
        [Route("get1")]
        public IQueryable<Client> GetClient1()
        {
            return db.Client.Take(10);
        }

        [Route("get2")]
        public IHttpActionResult GetClient2()
        {
            return Ok(db.Client.Take(10));
        }

        [Route("get3")]
        public HttpResponseMessage GetClient3()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent<IQueryable<Client>>(db.Client.Take(10),
                    GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                ReasonPhrase = "VERY_OK"
            };
        }

        [Route("get4")]
        public HttpResponseMessage GetClient4()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Client.Take(10));
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        [Route("{id}", Name = "GetClientById")]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        [Route("{id}/orders")]
        [Route("~/ClientOrders/{id}")]
        public IHttpActionResult GetClientOrders(int id)
        {
            var orders = db.Order.Where(p => p.ClientId == id);

            return Ok(orders);
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        [Route("{id}/orders/{*date:datetime}")]
        public IHttpActionResult GetClientOrders(int id, DateTime date)
        {
            var orders = db.Order
                .Where(p => p.ClientId == id
                    && p.OrderDate.Value.Year == date.Year
                    && p.OrderDate.Value.Month == date.Month
                    && p.OrderDate.Value.Day == date.Day);

            return Ok(orders);
        }

        [ResponseType(typeof(Client))]
        [Route("{id}/orders/pending")]
        public IHttpActionResult GetClientOrdersPending(int id)
        {
            var orders = db.Order
                .Where(p => p.ClientId == id
                    && p.OrderStatus == "P");

            return Ok(orders);
        }



        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        [Route("")]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("GetClientById", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.ClientId == id) > 0;
        }
    }
}