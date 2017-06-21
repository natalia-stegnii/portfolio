using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNet.Mvc;
using Portfolio.ASP.Net.Models;
using System.Net.Mail;
using System.Web.Mvc;

namespace Portfolio.ASP.Net.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);
                    msz.To.Add("goloborodko.natasha@gmail.com");// Change this where you want to receice the mail
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;
                    //Email address using which mail will send
                    smtp.Credentials = new System.Net.NetworkCredential("youremailid@gmail.com", "password");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting me ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Soory we are facing Problem here {ex.Message}";
                }

            }


            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}