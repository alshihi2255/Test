using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public List<User> users = new List<User>()
        {
            new User {Id=111, Name="Adil"}
        };
        public List<User> users1 = new List<User>()
        {
            new User {Id=222, Name="ahmed"}
        };
        public UserController()
        {

        }

        [HttpGet]
        public ActionResult GetUser()
        {
            //var user = new User { Id = 1111, Name = "Adel" };
            return Ok(users);
        }

        [HttpGet]
        [Route("newlist")]
        public ActionResult GetUser1()
        {
            //var user = new User { Id = 1111, Name = "Adel" };
            return Ok(users1);
        }



        [HttpPost]
        public ActionResult AddUser(User user)
        {
            //var newUser = new User { Id = 1111, Name = "Adel2" };
            return Ok(users1);
        }
    }
}
