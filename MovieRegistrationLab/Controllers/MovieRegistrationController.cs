using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistrationLab.Controllers
{
    public class MovieRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View("MovieRegistration");
        }
        public IActionResult MovieConfirmation(Models.Movie movie)
        {
            movie.AddToDB(movie);
            return View(movie);
        }
        public IActionResult ViewMovies()
        {
            return View();
        }
    }
}
