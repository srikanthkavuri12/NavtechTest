using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavtechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderManager _ordermanager;
        public OrdersController(IOrderManager orderManager)
        {
            _ordermanager = orderManager;
        }
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            
            return _ordermanager.GetAllOrders();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id, [FromQuery] int PageSize)
        {
            if (_ordermanager.GetOrderbyId(id) == null)
            {
                var result = new NotFoundObjectResult(new { message = "Order does not exist" });
                return result;
            }
            else
            {
                int id1 = _ordermanager.GetOrderbyId(id).OrderId;
                int PageSize1 = _ordermanager.GetOrderbyId(id).Pagesize;
                if (id1 == id && PageSize1 == PageSize)
                {
                    return _ordermanager.GetOrderbyId(id);
                }
                else if(id1 == id && PageSize1 != PageSize)
                {
                    var result = new NotFoundObjectResult(new { message = "PageSize does not exist "+"  Page Size for Order  "+id1+" is "+PageSize1 });
                    return result ;
                }
                else
                {
                    return _ordermanager.GetOrderbyId(id);
                }
            }
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            _ordermanager.AddOrder(order);
            if (order.OrderName != null && order.OrderType!=null )
            {
                var result = new OkObjectResult(new { message = "New Order Added successfully" });
                return result;
            }
            else
            {
                var result = new BadRequestObjectResult(new { message = "Data is Incorrect" });
                return result;
            }
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (order.OrderId == 0)
            {
                var result = new BadRequestObjectResult(new { message = "Order Id Should be passed to update" });
                return result;
            }
            else
            {
                _ordermanager.UpdateOrder(order);
                var result = new OkObjectResult(new { message = "Updated successfully" });
                return result;
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _ordermanager.DeleteOrder(id);
            var result = new OkObjectResult(new { message = "Order deleted Successfully" });
            return result;
        }
    }
}
