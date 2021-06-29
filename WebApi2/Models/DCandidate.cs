using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApi2.Models
{
    public class DCandidate
    {   [Key]
        public int DCandidateId { get; set; }

      //  [Required(ErrorMessage = "Please Enter User Name ")]
        [Column(TypeName="nvarchar(100)")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Please Enter Email ")]
       // [DataType(DataType.EmailAddress)]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

       // [Required(ErrorMessage = "Please Enter Password ")]
       // [DataType(DataType.Password)]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please Enter Confrim Password ")]
        //[DataType(DataType.Password)]
        [Column(TypeName = "nvarchar(100)")]
       // [Compare("Password")]
        public string ConfrimPassword { get; set; }
     
        //[Required(ErrorMessage = "Please Enter Address ")]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
    }
}
