using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
    public class SearchPage : BasePage
    {
        #region SearchPage Locators
        public static string locationTxt = "#location";
        public static string hotelsTxt = "#hotels";
        public static string roomTypeTxt = "#room_type";
        public static string roomNosTxt = "#room_nos";
        public static string datePickInTxt = "#datepick_in";
        public static string datePickOutTxt = "#datepick_out";
        public static string adultRoomTxt = "#adult_room";
        public static string childRoomTxt = "#child_room";
        public static string searchBtn = "#Submit";
        #endregion

        public static async Task SearchHotel(string Location, string Hotel, string RoomType, string RoomNo, string DateIn, string DateOut, string AdultRoom, string ChildRoom)
        {
            await page.SelectOptionAsync(locationTxt, Location);
            await page.SelectOptionAsync(hotelsTxt, Hotel);
            await page.SelectOptionAsync(roomTypeTxt, RoomType);
            await page.SelectOptionAsync(roomNosTxt, RoomNo);
            await page.FillAsync(datePickInTxt, DateIn);
            await page.FillAsync(datePickOutTxt, DateOut);
            await page.SelectOptionAsync(adultRoomTxt, AdultRoom);
            await page.SelectOptionAsync(childRoomTxt, ChildRoom);
            await page.ClickAsync(searchBtn);
        }
    }
}
