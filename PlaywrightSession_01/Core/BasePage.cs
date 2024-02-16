using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSession_01
{
    public class BasePage
    {
        public static IFrameLocator frameLocator { get; set; }
        public static IPage page { get; set; }
        public static IFrame Frame { get; set; }
        public static IBrowser Browser { get; set; }
        public static IBrowserContext Context { get; set; }
        public static JObject jObject;

        public static async Task Initialize()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { Headless = false, SlowMo = 50, Timeout = 120000, });
            Context = await Browser.NewContextAsync();
            page = await Browser.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);
        }
        public static void ReadJson(string filename)
        {
            string myJsonString = File.ReadAllText(filename);
            jObject = JObject.Parse(myJsonString);
           
        }
    }
}
