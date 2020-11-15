using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistrationLab.Controllers
{
    public class ViewMoviesController : Controller
    {
        public IActionResult Index()
        {
            return View("ViewMovies");
        }
    }
}
