using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi0904.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        [Route("jsm")]
        public IHttpActionResult GetJsonSupportedMediaTypes()
        {
            return Ok(GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes);
        }

        [Route("jse")]
        public IHttpActionResult GetJsonSupportedEncodings()
        {
            return Ok(GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedEncodings);
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
