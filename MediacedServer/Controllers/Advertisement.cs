using MediacedServer.Model;
using MediacedServer.Prefs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace MediacedServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        [HttpGet]
        public string GetList()
        {
            Database db = new Database();
            List<Advertisement> advs = new List<Advertisement>();

            SqlConnection conn = new SqlConnection(db.connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Mediaced].[dbo].[advertisements]", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Advertisement adv = new Advertisement(
                        (int)reader["id"], 
                        (string)reader["name"], 
                        (string)reader["phonenumber"], 
                        (string)reader["email"], 
                        Convert.ToSingle(reader["salaryusd"]),
                        Convert.ToSingle(reader["courseusd"]),
                        Convert.ToSingle(reader["salarybyn"]));

                    advs.Add(adv);
                }
            }


            conn.Close();

            string output = JsonConvert.SerializeObject(advs, Formatting.None);

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return output;
        }

        [HttpPost]
        public StatusCodeResult addAdvertisement([FromForm] Advertisement advertisement)
        {
            // HttpContext.Response.Headers.Add("Content-Type", "application/json");

            Database db = new Database();
            SqlConnection conn = new SqlConnection(db.connectionString);
            conn.Open();

            String sqlQuery = $@"INSERT INTO [Mediaced].[dbo].[advertisements]
           ([id]
           ,[name]
           ,[phonenumber]
           ,[email]
           ,[salaryusd]
           ,[courseusd]
           ,[salarybyn]
           
     VALUES
           ({advertisement.id}
           ,'{advertisement.name}'
           ,'{advertisement.phoneNumber}'
           ,'{advertisement.email}'
          
           ,{advertisement.salaryusd.ToString().Replace(",", ".")}
           ,{advertisement.courseOfUSD.ToString().Replace(",", ".")}
           ,{advertisement.salarybyn.ToString().Replace(",", ".")}')";
           

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            try
            {
                command.ExecuteNonQuery();
                return StatusCode(200);

            }
            catch
            {
                return StatusCode(500);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
