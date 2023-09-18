using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomRouteHandlerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            Route newRoute = new Route("{controller}/{action}", new MyRouteHemdler());
            routes.Add(newRoute);
        }
    }

    public class MyRouteHemdler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MyHttpHandler();
        }
    }

    public class MyHttpHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<h2>Hello World!</h2>"); //при запуске выдаст ошибку. Необходимо обратиться с двусегментным запросом 

        }
    }
}
