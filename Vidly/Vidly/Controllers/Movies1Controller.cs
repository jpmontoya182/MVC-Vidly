using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class Movies1Controller : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek 2" };

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id : {id}");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");

        }

        // GET : movies/released/2020/4 -> in routes ew defined this behaviour
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // example different types of pass data to the view
        public ActionResult RandomData()
        {
            var movie = new Movie() { Name = "Shrek come back !!" };
            // it's no recommended pass data to the view, with these two methosd
            // because is fragile when you make a change, use the same method that 
            // random.
            ViewData["Movie"] = movie;
            ViewBag.RandomMovie = movie;
            return View();
        }

        // example ViewModels
        public ActionResult RandomViewModel()
        {
            var movie = new Movie() { Name = "Shrek 3" };
            var customers = new List<Customer>
            {
                new Customer { Name="customer 1"},
                new Customer { Name = "customer 2"},
                new Customer { Name = "customer 3"},
                new Customer { Name = "customer 4"},
                new Customer { Name = "customer 5"},
                new Customer { Name = "customer 6"}

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);


        }


    }
}