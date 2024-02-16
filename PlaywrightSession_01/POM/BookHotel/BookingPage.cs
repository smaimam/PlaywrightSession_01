using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
    public class BookingPage : BasePage
    {
        #region BookHotelPage Locators
        public static string fnameTxt = "#first_name";
        public static string lnameTxt = "#last_name";
        public static string addressTxt = "#address";
        public static string cCNoTxt = "#cc_num";
        public static string cCTypeDropDown = "#cc_type";
        public static string expiryDateDropDown = "#cc_exp_month";
        public static string expiryYearDropDown = "#cc_exp_year";
        public static string cVVNoTxt = "#cc_cvv";
        public static string bookNowBtn = "#book_now";
        public static string cancelBtn = "#cancel";
        public static string orderNoTxt = "#order_no";
        #endregion BookHotelPage Locators

        public static async Task BookHotel(string Firstname, string Lastname, string address, string CCNo, string CvvNo)
        {
            await page.FillAsync(fnameTxt, Firstname);
            await page.FillAsync(lnameTxt, Lastname);
            await page.FillAsync(addressTxt, address);
            await page.FillAsync(cCNoTxt, CCNo);
            await page.TypeAsync(cCTypeDropDown,"VISA");
            await page.TypeAsync(expiryDateDropDown,"June");
            await page.TypeAsync(expiryYearDropDown,"2022");
            await page.FillAsync(cVVNoTxt, CvvNo);
            await page.ClickAsync(bookNowBtn);
        }
    }
}
