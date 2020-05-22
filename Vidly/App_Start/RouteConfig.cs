using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Attribute Routes
            routes.MapMvcAttributeRoutes();

            ////Custom Route
            //routes.MapRoute(
            //    "MoviesByReleasedDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action= "ByReleasedDate" },
            //    new { year= @"\d{4}", month = @"\d{2}", } // 2019|2020" instead of year if want ot restrict years
            //    // In Custom Route if method/route changesthen it will not update action in routeconfig.cs,
            //    //So we have to achieve this by using Attribute Routes route
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
