using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace SeleniumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Found driver at https://sites.google.com/a/chromium.org/chromedriver/downloads
            using (IWebDriver driver = new ChromeDriver(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName))
            {
                driver.Navigate().GoToUrl("http://www.google.com/");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("Cheese");
                query.Submit();
                // Fails with WebDriver 3.2, using 2.27
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Page title is: " + driver.Title);

            }
        }
    }
}
