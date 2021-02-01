using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
   // http://localhost:4256/api/user

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUser()
        {
            var user = new User { Id = 1111, Name = "Adel" };
            return Ok(user);
        }


        [HttpPost]
        public ActionResult AddUser(User user)
        {
            var newUser = new User { Id = 1111, Name = "Adel2" };
            return Ok(newUser);
        }
    }
}
