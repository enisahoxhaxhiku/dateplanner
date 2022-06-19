using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DatePlanner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DatePlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokacioniController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LokacioniController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Lokacioni";
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DatePlannerCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Lokacioni l)
        {
            string query = @"insert into dbo.Lokacioni values 
                        ('" + l.Aktivitetet + @"','" + l.LlojiLokacionit +  @"')";
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DatePlannerCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }


            }
            return new JsonResult("Shtuar me sukses!");

        }
        [HttpPut]
        public JsonResult Put(Lokacioni l)
        {

            string query = @"update Lokacioni set Aktivitetet = '" + l.Aktivitetet + @"', LlojiLokacionit = '" + l.LlojiLokacionit + @"'where LokacioniID = " + l.LokacioniID + @"";
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DatePlannerCon");

            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }


            }
            return new JsonResult("Ndryshuar me sukses!");
        }

        [HttpDelete("{lID}")]
        public JsonResult Delete(int lID)
        {

            string query = @"delete from Lokacioni where LokacioniID = " + lID + @"";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DatePlannerCon");

            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))

            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();

                    myCon.Close();
                }


            }
            return new JsonResult("Fshire me sukses!");
        }
    }
}