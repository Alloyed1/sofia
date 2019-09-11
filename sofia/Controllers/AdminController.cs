using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sofia.Models;
using sofia.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sofia.Controllers
{
	public class AdminController : Controller
	{
		SignInManager<User> _signInManager;
		UserManager<User> _userManager;
		ApplicationContext _context;
		public AdminController(SignInManager<User> signInManager, UserManager<User> userManager, ApplicationContext context)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Panel", "Admin");
			}
			return View();
		}
        
		[HttpPost]
		public async Task<IActionResult> Index(string Password, string Name)
		{
			
			if (Password == "adminnastya668" && Name == "admin")
			{
				User user = _userManager.Users.Where(s => s.UserName == "admin").FirstOrDefault();
				if (user != null)
				{
					await _signInManager.SignInAsync(_userManager.Users.Where(s => s.UserName == "admin").FirstOrDefault(), true);
					return RedirectToAction("Panel", "Admin");
				}
				else
				{
					var result = await _userManager.CreateAsync(new User { Email = "admin", UserName = "admin" }, "adminnastya668");		
					await _signInManager.SignInAsync(_userManager.Users.Where(s => s.UserName == "admin").FirstOrDefault(), true);
					return RedirectToAction("Panel", "Admin");
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddObject()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddObject(AddHomeViewModel mode, IFormFileCollection files)
		{
            Home home = new Home
            {
                About = mode.About,
                Adress = mode.Adress,
                TypeSdelki = mode.TypeSdelki,
                Coords = mode.Coords,
                AllCountRoom = mode.AllCountRoom,
                AllPloshadRoom = mode.AllPloshadRoom,
                Animals = mode.Animals,
                Balkon = mode.Balkon,
                Children = mode.Children,
                Communal = mode.Communal,
                Comnat = mode.Comnat,
                Etag = mode.Etag,
                EtagAll = mode.EtagAll,
                Kuxnya = mode.Kuxnya,
                ObjectText = mode.ObjectText,
                Name = mode.Name,
                Price = mode.Price,
                PloshadRoom = mode.PloshadRoom,
                Predoplata = mode.Predoplata,
                Sostav = mode.Sostav,
                Parkovka = mode.Parkovka,
                Remont = mode.Remont,
                SanUzelRazdel = mode.SanUzelRazdel,
                SanUzelVmeste = mode.SanUzelVmeste,
                TypeArenda = mode.TypeArenda,
                TypeCommerce = mode.TypeCommerce,
                Zalog = mode.Zalog
            };
            var result =  await _context.AddAsync(home);
            if(mode.Dop != null)
            {
                foreach (string text in mode.Dop)
                {
                    await _context.AddAsync(new Dop { HomeId = result.Entity.Id, Text = text });
                }
            }
            if(files.Count() != 0)
            {
                foreach (var uploadedFile in files)
                {
                    Photos photos = new Photos();
                    using (var memoryStream = new MemoryStream())
                    {
                        await uploadedFile.CopyToAsync(memoryStream);
                        photos.Photo = memoryStream.ToArray();
                    }
                    photos.HomeId = result.Entity.Id;
                    await _context.AddAsync(photos);
                }
            }
            

            await _context.AddAsync(home);
            await _context.SaveChangesAsync();
			return RedirectToAction("Panel", "Admin");
		}
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Panel()
		{
            var model = new List<AdminViewModel>();
            var items = _context.Homes.ToList();

            foreach(var item in items)
            {
                var mod = new AdminViewModel();
                mod.about = item.About;
                mod.Id = item.Id;
                mod.Name = item.Name;
                mod.Price = item.Price;
                mod.Photo =  _context.Photos.Where(w => w.HomeId == item.Id).Select(s => s.Photo).FirstOrDefault();
                model.Add(mod);
            }
			return View(model);
		}
	}
}
