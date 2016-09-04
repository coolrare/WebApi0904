using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace WebApi0904.Controllers
{
    public class LoginController : ApiController
    {
        public IHttpActionResult Post(LoginVM user)
        {
            if (user.username == "will" && user.password == "123")
            {
                FormsAuthentication.RedirectFromLoginPage(user.username, false);

                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
        }
    }
}
