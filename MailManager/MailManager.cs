using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailManager
{
    public class MailManager : IDisposable
    {
        public SmtpClient Client { get; set; }
        public string Sender { get; set; }

        public MailManager(string host, int port, string sender, string username, string password)
        {
            Client = new SmtpClient(host, port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
            Sender = sender;
        }

        public MailManager(string host, string sender, string password)
        {
            Client = new SmtpClient(host)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true
            };
            Sender = sender;
        }


        public void SendMail(IEnumerable<string> recipiants, string subject, string text)
        {
            foreach (var recipiant in recipiants)
            {
                MailAddress from = new MailAddress(Sender);
                MailAddress to = new MailAddress(recipiant);
                using (MailMessage message = new MailMessage(from, to)
                {
                    Body = text,
                    Subject = subject,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8
                })
                {
                    Client.Send(message);
                    //await Client.SendMailAsync(message);
                }
            }
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
