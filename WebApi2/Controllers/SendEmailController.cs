using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;
using System.Net.Mail;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
      
        [HttpPost]
        public JsonResult post(EmailBody em)
        
        {
            bool foundemail = true;
            string to = em.Email;
            string email = em.Email.ToString();
            int index  = email.IndexOf("@");
            string name = email.Substring(0, index);
            string subject = "Desease Alert";
            string areaName = em.Area;
            string desease = "";
            string body = "Hi "+ name + "! , \n A new desese has stricked in following area: " 
                          + areaName + "\nYour plants may get infected with following desease:"
                          + desease+ "\nKindly take precautions \n for any further queries please contact Us \n regards Plantdeseasedetection Admin!";
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("plantdeseasedetection@gmail.com");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("plantdeseasedetection@gmail.com", "033142fazi");
            smtp.Send(mm);
            return new JsonResult(foundemail.ToString());
        }

    }
}
