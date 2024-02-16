using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
  [TestFixture]
  public class BookingPageTC
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
      public async Task BookHotel()
      {
          string Url = "https://adactinhotelapp.com/";
          await LoginPage.Login(Url, "ImadTester", "ImadTester");
          await SearchPage.SearchHotel("Sydney", "Hotel Creek", "Standard", "1 - One", "2022-10-01", "2022-10-05", "1 - One", "0- None");
          await SelectPage.SelectHotel();
          await BookingPage.BookHotel("Huda", "Aleem", "N.N", "12345678912121214", "321");
      }

      #region DataDriven

      [Test]
      public async Task BookHotel_DataDriven()
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
          string firstName = BasePage.jObject.SelectToken("Login").SelectToken("firstName").Value<string>();
          string lastName = BasePage.jObject.SelectToken("Login").SelectToken("lastName").Value<string>();
          string address = BasePage.jObject.SelectToken("Login").SelectToken("address").Value<string>();
          string CCNo = BasePage.jObject.SelectToken("Login").SelectToken("CCNo").Value<string>();
          string CvvNo = BasePage.jObject.SelectToken("Login").SelectToken("CvvNo").Value<string>();

            #endregion

          await LoginPage.Login(url, user, password);
          await SearchPage.SearchHotel(location, hotel, roomType, roomNo, dateIn, dateOut, adultRoom, childRoom);
          await SelectPage.SelectHotel();
          await BookingPage.BookHotel(firstName,lastName,address,CCNo,CvvNo);
        }
      #endregion
    }
}
