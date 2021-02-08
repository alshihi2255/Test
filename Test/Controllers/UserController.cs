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

        public UserController()
        {

        }

        [HttpGet]
        public ActionResult GetUser()
        {
            var users = new List<User>();
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = "workstation id=testDB1.mssql.somee.com;packet size=4096;user id=hunter22_SQLLogin_1;pwd=of2xuqf4bx;data source=testDB1.mssql.somee.com;persist security info=False;initial catalog=testDB1";
                try
                {
                    {
                        conn.Open();
                        var query = "select Id, Name from Users";

                        var cmd = new SqlCommand(query, conn);

                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var current_user = new User()
                                {

                                    Id = Convert.ToInt32(dr["Id"]),

                                    Name = dr["Name"].ToString(),

                                };
                                users.Add(current_user);
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(users);
            }


        }

        [HttpPost]

        public ActionResult AddUser(User user)
        {

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = "workstation id=testDB1.mssql.somee.com;packet size=4096;user id=hunter22_SQLLogin_1;pwd=of2xuqf4bx;data source=testDB1.mssql.somee.com;persist security info=False;initial catalog=testDB1";
                try
                {


                    conn.Open();
                    var query = "insert into Users ( Id, Name) values (@_id, @_name)";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("_id", user.Id);
                    cmd.Parameters.AddWithValue("_name", user.Name);
                    var rows = cmd.ExecuteNonQuery();

                    if(rows > 0 ) return Ok();

                    return Conflict();

                }
                catch (Exception)
                {
                    throw;
                }
                
            }



        }
    }

}

