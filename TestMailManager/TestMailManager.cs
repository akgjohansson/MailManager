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
            using (var manager = new MailManager.MailManager("smtp.gmail.com", 587, "gotaelves@gmail.com", "gotaelves@gmail.com", "GotaElvesJ-11"))
            {
                await manager.SendMail(new List<string> { "akgjohan@gmail.com", "launchpad@gotaelves.se" }, "testämne", "testtext");
            }
        }

        [TestMethod]
        public async Task TestSendMailBrollop()
        {
            using (var manager = new MailManager.MailManager("smtp.gmail.com", 587, "ja19maj@gmail.com", "ja19maj@gmail.com", "JA2018-pass"))
            {
                await manager.SendMail(new List<string> { "akgjohan@gmail.com", "launchpad@gotaelves.se" }, "testämne", "testtext");
            }
        }
    }
}
