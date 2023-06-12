using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UI_WipAware.Elements;
using UI_WipAware.Results;

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

        [TestInitialize]
        public void initialize()
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

        //[TestCleanup]
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
        [Description("Testing POM")]

        public void AdvancedSearch()
        {
            HeaderButtons headerButtons = new HeaderButtons(WipAwareDriver);
            AdvancedFilter advancedFilter = new AdvancedFilter(WipAwareDriver);
            AdvancedSearchResults advancedSearchResults = new AdvancedSearchResults(WipAwareDriver);
            MatterSummary matterSummary = new MatterSummary(WipAwareDriver);
            SearchResult searchResult = new SearchResult(WipAwareDriver);
            

            headerButtons.clickAdvancedSearchButton();
            advancedFilter.clickMatterIdSearchButton();
            advancedFilter.sendKeysMatterIdPopUpInput("Arden"); //DDT / hardcode later
            searchResult.FindAndClick(searchResult.secondayText,"General (1)");
            advancedFilter.Waitfor(advancedFilter.ClientMatterFilterContent);
            advancedFilter.clickSearchButton();
            advancedSearchResults.clickClientMatterFirstResult();
            //implement Assert
            Stop();
            
        }
        
      
    }
}
