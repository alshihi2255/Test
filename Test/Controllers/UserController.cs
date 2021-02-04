using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test
{


    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
       
        //public List<User> users = new List<User>()
        //{

        //    new User {Id=111, Name="Adil"}
        //};
        //public List<User> users1 = new List<User>()
        //{
        //    new User {Id=222, Name="ahmed"}
        //};
        public UserController()
        {

        }

        [HttpGet]
        public   void GetUser()
        {
         var   _str = "workstation id=testDB1.mssql.somee.com;packet size=4096;user id=hunter22_SQLLogin_1;pwd=of2xuqf4bx;data source=testDB1.mssql.somee.com;persist security info=False;initial catalog=testDB1";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=[testDB1.mssql.somee.com];Database=[testDB1];Trusted_Connection=true";

                try
            {
               
                {
                    conn.Open();
                    var query = "select Id, Name from Users";
                    var cmd = new SqlCommand(query,conn);
                    var dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    var userDetails = dataReader.GetValue(0);

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("{0}\t{1}", dataReader[0],
                            dataReader[1]);
                        }

                        
                    }
                    else
                    {
                        Console.WriteLine("no record founds"); 
                    }
                    dataReader.Close();


                }
            }
            catch (Exception)
            {

                throw;
            }

            //var user = new User { Id = 1111, Name = "Adel" };
            
        }

        //[HttpGet]
        //[Route("newlist")]
        //public ActionResult GetUser1()
        //{
        //    //var user = new User { Id = 1111, Name = "Adel" };
        //    return Ok(users1);
        //}



        //[HttpPost]
        //public ActionResult AddUser(User user)
        //{
        //    //var newUser = new User { Id = 1111, Name = "Adel2" };
        //    return Ok(users1);
        //}
    }
}
