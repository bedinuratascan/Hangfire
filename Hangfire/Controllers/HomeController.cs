using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hangfire.Models;
using Hangfire.BackgroundJobs;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Hangfire.Controllers
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
            return View();
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

        public IActionResult Signup()
        {
            FireAndForgetJobs.SendEmailToUserJob("12359778", "Welcome to my blog");

            return View();
        }

        public IActionResult PictureSave()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName = String.Empty;

            if(picture!=null && picture.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/watermarks", newFileName);

                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
                string jobID = BackgroundJobs.DelayedJobs.AddWatermark(newFileName, "www.bedinuratascan.com");
            }
            return View();
        }
    }
}
