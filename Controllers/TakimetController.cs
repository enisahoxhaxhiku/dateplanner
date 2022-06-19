using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DatePlanner.Models;

namespace DatePlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakimetController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TakimetController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]

        public JsonResult Get()
        {

            string query = @"select TakimetID,LlojiTakimit , DataTakimit from Takimet";
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
        public JsonResult Post(Takimet t)
        {
            string query = @"insert into dbo.Takimet values 
                        ('" + t.LlojiTakimit + @"','" + t.DataTakimit  + @"')";
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
        public JsonResult Put(Takimet t)
        {

            string query = @"update Takimet set LlojiTakimit = '" + t.LlojiTakimit + @"', DataTakimit = '" + t.DataTakimit +  @"'where TakimetID = " + t.TakimetID + @"";
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
        [HttpDelete("{tID}")]
        public JsonResult Delete(int tID)
        {

            string query = @"delete from Takimet where TakimetID = " + tID + @"";

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
