using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace UI_WipAware
{
    public static class WebDriverExtensions
    {
        private static WebDriverWait Wait;
        public static void WaitForElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(condition =>
            {
                try
                {
                    var e = driver.FindElement(by);
                    return e.Displayed && e.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementClickInterceptedException)
                {
                    return false;
                }
            });


        }

        //public static void IsEnabled(IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

        //    //create the condition about search button being enabled
        //    Func<IWebDriver, bool> isEnabled =
        //          d =>
        //          {
        //              IWebElement e = d.FindElement(by);
        //              return e.Displayed && e.Enabled;
        //          };
            
        //    //wait until the search button is displayed and enabled
        //    Wait.Until(isEnabled);
            
        //}


    }
}
