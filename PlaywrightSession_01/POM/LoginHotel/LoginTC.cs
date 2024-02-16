using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
    [TestFixture]
    public class LoginTC
    {
        [OneTimeSetUp]
        public async Task ClassInit()
        {

        }

        [OneTimeTearDown]
        public async Task ClassCleanUp()
        {

        }

        [SetUp]
        public async Task TestSetup()
        {
            BasePage.ReadJson("data.json");
            await BasePage.Initialize();
        }

        [TearDown]
        public async Task TearDown()
        {
            await BasePage.page.CloseAsync();
        }

        [Test]
        public async Task Login_ValidUserValidPassword()
        {
            await LoginPage.Login("https://adactinhotelapp.com/", "ImadTester", "ImadTester");
        }

        #region DataDriven
        [Test]
        public async Task Login_DataDriven()
        {
            #region Data
            string url = BasePage.jObject.SelectToken("Login").SelectToken("url").Value<string>();
            string user = BasePage.jObject.SelectToken("Login").SelectToken("username").Value<string>();
            string password = BasePage.jObject.SelectToken("Login").SelectToken("password").Value<string>();
            #endregion 

            await LoginPage.Login(url, user, password);
        }
        #endregion
    }
}
