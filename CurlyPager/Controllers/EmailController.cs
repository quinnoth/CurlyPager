using System;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using System.Configuration;
using log4net;

namespace CurlyPager.Controllers
{
    public class EmailController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EmailController));

        public void Get(string subject, string body)
        {
            log.Info("GET Received, Subject: " + subject + ", Body: " + body);
            //send the email
            SendEmail(subject, body);
        }

        public void Post(string subject, string body)
        {
            log.Info("POST Received, Subject: " + subject + ", Body: " + body);
            //send the email
            SendEmail(subject, body);
        }

        public void SendEmail(string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    //Configure the SMTP Connection
                    smtpClient.Host = ConfigurationManager.AppSettings["SMTP_Host"];
                    smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]);
                    smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTP_EnableSsl"]);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTP_Username"], ConfigurationManager.AppSettings["SMTP_Password"]);

                    // Send the Email
                    var mailMessage = new MailMessage(
                        new MailAddress(ConfigurationManager.AppSettings["SMTP_From"], "Internal Alerts"),
                        new MailAddress(ConfigurationManager.AppSettings["SMTP_To"], "Internal Alerts"));
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
