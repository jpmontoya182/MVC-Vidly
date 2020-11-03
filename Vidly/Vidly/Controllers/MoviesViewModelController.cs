using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesViewModelController : Controller
    {



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