using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Task1.Models;

namespace Task1.Controllers
{
    public class EmployeeController : Controller
    {
        NorthwindContext _db;
        public EmployeeController(NorthwindContext db)
        {
            _db = db;
        }
        public IActionResult List()
        {
            List<Employee> employees = _db.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return View(employee);
            }
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
