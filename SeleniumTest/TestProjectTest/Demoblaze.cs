using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebsiteTests
{
    public class DemoBlaze
    {
        private IWebDriver driver;
        String test_url = "https://www.demoblaze.com/index.html";
        private readonly Random _random = new();

        [SetUp]
        public void Start_browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(test_url);
        }

        [Test]
        public void AddToCart_Buy()
        {
            IWebElement loginButton = driver.FindElement(By.Id("login2"));
            loginButton.Click();
            Thread.Sleep(500);

            IWebElement usernameField = driver.FindElement(By.Id("loginusername"));
            usernameField.SendKeys("3");

            IWebElement passwordField = driver.FindElement(By.Id("loginpassword"));
            passwordField.SendKeys("3");

            IWebElement LoginButton = driver.FindElement(By.XPath("//button[text()='Log in']"));
            LoginButton.Click();
            Thread.Sleep(500);

            // POPUP
            try
            {
                IWebElement sButton2 = driver.FindElement(By.XPath("//button[@class='agree-button eu-cookie-compliance-secondary-button']"));
                sButton2.Click();
            }
            catch (NoSuchElementException)
            {
                // does nothing if cookies policy not found
            }   

            IWebElement laptopsCategory = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/a[3]"));
            laptopsCategory.Click();
            Thread.Sleep(500);

            IWebElement productLink = driver.FindElement(By.XPath("//a[normalize-space()='MacBook Pro']"));
            productLink.Click();
            Thread.Sleep(5000);

            IWebElement addToCartButton = driver.FindElement(By.XPath("//a[@class='btn btn-success btn-lg']"));
            addToCartButton.Click();
            Thread.Sleep(500);


            IAlert alert = driver.SwitchTo().Alert();

            alert.Accept();


            IWebElement cartLink = driver.FindElement(By.LinkText("Cart"));
            cartLink.Click();
            Thread.Sleep(500);

            IWebElement placeorder = driver.FindElement(By.XPath("//button[text()='Place Order']"));
            placeorder.Click();
            Thread.Sleep(500);

            driver.FindElement(By.Id("name")).SendKeys("Nimi");
            driver.FindElement(By.Id("country")).SendKeys("Riik");
            driver.FindElement(By.Id("city")).SendKeys("Linn");
            driver.FindElement(By.Id("card")).SendKeys("6593756957");
            driver.FindElement(By.Id("month")).SendKeys("06");
            driver.FindElement(By.Id("year")).SendKeys("2023");

            IWebElement purchase = driver.FindElement(By.XPath("//button[text()='Purchase']"));
            purchase.Click();
            Thread.Sleep(1000);

            Assert.Pass("Product successfully bought");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}