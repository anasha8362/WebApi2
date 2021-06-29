using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class SignUpDBContext:DbContext
    {
        public SignUpDBContext(DbContextOptions<SignUpDBContext>options):base(options)
        {

        }
        public DbSet<Users> Users { get; set; }

      
    }
}
