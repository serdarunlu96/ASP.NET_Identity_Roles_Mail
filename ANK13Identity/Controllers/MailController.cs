using ANK13Identity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace ANK13Identity.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Index(Mail mail)
        {
            // wejcbqsymjlvtlxa
            // bu gelen maili gonder!

            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                mailMessage.From = new MailAddress("silviatiger841@gmail.com");
                mailMessage.To.Add("silviatiger841@gmail.com");

                mailMessage.Subject = mail.Subject;
                mailMessage.Body = mail.Body;

                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";

                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("silviatiger841@gmail.com", "wejcbqsymjlvtlxa");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
    }
}
