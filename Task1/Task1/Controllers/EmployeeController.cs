using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Task1.Models;
using Task1.Models.ViewModel;

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
            //List<Employee> employees = _db.Employees.ToList();

            List<EmployeeListViewModel> employees = _db.Employees.Select(e => 
                new EmployeeListViewModel() 
                {
                    EmployeeID = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Title = e.Title
                }).ToList();

            return View(employees);
        }
        public IActionResult OrderList(int id)
        {
            List<OrderListViewModel> orders = _db.Orders.Where(x => x.EmployeeId == id).Select(x =>
                new OrderListViewModel
                {
                    OrderID = x.OrderId,
                    OrderDate = x.OrderDate,
                    ShipCountry = x.ShipCountry
                }).ToList();

            return View(orders);
        }
        public IActionResult Create()
        {
            List<SelectListItem> employees = _db.Employees.Select(e =>
                new SelectListItem()
                {
                    Text = $"{e.FirstName} {e.LastName}",
                    Value = e.EmployeeId.ToString()
                }).ToList();

            ViewBag.Employees = employees;

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            Employee employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                ReportsTo = model.ReportsTo
            };

            if(!ModelState.IsValid)
            {
                return View(employee);
            }

            _db.Employees.Add(employee);
            int result = _db.SaveChanges();
            if(result == 0) 
            {
                ViewBag.Message = "Registration Failed";
                return View();
            }

            return RedirectToAction(nameof(List));
        }
    }
}
