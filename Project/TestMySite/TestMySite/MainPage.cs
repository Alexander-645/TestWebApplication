using NUnit.Framework;
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
    class MainPage
    {
        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
            this.driver = driver;

            

        }

        [FindsBy(How = How.CssSelector, Using = "#Services")]
        private IWebElement servicesButton;

        [FindsBy(How = How.CssSelector, Using = "#Drop")]
        private IWebElement dropPages;

        [FindsBy(How = How.CssSelector, Using = "#ServicesTextLink")]
        private IWebElement servicesTextLink;

        [FindsBy(How = How.CssSelector, Using = "#ServicesTextLink2")]
        private IWebElement servicesTextLinkTwo;

        [FindsBy(How = How.CssSelector, Using = "#Maintenance")]
        private IWebElement maintenanceButton;

        [FindsBy(How = How.CssSelector, Using = "#ContactUs")]
        private IWebElement contactButton;

        [FindsBy(How = How.CssSelector, Using = "#pageintro")]
        private IWebElement pageIntro;

        [FindsBy(How = How.CssSelector, Using = "#Name")]
        private IWebElement newsNameField;

        [FindsBy(How = How.CssSelector, Using = "#Mail")]
        private IWebElement newsMailField;

        [FindsBy(How = How.CssSelector, Using = "#SubButton")]
        private IWebElement newsSubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#footer")]
        private IWebElement footer;

        [FindsBy(How = How.CssSelector, Using = "#MaintenanceTextLink")]
        private IWebElement maintenanceTextlink;



        public MainPage ServicesPageLink()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(dropPages).Perform();
            Thread.Sleep(300);
            servicesButton.Click();

            return new MainPage(driver);
        }

        public MainPage MaintenancePageLink()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(dropPages).Perform();
            Thread.Sleep(300);
            maintenanceButton.Click();

            return new MainPage(driver);
        }

        public MainPage ContactPageLink()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(dropPages).Perform();
            Thread.Sleep(300);
            contactButton.Click();

            return new MainPage(driver);
        }

        public MainPage ServicesPageTextLink()
        {
            servicesTextLink.Click();

            return new MainPage(driver);
        }

        public Boolean MainPageOpen()
        {
            return pageIntro.Displayed;
        }

        public MainPage ServicesTextLinkTwo()
        {
            servicesTextLink.Click();

            return new MainPage(driver);
        }

        public Boolean MainPageFillNewsForm(string name, string mail)
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

        public MaintenancePage MaintenaceTextLinkClick()
        {
            maintenanceTextlink.Click();

            return new MaintenancePage(driver);
        }

    }
}

