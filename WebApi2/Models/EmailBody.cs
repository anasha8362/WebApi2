
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class EmailBody
    {
        public string Email { get; set; }
        public string Area { get; set; }
    }
}