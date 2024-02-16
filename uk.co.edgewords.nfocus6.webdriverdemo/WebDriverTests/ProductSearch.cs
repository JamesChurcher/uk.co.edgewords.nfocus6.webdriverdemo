using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uk.co.edgewords.nfocus6.webdriverdemo.Utils;

namespace uk.co.edgewords.nfocus6.webdriverdemo.WebDriverTests
{
    internal class ProductSearch : TestBaseClass
    {
        [Test, Category("Functional")]
        public void SearchItem()
        {

            // Navigate to url
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";

            //Wait for page to load

            // Dismiss popup
            driver.FindElement(By.ClassName("woocommerce-store-notice__dismiss-link")).Click();

            // Find search bar
            var searchBar = driver.FindElement(By.ClassName("search-field"));

            // Type and submit search
            searchBar.Click();
            searchBar.Clear();
            searchBar.SendKeys("cap");
            searchBar.SendKeys(Keys.Enter);

            // Add cap to cart
            Helper.WaitForElDisplayed(driver, By.Name("add-to-cart"));  //Explicit wait for item page to load
            driver.FindElement(By.Name("add-to-cart")).Click();
            Console.WriteLine("Cap added to cart");

            // View cart
            //driver.FindElement(By.CssSelector(".cart-contents")).Click(); //Can sometimes go to cart before cap has been added
            driver.FindElement(By.LinkText("View cart")).Click();   //Only displayed once cap has been added
            Console.WriteLine("Go to cart");

            // Remove from cart
            driver.FindElement(By.ClassName("remove")).Click();
            Console.WriteLine("Cap removed from cart");

            // Explicit wait for item removal to complete
            Helper.WaitForElDisplayed(driver, By.PartialLinkText("Return to shop"));

            // Return to shop
            driver.FindElement(By.PartialLinkText("Return to shop")).Click();

            // View cart
            driver.FindElement(By.CssSelector(".cart-contents")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".cart-empty")).Displayed);

            // Write out test completion status
            Console.WriteLine("Test completed");

            // Take a screenshot on test completion
            string projectPath = @"C:\Users\JamesChurcher\source\repos\uk.co.edgewords.nfocus6.webdriverdemo\uk.co.edgewords.nfocus6.webdriverdemo\";
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile($"{projectPath}screenshots\\screen.png");

            // Attach image to report
            TestContext.AddTestAttachment($"{projectPath}screenshots\\screen.png", "Web page on test completion");

            //Thread.Sleep(5000);
        }
    }
}
