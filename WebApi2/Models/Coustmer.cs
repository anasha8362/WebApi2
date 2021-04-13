using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class Coustmer
    {
        public int CoustmerId { get; set; }

        public string CoustmerName { get; set; }

        public string DateOfJioning { get; set; }
     
        public string PhotoFileName { get; set; }

        public string Department { get; set; }
    }
}
