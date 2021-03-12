using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        db dbObj = new db();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] CustomerIdentity cusIden)
        {
            int res = dbObj.checkLogin(cusIden);
            if (res == 1)
            {
                TempData["msg"] = "Welcome to my page";
                return RedirectToAction("Index", "Products");
            }
            else
            {

                TempData["msg"] = "UserID or Password is wrong.!";
                return RedirectToAction("Index");
            }
            

        }

        public IActionResult Privacy()
        {
            ViewData["Massage"] = "Description page";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
