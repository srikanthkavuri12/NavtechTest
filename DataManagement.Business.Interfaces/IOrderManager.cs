using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Business.Interfaces
{
   public  interface IOrderManager
    {
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int OrderId);
        IList<Order> GetAllOrders();
        Order GetOrderbyId(int OrderId);
    }
}
