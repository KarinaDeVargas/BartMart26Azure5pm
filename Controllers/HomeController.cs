using BartmartWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BartmartWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/homepage.cshtml");
        }

        public IActionResult Signup()
        {
            return View("~/Views/Auth/Signup.cshtml");
        }
        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        //public IActionResult NewListing()
        //{
        //return View("~/Views/Pages/NewListing.cshtml");
        //}

        public IActionResult EditListing()
        {
            return View("~/Views/Pages/EditListing.cshtml");
        }
        public IActionResult ListingDetails()
        {
            return View("~/Views/Pages/ListingDetails.cshtml");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Homepage()
        {
            return View();
        }
        public IActionResult Browsepage()
        {
            return View();
        }

        // Search Action for search engine
        public IActionResult SearchEngine(string query)
        {
            ViewData["Query"] = query;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
