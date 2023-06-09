using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UI_WipAware
{
    public static class WebDriverExtensions
    {

        //this method checks if the element is displayed and enabled. Replaces  the ExpectedConditions which is deprecated
        public static void WaitForElement(IWebDriver driver, By by, int timeoutInTimeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInTimeout));
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


        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Temp\Download\Image.png",
                ScreenshotImageFormat.Png);
        }
        public static void AssertFailScreenshot(IWebDriver driver, string one, string two)
        {
            bool result = false;
            try
            {
                Assert.AreEqual(one, two, "Fail");
            }
            catch (AssertFailedException)
            {

               
            }

            TakeScreenshot(driver);
        }



    }
}
