using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IConfiguration _Configuration;

        private readonly SignUpDBContext _context;
        public SignInController(IConfiguration configuration, SignUpDBContext context)
        {
            _Configuration = configuration;
            _context = context;
        }
        
       
        [HttpGet]
        public JsonResult Get()
        {

            var users = _context.Users.ToList();

            return new JsonResult(users);

        }
        [HttpGet("{id}")]
        public JsonResult GetUser(int id)
        {
            var user =  _context.Users.Find(id);

            if (user == null)
            {
                return new JsonResult("User Not Found");
            }
            else
            {
                return new JsonResult(user);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult post(Users user)
        {

            //var tb = _context.Users.ToList();
            var authUser = _context.Users.Where((x) => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            bool found = false;
            //List<string> pNotes = new List<string>();
            //foreach (var a in tb)
            //{
            //    if (user.Email == a.Email && user.Password == a.Password)
            //    {
            //        found = true;
            //    }
            //}
            
            if (authUser == null)
            {
                
                return new JsonResult(found.ToString());

            }
            else
            {
                found = true;
                return new JsonResult(found.ToString());
            }
        }

       
        [HttpPut("{id}")]
        public JsonResult PutUser(int id, Users user)
        {
            user.UserId = id;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return new JsonResult("User Not Found");
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("User saved sucessfully");
        }
        [HttpPut]
        public JsonResult put(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
             _context.SaveChanges();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id}")]
        public JsonResult Delete(int Id)
        {
           
                var user = _context.Users.Find(Id);
                if (user == null)
                {
                    return new JsonResult("User not deleted Successfully");
                }

                _context.Users.Remove(user);
                _context.SaveChangesAsync();

                return new JsonResult("Deleted Successfully");
            
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
