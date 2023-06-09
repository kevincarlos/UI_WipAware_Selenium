using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UI_WipAware.Elements;

namespace UI_WipAware
{
    [TestClass]
    public class UnitTest1
    {
        private const string Url = "http://localhost/Expert_Local/ApplicationServices/WIPAware/";
        private const string WindowTitle = "WIP Aware";
        private const int Timeout = 180;
        private const int PollTime = 1;
        protected static IWebDriver WipAwareDriver;
        protected static IWebElement WebElement;
        protected static WebDriverWait WebdriverWait;
        protected static IList<IWebElement> List;


        public void Setup()
        {
            //ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
            WipAwareDriver = new ChromeDriver();
            WipAwareDriver.Navigate().GoToUrl(Url);
            WipAwareDriver.Manage().Window.Maximize();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(WipAwareDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(Timeout);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(PollTime);
            fluentWait.Until(driver => driver.Title == WindowTitle);

        }

        public void Stop()
        {
            WipAwareDriver.Close();
        }

        public void login()
        {
            // enter login session to be used for the driver.
            // possibly add rights to "Wip Aware User" policy.
        }

        [TestMethod]
        [Description("This will trigger an Advanced Search for Arden Industries in the client.matter field " +
                    "and select General(1) as the matter and compare the results of WipTotal, WipLessPrebill " +
                    "and ARtotal in the Bill Summary")]
        public void AdvanceSearch()
        {
            Setup();
            //check if advance search is clickable (Explicit Wait) then click Advanced Search Button
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector(HeaderButtons.CSSAdvancedSearchButton), Timeout);
            WipAwareDriver.FindElement(By.CssSelector(HeaderButtons.CSSAdvancedSearchButton)).Click();

            //wait if the client.matter element is available then click
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector(AdvancedFilter.CSSMatterIdSearchButton), Timeout);
            WipAwareDriver.FindElement(By.CssSelector(AdvancedFilter.CSSMatterIdSearchButton)).Click();

            //wait for the client.matter popup element is available then type Arden
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector(AdvancedFilter.CSSMatterIdPopUpInput), Timeout);
            WipAwareDriver.FindElement(By.CssSelector(AdvancedFilter.CSSMatterIdPopUpInput)).SendKeys("Arden");

            //wait for the populated client.matter that was typed in
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector("#search-control-results > li:nth-child(2) > div > div"), Timeout);

            //gets the count number of list under the dropdown
            var count = WipAwareDriver.FindElements(By.CssSelector("#search-control-results > li")).Count;

            //implement a search for "General (1)" matter then click if it is "General (1)"
            for (int i = 1; i <= count; i++)
            {
                var isArdenGeneral = WipAwareDriver.FindElement(By.CssSelector("#search-control-results > li:nth-child(" + i + ") > div > div > div.secondary-text")).Text;
                //Console.WriteLine(isArdenGeneral);
                if (isArdenGeneral == "General (1)")
                {
                    WipAwareDriver.FindElement(By.CssSelector("#search-control-results > li:nth-child(" + i + ") > div > div")).Click();
                }
            }
            //wait and assert if the matter selected in Arden General (1)
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector("#a-advanced-filter > div.a-advanced-filter-content > div > div:nth-child(1) > div > div.a-multiselect-container > div > div.a-multiselect-item-text > div.a-multiselect-item-secondarytext"), Timeout);
            string isGeneral = WipAwareDriver.FindElement(By.CssSelector("#a-advanced-filter > div.a-advanced-filter-content > div > div:nth-child(1) > div > div.a-multiselect-container > div > div.a-multiselect-item-text > div.a-multiselect-item-secondarytext"))
                .Text;
            Assert.AreEqual(isGeneral, "General (1)", "Fail");

            //wait and click search button
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.XPath(AdvancedFilter.XpathSearchButton), Timeout);
            WipAwareDriver.FindElement(By.XPath(AdvancedFilter.XpathSearchButton)).Click();

            //wait for the results for Arden General (1) in the grid then get the values on the grid
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector
                ("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(3) > div > div > div.a-row-item-content.a-linear-transition > div > div.a-primary-text > span:nth-child(2)"), Timeout);

            var WipTotal = WipAwareDriver.FindElement(By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(4) > span")).Text;
            var WipLessPrebill = WipAwareDriver.FindElement(By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(5) > a")).Text;
            var ARtotal = WipAwareDriver.FindElement(By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(8) > span")).Text;

            //Click the grid result of search for Arden
            WipAwareDriver.FindElement(By.CssSelector
                ("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(3) > div > div > div.a-row-item-content.a-linear-transition > div > div.a-primary-text > span:nth-child(2)")).Click();

            //wait for the popup window on the side then get the values to compare
            WebDriverExtensions.WaitForElement(WipAwareDriver, By.CssSelector("#smartForm-content > div > div:nth-child(4) > div > span.a-graph-title > span.a-summary-total-value"), Timeout);

            //var SideWindowWipTotal = "test";
            var SideWindowWipTotal = WipAwareDriver.FindElement(By.CssSelector("#smartForm-content > div > div:nth-child(4) > div > span.a-graph-title > span.a-summary-total-value")).Text;
            var SideWindowWipLessPrebill = WipAwareDriver.FindElement(By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(5) > a")).Text;
            var SideWindowARtotal = WipAwareDriver.FindElement(By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(8) > span")).Text;

            //Screenshot
            //WebDriverExtensions.TakeScreenshot(WipAwareDriver);

            //compare values using assertion
            WebDriverExtensions.AssertFailScreenshot(WipAwareDriver, SideWindowWipTotal, WipTotal);
            WebDriverExtensions.AssertFailScreenshot(WipAwareDriver,SideWindowWipLessPrebill, WipLessPrebill);
            WebDriverExtensions.AssertFailScreenshot(WipAwareDriver,SideWindowARtotal, ARtotal);
            //Assert.AreEqual(SideWindowARtotal, ARtotal, "Fail");

            //sleep then close driver
            //Thread.Sleep(3000);
            Stop();
        }
    }
}
