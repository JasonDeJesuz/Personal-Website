using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Website_ASPNET.ViewModels;
using System.IO;
using Newtonsoft;
using System.Web;
using Microsoft.AspNetCore.Diagnostics;

namespace Personal_Website_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> email (IFormCollection form)
        {
            var name = form["name"];
            var email = form["email"];
            var subject = form["subject"];
            var messages = form["message"];
            var x = await SendEmail(name,email,subject, messages);
            if (x == "sent")
                ViewData["esent"]= "Your Message Has Been Sent";
                ViewBag.UserMessage = "Your Message Has Been Sent";
            return RedirectToAction("Sent");
        }
        private async Task<string> SendEmail(string name, string email, string subject, string messages)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("")); // receiver's email id
            message.From = new MailAddress("");  // sender's email id
            message.Subject = subject;
            message.Body = "Name: " + name + "\nFrom: " + email + "\n" + messages;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = ",  // sender's email id
                    Password = ""  // password
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return "sent";
            }
        }

        public IActionResult Software()
        {
            /* Retrieving the details from Github */
            string uri = "";   /* User profile on github i.e. https://api.github.com/users/{USER}/repos */
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(uri));

            WebReq.Method = "GET";
            WebReq.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            jsonString = reader.ReadToEnd();
            }

            List<GithubViewModel> githubdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GithubViewModel>>(jsonString);

            return View(githubdata);
        }

        public IActionResult Sent()
        {
            return View();
        }

        public IActionResult Gear()
        {
            return View();
        }

        public IActionResult Error()
        {
            var pathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // Exception exception = pathFeature?.Error; // Here will be the exception details.

            return View();
        }
    }
}