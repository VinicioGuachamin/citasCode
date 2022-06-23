using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using pruebaBackendPry.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaBackendPry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public CitaController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // GET: api/<CitaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CitaController>/5
        [HttpGet("{placa}")]
        public JsonResult Get(string placa)
        {
            string query = @"select * from citas where Placa = @placa";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DevConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@placa", placa);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        // POST api/<CitaController>
        [HttpPost]
        public JsonResult Post(string placa, DateTime fecha)
        {
            string query = @"insert into citas (Placa, Fecha, Estado) values (@placa, @fecha, @estado) ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DevConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@placa", placa);
                    myCommand.Parameters.AddWithValue("@fecha", fecha);
                    myCommand.Parameters.AddWithValue("@estado", "PROGRAMADA");

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
