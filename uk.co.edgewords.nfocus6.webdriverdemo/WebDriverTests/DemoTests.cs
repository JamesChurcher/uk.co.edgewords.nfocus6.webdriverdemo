using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.nfocus6.webdriverdemo.POMClasses;
using uk.co.edgewords.nfocus6.webdriverdemo.Utils;
using static uk.co.edgewords.nfocus6.webdriverdemo.Utils.StaticHelperLib;

namespace uk.co.edgewords.nfocus6.webdriverdemo.WebDriverTests
{
    internal class DemoTests : BaseTest
    {
        [Test, Category("Demo")]
        public void TraditionalTest()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/";
            driver.FindElement(By.PartialLinkText("Login")).Click();

            driver.FindElement(By.Id("username")).SendKeys("edgewords");
            driver.FindElement(By.Id("password")).SendKeys("edgewords123");
            driver.FindElement(By.LinkText("Submit")).Click();

            StaticWaitForElement(driver, By.LinkText("Log Out"), 3);

            string bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.That(bodyText, Does.Contain("User is Logged in"), "Not logged in");
            Thread.Sleep(2000);
        }

        [Test, Category("Demo")]
        public void POMLogin()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/";
            HomePagePOM home = new(driver);
            home.GoLogin();
            LoginPagePOM login = new(driver);
            //login.setUsername("edgewords");
            //login.setPassword("edgewords123");
            //login.submitForm();

            //login.setUsername("edgewords")
            //     .setPassword("edgewords123")
            //     .submitForm();

            bool loggedIn = login.LoginExpectSuccess("edgewords", "edgewords123");
            Assert.That(loggedIn, "We did not login");
            //NUnit Classic equivalent:
            //Assert.IsTrue();

            Thread.Sleep(2000);
        }
    }
}
