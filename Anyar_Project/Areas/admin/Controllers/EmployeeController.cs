using Anyar_Project.DAL;
using Anyar_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anyar_Project.Areas.admin.Controllers
{
    [Area("admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            string imageName = Guid.NewGuid()+employee.FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath,"assets/img/team",imageName);
            using (FileStream fileStrem = new FileStream(path, FileMode.Create))
            {
                employee.FormFile.CopyTo(fileStrem);
            }
            employee.Image = imageName;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var existEmployee = _context.Employees.Find(employee.Id);
            if (employee.FormFile is not null)
            {
                string imageName =  Guid.NewGuid()+employee.FormFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/img/team", imageName);
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    employee.FormFile.CopyTo(fileStream);
                }
                existEmployee.Image = imageName;
            }
            existEmployee.Name = employee.Name;
            existEmployee.Title = employee.Title;
            existEmployee.Position = employee.Position;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var existEmployee = _context.Employees.Find(id);
            _context.Employees.Remove(existEmployee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
