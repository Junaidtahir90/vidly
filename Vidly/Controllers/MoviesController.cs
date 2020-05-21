using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Models.Movie() { Name = "Life is Horror" };
            //movie.Name = "Bad boy";
            return View(movie);
        }
    }
}