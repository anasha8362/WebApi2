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
//namespace WebApi2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DCandidateController : ControllerBase
//    {
//        private readonly SignUpDBContext _context;

//        public object ViewBag { get; private set; }

//        public DCandidateController(SignUpDBContext context)
//        {
//            _context = context;
//        }

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        private readonly IConfiguration _context;
       

        public DCandidateController(IConfiguration context)
        {
            _context = context;
            
        }


        [HttpGet]
        public JsonResult Get()

        {
            string query = @"
                            select  DCandidateId,UserName,Email,Password,ConfrimPassword,Address,
                          from dbo.Dcandidate
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _context.GetConnectionString("DcandidateAppCon");
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
        public JsonResult Post(DCandidate cous)
        {
            string query = @"
                            insert into dbo.Dcandidate 
                           (DCandidateId,UserName,Email,Password,ConfrimPassword,Address)
                            values
                            (
                            '" + cous.DCandidateId + @"'
                            ,'" + cous.UserName + @"'
                            ,'" + cous.Email + @"'
                            ,'" + cous.Password + @"'
                            ,'" + cous.ConfrimPassword + @"'
                            ,'" + cous.Address + @"'
                            )
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _context.GetConnectionString("DcandisateAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using SqlCommand myCommand = new SqlCommand(query, myCon);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader); ;

                myReader.Close();
                myCon.Close();
            }
            return new JsonResult("Added Successfully");
}
    }
}









//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApi2.Models;
//using System.IO;
//using Microsoft.Extensions.Configuration;
//namespace WebApi2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DCandidateController : ControllerBase
//    {
//        private readonly SignUpDBContext _context;

//        public object ViewBag { get; private set; }

//        public DCandidateController(SignUpDBContext context)
//        {
//            _context = context;
//        }

        // GET: api/Dcandidate
        //uncoment from here
        //        [HttpGet]
        //        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDcandidates()
        //        {
        //            return await _context.Dcandidates.ToListAsync();
        //        }


//        // GET: api/Dcandidate/5
//        //uncoment from here

//        [HttpGet("{id}")]
//        public async Task<ActionResult<DCandidate>> GetDcandidate(int id)
//        {
//            var dcandidate = await _context.Dcandidates.FindAsync(id);

//            if (dcandidate == null)
//            {
//                return NotFound();
//            }

//            return dcandidate;
//        }

//        // PUT: api/Dcandidate/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        //uncoment from here
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutDcandidate(int id, DCandidate dcandidate)
//        {
//            dcandidate.DCandidateId = id;

//            _context.Entry(dcandidate).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!DcandidateExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Dcandidate
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        //uncoment from here
//        [HttpPost]
//        public JsonResult Post(DCandidate cous)
//        {
//            string query = @"
//                            insert into dbo.Dcandidate 
//                            (DCandidateId,UserName,Email,Password,ConfrimPassword,Address)
//                            values
//                            (
//                            '" + cous.DCandidateId + @"'
//                            ,'" + cous.UserName + @"'
//                            ,'" + cous.Email + @"'
//                            ,'" + cous.Password + @"'
//                            ,'" + cous.ConfrimPassword + @"'
//                            ,'" + cous.Address + @"'

//                            )
//                            ";

//            string sqlDataSource = _context.GetConnectionString("SignUpDB");
//            SqlDataReader myReader;
//            using (SqlConnection myCon = new SqlConnection())
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myReader = myCommand.ExecuteReader();


//                    myReader.Close();
//                    myCon.Close();
//                }
//            }
//            return new JsonResult("Added Successfully");
//        }




//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<ActionResult<DCandidate>> PostDcandidate(DCandidate dcandidate)
//        //{
//        //    _ = _context.Dcandidates.Add(dcandidate);
//        //    await _context.SaveChangesAsync();
//        //    ViewBag = "the user" + dcandidate.UserName + "is saved successfully ";// pop up json response that recorde is updated successfully it is not working because it is not allowing to add .message

//        //    return CreatedAtAction("GetDcandidate", new { id = dcandidate.DCandidateId }, dcandidate);
//        //}

//        // DELETE: api/Dcandidate/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteDcandidate(int id)
//        {
//            var dcandidate = await _context.Dcandidates.FindAsync(id);
//            if (dcandidate == null)
//            {
//                return NotFound();
//            }

//            _context.Dcandidates.Remove(dcandidate);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool DcandidateExists(int id)
//        {
//            return _context.Dcandidates.Any(e => e.DCandidateId == id);
//        }
//    }
//}
