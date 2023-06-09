using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_WipAware.Elements
{
    class AdvancedSearchResults
    {
        private readonly By ClientMatterFirstResult = By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(3) > div > div > div.a-row-item-content.a-linear-transition > div > div.a-primary-text > span:nth-child(2)");
        private readonly By WipTotal = By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(4) > span");
        private readonly By WipLessPrebill = By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(5) > a");
        private readonly By ARtotal = By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(8) > span");


        private readonly IWebDriver driver;

        public AdvancedSearchResults(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickClientMatterFirstResult()
        {
            WebDriverExtensions.WaitForElement(driver, ClientMatterFirstResult, 180);
            driver.FindElement(ClientMatterFirstResult).Click();
        }
        public string getWipTotal()
        {
            return driver.FindElement(WipTotal).Text;
        }
        public string getWipLessPrebill()
        {
            return driver.FindElement(WipLessPrebill).Text;
        }
        public string getARtotal()
        {
            return driver.FindElement(ARtotal).Text;
        }
    }
}
