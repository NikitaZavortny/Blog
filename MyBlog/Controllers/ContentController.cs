using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Routing;

namespace MyBlog.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext applicationDb;

        public ActionResult Index(int id)
        {
            return View(applicationDb.States.FirstOrDefault(x => x.Id == id));
        }
        public ContentController(ApplicationDbContext a)
        {
            applicationDb = a;
        }

        public RedirectToActionResult Delete(int id)
        {
            applicationDb.States.Remove(applicationDb.States.FirstOrDefault(x => x.Id == id));
            applicationDb.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
        }

        [HttpGet]
        public IActionResult AddState()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddState(State state)
        {
            state.CreationDate = DateTime.Now;
            applicationDb.States.Add(state);
            applicationDb.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult EditState(int id)
        {
            return View(applicationDb.States.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult EditState(State state) 
        {
            var item = applicationDb.States.FirstOrDefault(x => x.Id == state.Id);
            applicationDb.States.Remove(item);
            applicationDb.States.Add(state);
            applicationDb.SaveChanges();
            return View();
        }
    }
}
