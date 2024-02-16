using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
    public class LoginPage : BasePage
    {
        #region LoginPage Locators
        public static string userNameTxt = "#username";
        public static string passwordTxt = "#password";
        public static string loginBtn = "#login";
        #endregion

        public static async Task Login( string url, string username, string pass)
        {
            await page.GotoAsync(url);
            await page.FillAsync(userNameTxt, username);
            await page.Locator(userNameTxt).FillAsync(username);

            await page.FillAsync(passwordTxt, pass);
            await page.ClickAsync(loginBtn);
        }
    }
}
