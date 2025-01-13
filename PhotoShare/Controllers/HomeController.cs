using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}