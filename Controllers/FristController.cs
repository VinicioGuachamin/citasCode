using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaBackendPry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FristController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public FristController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // GET api/<FristController>/5
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from test";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DevConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        // POST api/<FristController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FristController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FristController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
