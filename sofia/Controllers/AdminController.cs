using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
		public IActionResult AddObject(AddHomeViewModel mode)
		{
			return RedirectToAction("Panel", "Admin");
		}
		[HttpGet]
		[Authorize]
		public IActionResult Panel()
		{
			return View();
		}
	}
}
