using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            // ActionResult is base calss for all action results in asp.net vc,return result as per reuest the data get in request
            // Action Results types
            var movie = new Models.Movie() { Name = "Life is Horror" };
            var customersList = new List<Customer>
            {
                new Customer { Name = "Alex Murphy" },
                new Customer { Name = "Rebbeca Oven" },
                new Customer { Name = "Simon Lance" }
            };


            //movie.Name = "Bad boy";
            #region Passing Data to view
            // Data can be passed using simple view,Viewdata and ViewBag
            // Viewdata
            //ViewData["Movie"] = movie;
            // View Data
            //ViewBag.Mov = movie;
            //lViewBag.RandomMovie = movie; // Vidly.Models.Movie as output

            var randomMovieViewModel = new RandomMovieViewModel
            {
                movie = movie,
                customers = customersList
            };

            return View(randomMovieViewModel);

            //return View(movie);
            #endregion
            // return View(movie);

            #region ActionResult Types
            // Content Result
            //return Content("This is content response");
            //  Not Found Result 
            //return HttpNotFound();
            // Empty Result
            //return new EmptyResult();
            // redirect action without params
            //return RedirectToAction("Index", "Home");
            // redirect action with params
            //return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
            // Ctrl+Shift+B to build application
            //return new ViewResult();
            #endregion
        }

        // GET: Movies/edit
        public ActionResult Edit(int Id)
        {
            // Simple param as movies/edit/1
            // Query strig format param movies/edit?id=3 
            return Content("Id=" + Id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";

            return Content(String.Format("pageIndex={0}&sortby={1}", pageIndex, sortBy));
        }

        //  [Route("movies/released/{year}/{month:regex(\\d{2}:range:1-12)}")] if apply regex then below error occur
        //No parameterless constructor defined for this object.
        // error is Line 16:             routes.MapMvcAttributeRoutes(); //routeconfig.cs
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleasedDate(int? year, int? month)
        {

            return Content(year + "/" + month);
            //if (!year.HasValue)
            //    year = 2000;
            //if (!month.HasValue)
            //    month = 1;
            //return Content(String.Format("year={0}&month={1}", year, month));

        }

    }
}