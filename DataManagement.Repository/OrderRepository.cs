using Dapper;
using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using DataManagement.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DataManagement.Repository
{

    public class OrderRepository : BaseRepository,
IOrderRepository
    {

        public bool AddOrder(Order order)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@OrderName", order.OrderName);
                parameters.Add("@OrderType", order.OrderType);
                parameters.Add("@OrderCreateDate", order.OrderCreatedDate);
                parameters.Add("@PageSize", order.Pagesize);
                SqlMapper.Execute(con, "AddOrder", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteOrder(int OrderId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OrderId", OrderId);
            SqlMapper.Execute(con, "DeleteOrder", param: parameters, commandType: StoredProcedure);
            return true;
        }
        public IList<Order> GetAllOrders()
        {
            IList<Order> OrderList = SqlMapper.Query<Order>(con, "GetAllOrders", commandType: StoredProcedure).ToList();
            return OrderList;
        }
        public Order GetOrderbyId(int OrderId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OrderId", OrderId);
                return SqlMapper.Query<Order>((SqlConnection)con, "GetOrderById", parameters, commandType: StoredProcedure).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateOrder(Order order)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@OrderId", order.OrderId);
                parameters.Add("@OrderName", order.OrderName);
                parameters.Add("@OrderType", order.OrderType);

                SqlMapper.Execute(con, "UpdateOrder", param: parameters, commandType: StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

