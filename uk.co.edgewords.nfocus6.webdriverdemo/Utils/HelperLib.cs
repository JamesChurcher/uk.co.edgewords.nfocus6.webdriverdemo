using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocus6.webdriverdemo.Utils
{
    internal class HelperLib
    {
        private IWebDriver _driver;

        public HelperLib(IWebDriver driver) //Get the driver from the calling test
        {
            this._driver = driver;  //Put it in to thiss class field
        }
        public void WaitForElement(By locator, int timeoutInSeconds = 3)    //A helper method using webdriver field
        {
            WebDriverWait myWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            myWait.Until(drv => drv.FindElement(locator).Enabled);
        }
        //More helper methods to be added when needed
    }
}
