using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_WipAware.Elements
{
    class AdvancedFilter
    {
        public const string NAMEMatterID = "MatterID";
        public const string CSSMatterIdSearchButton = "#a-advanced-filter > div.a-advanced-filter-content > div > div:nth-child(1) > div > div.smartFormFieldContainer.a-itemselector-field > div > div.searchInput.input.a-flex-row > i.control-icon.ui-icon-a-down-arrow.ui-icon-a-search-gray";
        public const string CSSMatterIdPopUpInput = "#search-control-input";
        public const string NAMEClentID = "ClientID";
        public const string NAMEMatterDept = "MatterDept";
        public const string NAMEMatterBillingEmployee = "MatterBillingEmployee";
        public const string NAMEMatterOffice = "MatterOffice";
        public const string NAMEMatterResponsibleEmployee = "MatterResponsibleEmployee";
        public const string XpathSearchButton = "//*[@id=\"a-advanced-filter\"]/div[2]/div/button[4]";
        public const string CSSSearchButton = "#a-advanced-filter > div.a-header.a-advanced-filter-toolbar > div > button.a-button.a-primary.a-search-apply-button";
        public const string ClearButton_CSS = "#a-advanced-filter > div.a-header.a-advanced-filter-toolbar > div > button.a-button.a-secondary.a-search-clear-button";

        private readonly By MatterID = By.Name("MatterID");
        private readonly By MatterIdSearchButton = By.CssSelector("#a-advanced-filter > div.a-advanced-filter-content > div > div:nth-child(1) > div > div.smartFormFieldContainer.a-itemselector-field > div > div.searchInput.input.a-flex-row > i.control-icon.ui-icon-a-down-arrow.ui-icon-a-search-gray");
        private readonly By MatterIdPopUpInput = By.CssSelector("#search-control-input");
        public readonly  By ClientMatterList = By.CssSelector("#search-control-results > li");
        private readonly By ClentID = By.Name("ClientID");
        private readonly By MatterDept = By.Name("MatterDept");
        private readonly By MatterBillingEmployee = By.Name("MatterBillingEmployee");
        private readonly By MatterOffice = By.Name("MatterOffice");
        private readonly By MatterResponsibleEmployee = By.Name("MatterResponsibleEmployee");
        private readonly By SearchButton = By.CssSelector("#a-advanced-filter > div.a-header.a-advanced-filter-toolbar > div > button.a-button.a-primary.a-search-apply-button");
        public readonly By ClientMatterFilterContent = By.CssSelector("#a-advanced-filter > div.a-advanced-filter-content > div > div:nth-child(1) > div > div.a-multiselect-container > div > div.a-multiselect-item-text > div.a-multiselect-item-secondarytext");
        private readonly By ClearButton = By.CssSelector("#a-advanced-filter > div.a-header.a-advanced-filter-toolbar > div > button.a-button.a-secondary.a-search-clear-button");

        private readonly IWebDriver driver;


        public AdvancedFilter(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Waitfor(By by)
        {
            WebDriverExtensions.WaitForElement(driver, by, 180);
        }
        public int getClientMatterList()
        {
            WebDriverExtensions.WaitForElement(driver, ClientMatterList, 180);
            int count = driver.FindElements(ClientMatterList).Count;
            return count;
        }

        public void clickMatterIdSearchButton()
        {
            WebDriverExtensions.WaitForElement(driver, MatterIdSearchButton, 180);
            driver.FindElement(MatterIdSearchButton).Click();
        }

        public void sendKeysMatterIdPopUpInput(string ClientOrMatterName)
        {
            WebDriverExtensions.WaitForElement(driver, MatterIdPopUpInput, 180);
            driver.FindElement(MatterIdPopUpInput).SendKeys(ClientOrMatterName);
        }

        public void clickSearchButton()
        {
            WebDriverExtensions.WaitForElement(driver, SearchButton, 180);
            driver.FindElement(SearchButton).Click();
        }

        public void WaitClientMatterFilterContent()
        {
            WebDriverExtensions.WaitForElement(driver, ClientMatterFilterContent, 180);
        }


    }
}
