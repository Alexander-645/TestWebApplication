using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMySite
{
    class ServicesPage
    {
        private IWebDriver driver;

        public ServicesPage(IWebDriver driver)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
            this.driver = driver;
          
        }

        [FindsBy(How = How.CssSelector, Using = "#name")]
        private IWebElement nameField;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement mailField;
        
        [FindsBy(How = How.CssSelector, Using = "#phone")]
        private IWebElement phoneField;

        [FindsBy(How = How.CssSelector, Using = "#checkbox1")]
        private IWebElement serviceCheck1;

        [FindsBy(How = How.CssSelector, Using = "#checkbox2")]
        private IWebElement serviceCheck2;

        [FindsBy(How = How.CssSelector, Using = "#checkbox3")]
        private IWebElement serviceCheck3;

        [FindsBy(How = How.CssSelector, Using = "#Date")]
        private IWebElement dateField;

        [FindsBy(How = How.CssSelector, Using = "#Submit")]
        private IWebElement submitButton;

        [FindsBy(How = How.CssSelector, Using = "#Reset")]
        private IWebElement clearButton;

        [FindsBy(How = How.CssSelector, Using = "#comment")]
        private IWebElement commentField;

        [FindsBy(How = How.CssSelector, Using = "#Maintenance")]
        private IWebElement maintenanceLink;

        [FindsBy(How = How.CssSelector, Using = "#ContactPage")]
        private IWebElement contactLink;

        [FindsBy(How = How.CssSelector, Using = "#Name")]
        private IWebElement newsNameField;

        [FindsBy(How = How.CssSelector, Using = "#Mail")]
        private IWebElement newsMailField;

        [FindsBy(How = How.CssSelector, Using = "#SubButton")]
        private IWebElement newsSubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#footer")]
        private IWebElement footer;

        [FindsBy(How = How.CssSelector, Using = "#Drop")]
        private IWebElement dropPages;


        public string ServisePageMailField(string name, string mail, string phone)
        {
            nameField.SendKeys(name);
            mailField.SendKeys(mail);
            phoneField.SendKeys(phone);
            serviceCheck2.Click();
            submitButton.Click();
            return mailField.GetAttribute("validationMessage");           
        }

        public string ServicePageSubmitButtonDisable(string mail)
        {
            string buttonDisable = "";
            mailField.Clear();
            mailField.SendKeys(mail);
            serviceCheck2.Click();
            buttonDisable = submitButton.GetAttribute("disabled");
            return buttonDisable;
        }

        public Boolean ServicePageSubmitForm(int number)
        {
            bool isSuccess = false;
            switch (number)
            {
                case 1:
                    serviceCheck1.Click();
                    break;

                case 2:
                    serviceCheck2.Click();
                    break;

                case 3:
                    serviceCheck3.Click();
                    break;

                case 4:
                    serviceCheck1.Click();
                    serviceCheck2.Click();
                    serviceCheck3.Click();
                    break;

            }
            
            submitButton.Click();
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

        public Boolean ServicePageFillForm(int checkNumber, string name, string mail, string phone)
        {
            nameField.SendKeys(name);
            mailField.SendKeys(mail);
            phoneField.SendKeys(phone);
            bool result =  ServicePageSubmitForm(checkNumber);
            return result;
        }

        public Boolean ServicesPageClearForm(string name, string mail, string phone)
        {
            bool isCleared = false;

            nameField.SendKeys(name);
            mailField.SendKeys(mail);
            phoneField.SendKeys(phone);
            serviceCheck2.Click();
            clearButton.Click();

            if (nameField.GetAttribute("value") == "" && mailField.GetAttribute("value") == ""
                && phoneField.GetAttribute("value") == "" && serviceCheck1.GetAttribute("checked") == null 
                && serviceCheck2.GetAttribute("checked") == null && serviceCheck3.GetAttribute("checked") == null
                && dateField.GetAttribute("value") == "" && commentField.GetAttribute("value") == "")
           
            {
                isCleared = true;
            }

            return isCleared;
        }

        public MaintenancePage MaintenanceLinkClick()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(dropPages).Perform();
            maintenanceLink.Click();

            return new MaintenancePage(driver);
        }

        public void ServicesPageFillDateAndComment(string date, string comment)
        {
            dateField.SendKeys(date);
            commentField.SendKeys(comment);
        }

        public ContactPage ContactUsLinkClick()
        {
            contactLink.Click();

            return new ContactPage(driver);
        }

        public Boolean ServicePageFillNewsForm(string name, string mail)
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
    }
}
