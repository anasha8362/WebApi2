using Microsoft.AspNetCore.Http;//
using Microsoft.AspNetCore.Mvc;//
using System;//
using System.Collections.Generic;//
using System.Linq;//
using System.Threading.Tasks;//
using Microsoft.Extensions.Configuration;//
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;//
using System.Data;//
using WebApi2.Models;//
using System.IO;//

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoustmerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public CoustmerController(IConfiguration configuration , IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

       
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select CoustmerId, CoustmerName,Department,
                            Convert (varchar(10),DateOfJoining,120) as DateOfJoining
                            ,PhotoFileName
                             from dbo.Coustmer
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoustmerAppCon");
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

            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Coustmer cous)
        {
            string query = @"
                            insert into dbo.Coustmer 
                            (CoustmerName,Department,DateOfJoining,PhotoFileName)
                            values
                            (
                            '" + cous.CoustmerName + @"'
                            ,'" + cous.Department + @"'
                            ,'" + cous.DateOfJioning + @"'
                            ,'" + cous.PhotoFileName + @"'
                            )
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoustmerAppCon");
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
        public JsonResult put(Coustmer cous)
        {
            string query = @"
                           update dbo.Coustmer set 
                           CoustmerName = '" + cous.CoustmerName + @"'
                           ,Department = '" + cous.Department + @"'
                           ,DateOfJoining = '" + cous.DateOfJioning + @"'
                            
                           Where CoustmerId = " + cous.CoustmerId + @"

                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoustmerAppCon");
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
                           Delete from  dbo.Coustmer
                           Where CoustmerId = " + Id + @"

                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoustmerAppCon");
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
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var HttpRequest = Request.Form;
                var postedFile = HttpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);

            }
            catch (Exception)
            {
                return new JsonResult("edit-pic.jpg");
            }
        }

        [Route("GetAllDepartmentNames")]
        public JsonResult GetAllDepartmentNames()
        {
            string query = @"
                            select DepartmentName from dbo.Department
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoustmerAppCon");
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

            return new JsonResult(table);
        }

    }
}
