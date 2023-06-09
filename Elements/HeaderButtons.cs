using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_WipAware.Elements
{
    public class HeaderButtons
    {
        public const string CSSAdvancedSearchButton = "#page-header > div.smb-header-buttons > span.a-icon-search-plus";
        public const string CSSQuickSearchButton = "#page-header > div.smb-header-buttons > span.a-icon-search";
        public const string CSSSavedSearchButton = "#page-header > div.smb-header-buttons > span.a-icon-saved-search";

        private readonly IWebDriver driver;
        private readonly By AdvancedSearchButton = By.CssSelector("#page-header > div.smb-header-buttons > span.a-icon-search-plus");
        private readonly By QuickSearchButton = By.CssSelector("#page-header > div.smb-header-buttons > span.a-icon-search");
        private readonly By SavedSearchButton = By.CssSelector("#page-header > div.smb-header-buttons > span.a-icon-saved-search");


        public HeaderButtons(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickAdvancedSearchButton()
        {

            WebDriverExtensions.WaitForElement(driver, AdvancedSearchButton, 180);
            driver.FindElement(AdvancedSearchButton).Click();
        }

        public void clickQuickSearchButton()
        {

            WebDriverExtensions.WaitForElement(driver, QuickSearchButton, 180);
            driver.FindElement(QuickSearchButton).Click();
        }

        public void clickSavedSearchButton()
        {

            WebDriverExtensions.WaitForElement(driver, SavedSearchButton, 180);
            driver.FindElement(SavedSearchButton).Click();
        }
    }
}
