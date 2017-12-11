using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestMailManager
{
    [TestClass]
    public class TestMailManager
    {
        [TestMethod]
        public async Task TestSendMailWithGmail()
        {
            using (var manager = new MailManager.MailManager("smtp.gmail.com", 587, "johansson.mcquack@gmail.com", "johansson.mcquack@gmail.com", "naut2Azon-65jm"))
            {
                await manager.SendMail(new List<string> { "akgjohan@gmail.com" }, "testsubject", "test text");
            }
        }

        [TestMethod]
        public async Task TestSendMailGotaElves()
        {
            using (var manager = new MailManager.MailManager("mail.gotaelves.se", "postmaster@gotaelves.se", "GotaElvesJ-11"))
            {
                await manager.SendMail(new List<string> { "akgjohan@gmail.com", "launchpad@gotaelves.se" }, "testämne", "testtext");
            }
        }
    }
}
