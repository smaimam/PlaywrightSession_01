using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PlaywrightSession_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession
{
    [TestFixture]
    public class SearchTC
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
        public async Task SearchHotel()
        {
            await LoginPage.Login("https://adactinhotelapp.com/", "ImadTester", "ImadTester");
            await SearchPage.SearchHotel("Sydney", "Hotel Creek", "Standard", "1 - One", "2022-10-01", "2022-10-05", "1 - One", "0 - None");
            await Assertions.Expect(BasePage.page.Locator("#select_form table tbody td.login_title")).ToHaveTextAsync("Select Hotel ");
            
        }

        #region DataDriven
        [Test]
        public async Task SearchHotel_DataDriven()
        {
            #region Data
            string url = BasePage.jObject.SelectToken("Login").SelectToken("url").Value<string>();
            string user = BasePage.jObject.SelectToken("Login").SelectToken("username").Value<string>();
            string password = BasePage.jObject.SelectToken("Login").SelectToken("password").Value<string>();
            string location = BasePage.jObject.SelectToken("Login").SelectToken("location").Value<string>();
            string hotel = BasePage.jObject.SelectToken("Login").SelectToken("hotel").Value<string>();
            string roomType = BasePage.jObject.SelectToken("Login").SelectToken("roomType").Value<string>();
            string roomNo = BasePage.jObject.SelectToken("Login").SelectToken("roomNo").Value<string>();
            string dateIn = BasePage.jObject.SelectToken("Login").SelectToken("dateIn").Value<string>();
            string dateOut = BasePage.jObject.SelectToken("Login").SelectToken("dateOut").Value<string>();
            string adultRoom = BasePage.jObject.SelectToken("Login").SelectToken("adultRoom").Value<string>();
            string childRoom = BasePage.jObject.SelectToken("Login").SelectToken("childRoom").Value<string>();
            #endregion

            await LoginPage.Login(url, user, password);
            await SearchPage.SearchHotel(location,hotel,roomType,roomNo,dateIn,dateOut,adultRoom,childRoom);
        }
        #endregion
    }
}
