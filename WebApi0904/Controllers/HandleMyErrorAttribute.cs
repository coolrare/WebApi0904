using System;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;

namespace WebApi0904.Controllers
{
    public class HandleMyErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, new MyError()
            {
                Error_Code = 1,
                Error_Msg = actionExecutedContext.Exception.Message
            });
        }
    }
}