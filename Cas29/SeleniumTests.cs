using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cas29
{
    class SeleniumTests
    {

        IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }

        [Test]
        public void TestGoogleSearch()
        {
            By Selector;

            Navigate("https://www.google.com/");

            Sleep(2000);

            Selector = By.Name("qqqq");
            IWebElement SearchField = FindElement(Selector);
            SearchField.SendKeys("Selenium automation with C#");

            Sleep(500);

            Selector = By.XPath("//input[@name='btnK']");
            IWebElement SearchButton = FindElement(Selector);
            SearchButton.Click();

            Sleep(2000);

            Selector = By.PartialLinkText("to English");
            IWebElement ChangeToEnglishLink = FindElement(Selector);
            ChangeToEnglishLink.Click();

            Sleep(2000);

            Selector = By.TagName("body");
            IWebElement Body = FindElement(Selector);
            if (Body.Text.Contains("Videos"))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail("Test failed - No videos present.");
            }
        }

        private IWebElement FindElement(By Selector)
        {
            IWebElement ReturnElement = null;

            try
            {
                ReturnElement = Driver.FindElement(Selector);
            } catch (NoSuchElementException)
            {
                Assert.Fail("Test failed - Element not found [{0}].", Selector.ToString());
            } catch (Exception Ex)
            {
                throw Ex;
            }

            return ReturnElement;
        }

        private void Navigate(string Url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);
        }

        private void Sleep(int Miliseconds)
        {
            System.Threading.Thread.Sleep(Miliseconds);
        }

    }
}
