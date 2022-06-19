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
    public class PerdoruesiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PerdoruesiController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Perdoruesi";
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
        public JsonResult Post(Perdoruesi per)
        {
            string query = @"insert into dbo.Perdoruesi values 
                        ('" + per.PerdoruesiName + @"','" + per.PerdoruesiSurname + @"','" + per.PerdoruesiEmail + @"')";
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DatePlannerCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myCon))
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
        public JsonResult Put(Perdoruesi per)
        {

            string query = @"update Perdoruesi set PerdoruesiName = '" + per.PerdoruesiName + @"', PerdoruesiSurname = '" + per.PerdoruesiSurname + @"',PerdoruesiEmail='" + per.PerdoruesiEmail + @"'where PerdoruesiID = " + per.PerdoruesiID + @"";
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

        [HttpDelete("{perID}")]
        public JsonResult Delete(int perID)
        {

            string query = @"delete from Perdoruesi where PerdoruesiID = " + perID + @"";

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