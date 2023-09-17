using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Task1.Models;

namespace Task1.Controllers
{
    public class OrderController : Controller
    {
        NorthwindContext _db;
        public OrderController(NorthwindContext db)
        {
            _db = db;
        }
        public IActionResult OrderList(int id)
        {
            List<Order> orders  = _db.Orders.Where(x => x.EmployeeId == id).Select(x => 
                new Order
                {
                    OrderId = x.OrderId,
                    OrderDate = x.OrderDate,
                    ShipCountry = x.ShipCountry
                }).ToList();

            return View(orders);
        }
    }
}
