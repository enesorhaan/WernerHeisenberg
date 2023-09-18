using System;

namespace Task1.Models.ViewModel
{
    public class OrderListViewModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCountry { get; set; }
    }
}
