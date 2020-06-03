using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab28_SWAPI.Models;

namespace Lab28_SWAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SwapiDAL SP = new SwapiDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonSearch(int Id)
        {
            Person p = SP.GetPersonbyId("people", Id);
            return View(p);
        }

        public IActionResult PlanetSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlanetSearch(int Id)
        {
            Planet p = SP.GetPlanetbyId("planets", Id);
            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
