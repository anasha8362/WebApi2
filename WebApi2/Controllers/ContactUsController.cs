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
    public class ContactUsController : ControllerBase
    {
        [HttpPost]
        public JsonResult post(ContactUsBody con)

        {
            bool foundemail = true;
            string to = "plantdeseasedetection@gmail.com";
            //string email = "plantdeseasedetection@gmail.com";
            string userEmail = con.Email;
           // int index  = email.IndexOf("@");
            string name = con.UserName;
            string subject = "Customer Contact Request";
            string message = con.Message;
           // string desease = "";
            string body = "Hi Admin, \n You have a contact request. Details are as follows: \n User Name: "
                          + name + "\n Email: " + userEmail + "\n Message: " + message + "\n\n Kindly Look into it and respond accordingly \n\n This is an auto generated Email!";  
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

            ///Email for User
            string toEmail = con.Email;
            string email = con.Email.ToString();
            int index = email.IndexOf("@");
            string nameUser = email.Substring(0, index);
            string subjectUser = "Contact Request!";
            string bodyUser = "Hi " + nameUser + "! ,\nThis is an auto generated Email. \n We have recived a contact request here at Plant Desease Detection center! \n Our representative will contact You soon at this email. \n\n For any further queries please contact Us again \n regards Plantdeseasedetection Admin!";
            MailMessage mmUser = new MailMessage();
            mmUser.To.Add(toEmail);
            mmUser.Subject = subjectUser;
            mmUser.Body = bodyUser;
            mmUser.From = new MailAddress("plantdeseasedetection@gmail.com");
            mmUser.IsBodyHtml = false;
            SmtpClient smtpUser = new SmtpClient("smtp.gmail.com");
            smtpUser.Port = 587;
            smtpUser.UseDefaultCredentials = true;
            smtpUser.EnableSsl = true;
            smtpUser.Credentials = new System.Net.NetworkCredential("plantdeseasedetection@gmail.com", "033142fazi");
            smtpUser.Send(mmUser);


            return new JsonResult(foundemail.ToString());
        }
    }
}
