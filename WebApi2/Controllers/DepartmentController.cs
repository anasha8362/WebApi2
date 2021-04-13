using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration ;
using System.Data.SqlClient;
using System.Data;
using WebApi2.Models;
namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        
    
        public DepartmentController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select DepartmentId, DepartmentName from dbo.Department";
            DataTable table = new DataTable();
            // database connection string
            string sqlDataSource = _Configuration.GetConnectionString("CoustmerAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult post(Department dep)
        {
            string query = @"
                            insert into dbo.Department values
                              ('"+dep.DepartmentName+@"')
                                                          ";
            DataTable table = new DataTable();
            string sqlDataSource = _Configuration.GetConnectionString("CoustmerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult put(Department dep)
        {
            string query = @"
                           update dbo.Department set 
                           DepartmentName = '"+dep.DepartmentName+@"'
                           Where DepartmentId = "+dep.DepartmentId + @"

                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _Configuration.GetConnectionString("CoustmerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id}")]
        public JsonResult Delete(int Id)
        {
            string query = @"
                           Delete from  dbo.Department 
                           Where DepartmentId = " + Id + @"

                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _Configuration.GetConnectionString("CoustmerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
