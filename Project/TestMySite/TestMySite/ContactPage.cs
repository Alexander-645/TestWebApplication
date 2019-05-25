using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMySite
{
    class ContactPage
    {
        private IWebDriver driver;
        
        public ContactPage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;

        }

        [FindsBy(How = How.CssSelector, Using = "#name")]
        private IWebElement nameField;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement mailField;

        [FindsBy(How = How.CssSelector, Using = "#phone")]
        private IWebElement phoneField;

        [FindsBy(How = How.CssSelector, Using = "#theme")]
        private IWebElement themeSelect;

        [FindsBy(How = How.CssSelector, Using = "#Submit1")]
        private IWebElement submitButton;

        [FindsBy(How = How.CssSelector, Using = "#Reset")]
        private IWebElement clearButton;

        [FindsBy(How = How.CssSelector, Using = "#r1")]
        private IWebElement radioButton1;

        [FindsBy(How = How.CssSelector, Using = "#r2")]
        private IWebElement radioButton2;

        [FindsBy(How = How.CssSelector, Using = "#comment")]
        private IWebElement commentField;

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

        [FindsBy(How = How.CssSelector, Using = "#MainLink")]
        private IWebElement mainHeaderLink;

        [FindsBy(How = How.CssSelector, Using = "#Maintenance")]
        private IWebElement maintenancePageLink;

        [FindsBy(How = How.CssSelector, Using = "#FourWheelsLink")]
        private IWebElement mainPageLink;

        public void ContactFormFillTextFields(string name, string mail, string phone)
        {
            nameField.SendKeys(name);
            mailField.SendKeys(mail);
            phoneField.SendKeys(phone);
        }

        public string ContactPageDropboxMessage(string name, string mail, string phone)
        {
            ContactFormFillTextFields(name, mail, phone);
            submitButton.Click();

            return themeSelect.GetAttribute("validationMessage");
        }

        public Boolean ContactPageSubmitForm(string theme)
        {
            bool isSuccess = false;

            SelectElement select = new SelectElement(themeSelect);
            select.SelectByText(theme);
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

        public string ContactPageMailFieldError(string name, string mail, string phone, string theme)
        {
            ContactFormFillTextFields(name, mail, phone);
            SelectElement select = new SelectElement(themeSelect);
            select.SelectByText(theme);
            submitButton.Click();

            return mailField.GetAttribute("validationMessage");
        }

        public Boolean ContactPageFixMail(string mail)
        {
            bool isSuccess = false;

            mailField.Clear();
            mailField.SendKeys(mail);
            phoneField.SendKeys("");
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

        public Boolean ContactPageFillForm(string name, string mail, string phone, string theme)
        {
            bool isSuccess = false;
            ContactFormFillTextFields(name, mail, phone);
            SelectElement select = new SelectElement(themeSelect);
            select.SelectByText(theme);
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

        public Boolean ContactPageClearForm(string name, string mail, string phone, string theme)
        {
            bool isCleared = false;

            ContactFormFillTextFields(name, mail, phone);
            SelectElement select = new SelectElement(themeSelect);
            select.SelectByText(theme);
            clearButton.Click();

            if (nameField.GetAttribute("value") == "" && mailField.GetAttribute("value") == ""
                && phoneField.GetAttribute("value") == "" && themeSelect.GetAttribute("value") == ""
                && commentField.GetAttribute("value") == "" && radioButton1.GetAttribute("checked")!= null 
                && radioButton2.GetAttribute("checked") == null)

            {
                isCleared = true;
            }

            return isCleared;
        }

        public Boolean ContactPageNewsForm(string name, string mail)
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

        public MainPage ContactPageMainPageHeaderLink()
        {
            mainHeaderLink.Click();

            return new MainPage(driver);
        }

        public MaintenancePage MaintenacePageLinkClick()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(dropPages).Perform();
            maintenancePageLink.Click();

            return new MaintenancePage(driver);
        }

        public void ContactPageFormFillRadioAndComments(int radioNum, string comment)
        {
            switch (radioNum)
            {
                case 1:
                    radioButton1.Click();
                    break;
                case 2:
                    radioButton2.Click();
                    break;
            }

            commentField.SendKeys(comment);
        }

        public MainPage FourWheelsLinkClick()
        {
            mainPageLink.Click();

            return new MainPage(driver);
        }

    }
}
