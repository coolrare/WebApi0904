using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebApi0904.Controllers;

namespace WebApi0904
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API 設定和服務
            // 將 Web API 設定成僅使用 bearer 權杖驗證。
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //config.Filters.Add(new CheckModelStateAttribute());
            config.Filters.Add(new HandleMyErrorAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
