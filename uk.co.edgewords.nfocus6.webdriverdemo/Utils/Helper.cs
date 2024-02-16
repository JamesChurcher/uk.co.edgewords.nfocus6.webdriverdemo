using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocus6.webdriverdemo.Utils
{
    internal static class Helper
    {
        // Explicit wait for element to be displayed
        public static void WaitForElDisplayed(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(locator).Displayed);
        }
    }
}
