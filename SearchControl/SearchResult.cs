using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_WipAware.Results


{
    class SearchResult
    {
        public readonly By primaryText = By.CssSelector("#search-control-results > li > div > div > div.search-result-text");
        public readonly By secondayText = By.CssSelector("#search-control-results > li > div > div > div.secondary-text");
        public readonly By tertiaryText = By.CssSelector("#search-control-results > li > div > div > div.tertiary-text");

        private readonly IWebDriver driver;
        private IList<IWebElement> list;


        public SearchResult(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FindAndClick(By by,String text)
        {
            list = driver.FindElements(by);
            foreach (IWebElement e in list)
            {
                if (e.Text == text)
                {
                    e.Click();
                }
            }
        }
    }
}
