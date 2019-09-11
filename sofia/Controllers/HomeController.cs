using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sofia.Models;
using sofia.ViewModels;

namespace sofia.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;
        public HomeController(ApplicationContext _context)
        {
            this._context = _context;
        }
		public IActionResult Index()
		{
            var model = new List<AdminViewModel>();
            var items = _context.Homes.ToList();

            foreach (var item in items)
            {
                var mod = new AdminViewModel();
                mod.about = item.About;
                mod.Id = item.Id;
                mod.Name = item.Name;
                mod.Price = item.Price;
                mod.Photo = _context.Photos.Where(w => w.HomeId == item.Id).Select(s => s.Photo).FirstOrDefault();
                mod.Coords = item.Coords;
                model.Add(mod);
            }
            return View(model);
		}

        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            _context.Homes.Remove(_context.Homes.Where(w => w.Id == id).FirstOrDefault());
            _context.Photos.RemoveRange(_context.Photos.Where(w => w.HomeId == id));
            _context.Dops.RemoveRange(_context.Dops.Where(w => w.HomeId == id));
            _context.SaveChanges();
            return RedirectToAction("Panel", "Admin");
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            var item = _context.Homes.FirstOrDefault(w => w.Id == id);
            var itm = new ItemViewModel { Dop = _context.Dops
                .Where(s => s.HomeId == item.Id)
                .Select(s => s.Text)
                .ToList(),

                Home = item,

                Photos = _context.Photos
                .Where(s => s.HomeId == item.Id)
                .Select(s => s.Photo)
                .ToList()
            };
            return View(itm);
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
