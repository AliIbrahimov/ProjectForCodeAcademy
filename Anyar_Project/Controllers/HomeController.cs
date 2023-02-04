using Anyar_Project.DAL;
using Anyar_Project.Models;
using Anyar_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Anyar_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Employees = _context.Employees.Include(x=>x.Icons).ToList(),
                Settings = _context.Settings.ToList()
            };
            return View(homeVM);
        }

    }
}