using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using System;

namespace DataManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController:Controller
    {
        IUserManager _userManager;
        public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public IEnumerable<User> Get([FromQuery] string pagesize)
    {
        return _userManager.GetAllUser();
    }
    // GET api/user/5  
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
            if (_userManager.GetUserById(id) == null)
            {

                 var result = new OkObjectResult(new { message = "User does not exist" });
                return result;
            }
            else
            {
                return _userManager.GetUserById(id);
            }
            
            
    }
    // POST api/user  
    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
            
                _userManager.AddUser(user);
            if (user.UserEmail == "User already exists")
            {
                var result = new OkObjectResult(new { message = "User already exists" });
                return result;
            }
            else
            {
                var result = new OkObjectResult(new { message = "New User Added successfully" });
                return result;
            }
        
    }
    // PUT api/user/5  
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User user)
    {
            if(user.UserId==0)
            {
                var result = new BadRequestObjectResult(new { message = "User Id Should be passed to update" });
                return result;
            }
            else
            {
                _userManager.UpdateUser(user);
                var result = new OkObjectResult(new { message = "Updated successfully" });
                return result;
            }
        
            
    }
    // DELETE api/user/5  
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _userManager.DeleteUser(id);
            var result = new OkObjectResult(new { message = "User Deleted Successfully" });
            return result;
        }
}  
}  