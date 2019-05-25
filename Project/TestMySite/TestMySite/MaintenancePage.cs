using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMySite
{
    class MaintenancePage
    {
        private IWebDriver driver;

        public MaintenancePage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "#ContactLink")]
        private IWebElement contactLink;

        [FindsBy(How = How.CssSelector, Using = "#Drop")]
        private IWebElement dropPages;

        [FindsBy(How = How.CssSelector, Using = "#Name")]
        private IWebElement newsNameField;

        [FindsBy(How = How.CssSelector, Using = "#Mail")]
        private IWebElement newsMailField;

        [FindsBy(How = How.CssSelector, Using = "#SubButton")]
        private IWebElement newsSubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#footer")]
        private IWebElement footer;

        [FindsBy(How = How.CssSelector, Using = "#MainPage")]
        private IWebElement mainPageLink;

        public ContactPage ContactLinkClick()
        {
            
            contactLink.Click();

            return new ContactPage(driver);
        }

        public Boolean MaintenancePageFillNewsForm(string name, string mail)
        {
            bool isSuccess = false;

            newsNameField.SendKeys(name);
            newsMailField.SendKeys(mail);
            footer.Click();

            newsSubmitButton.Click();

            try
            {
                string Alert = driver.SwitchTo().Alert().Text;
                driver.SwitchTo().Alert().Accept();
                isSuccess = true;
                return isSuccess;
            }
            catch (NoAlertPresentException e)
            {
                return isSuccess;
            }
        }

        public MainPage MainPageLinkClick()
        {
            mainPageLink.Click();

            return new MainPage(driver);
        }

    }
}
