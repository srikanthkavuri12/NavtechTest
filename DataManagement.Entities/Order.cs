using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string  OrderName { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderCreatedDate { get; set; } = DateTime.Now;
       
    }
}
