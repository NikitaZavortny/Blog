using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Data;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext appdb;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _appdb)
        {
            _logger = logger;
            appdb = _appdb;
        }

        public IActionResult Index()
        {
            return View(appdb.States.OrderBy(x => x.CreationDate).Take(5).ToList());
        }

        public async Task<IActionResult> Privacy()
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
