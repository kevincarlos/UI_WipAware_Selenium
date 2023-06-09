using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_WipAware.Elements
{
    class MatterSummary
    {
        private readonly By MatterSummaryWipTotal = By.CssSelector("#smartForm-content > div > div:nth-child(4) > div > span.a-graph-title > span.a-summary-total-value");
        private readonly By MatterSummaryWipLessPrebill = By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(5) > a");
        private readonly By MatterSummaryARtotal = By.CssSelector("#actionGrid > div.k-grid-content.k-auto-scrollable > table > tbody > tr > td:nth-child(8) > span");

        private readonly IWebDriver driver;

        public MatterSummary(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string getMatterSummaryWipTotal()
        {
            return driver.FindElement(MatterSummaryWipTotal).Text;
        }
        public string getMatterSummaryWipLessPrebill()
        {
            return driver.FindElement(MatterSummaryWipLessPrebill).Text;
        }
        public string getMatterSummaryARtotal()
        {
            return driver.FindElement(MatterSummaryARtotal).Text;
        }

    }
}
