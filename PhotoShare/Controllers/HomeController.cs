using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhotoShare.Models;


namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {

        //Constructor
        public HomeController()
        {
            
        }

        //Home page
        public IActionResult Index()
        {
            //Create a list of photos
            List<Photo> photos = new List<Photo>();

            //Create 3 photo objects
            Photo photo1 = new Photo()
            {
                PhotoId = 1,
                Title = "Grey cat",
                Description = "A grey cat.",
                ImageFilename = "greycat1.jpg",
                IsPublic = true
            };

            Photo photo2 = new Photo()
            {
                PhotoId = 2,
                Title = "Ragdoll cat",
                Description = "A ragdoll cat.",
                ImageFilename = "ragdollcat1.jpg",
                IsPublic = true
            };

            Photo photo3 = new Photo()
            {
                PhotoId = 3,
                Title = "Strawberry orange cat",
                Description = "A strawberry orange cat.",
                ImageFilename = "strawberryorangecat1.jpg",
                IsPublic = true
            };

            //Add them to the list
            photos.Add(photo1);
            photos.Add(photo2);
            photos.Add(photo3);

            return View();

        }

        //Display the photo by ID
        public IActionResult DisplayPhoto(int id)
        {
            Photo photo = new Photo()
            {
                PhotoId = id,
                Title = "Black cat",
                Description = "A black cat",
                ImageFilename = "blackcat.jpg",
                IsPublic = true,
            };

            //Pass the photo to the view
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}