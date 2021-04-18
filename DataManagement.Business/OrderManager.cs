using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using System.Collections.Generic;

namespace DataManagement.Business
{
    public class OrderManager: IOrderManager
    {
        IOrderRepository _orderrepository;
        public OrderManager(IOrderRepository Orderrepository)
        {
            _orderrepository = Orderrepository;
        }

        public bool AddOrder(Order order)
        {
            return _orderrepository.AddOrder(order);
        }
        public bool DeleteOrder(int OrderId)
        {
            return _orderrepository.DeleteOrder(OrderId);
        }
        public IList<Order> GetAllOrders()
        {
            return _orderrepository.GetAllOrders();
                }
        public Order GetOrderbyId(int orderId)
        {
            return _orderrepository.GetOrderbyId(orderId);
        }
        public bool UpdateOrder(Order order)
        {
            return _orderrepository.UpdateOrder(order);
        }
    }
}
