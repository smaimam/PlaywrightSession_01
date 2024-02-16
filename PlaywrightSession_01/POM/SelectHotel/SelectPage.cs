using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
    public class SelectPage : BasePage
    {
        #region SelectPage Locators
        public static string continueBtn = "#continue";
        public static string radBtn = "#radiobutton_1";
        #endregion
        public static async Task SelectHotel()
        {
            await page.GetByRole(AriaRole.Radio).First.ClickAsync();
            await page.ClickAsync(continueBtn);
        }
    }
}
