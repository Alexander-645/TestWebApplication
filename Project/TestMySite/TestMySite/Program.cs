using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class Program
    {
        

        static void Main(string[] args)
        {
        }

        IWebDriver driver = new ChromeDriver();


        [Test]
        //Test-case № 13
        public void TestServicesPageFillForm()
        {

            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);

            mainPage.ServicesPageLinkClick();
            
            ServicesPage servicesPage = new ServicesPage(driver);

            string Valid = servicesPage.FillIncorrectMail("Олег", "123", "89521100129");
            bool result = Valid.Contains("@");
            Assert.IsTrue(result, "Сообщение не выведено");

            Assert.AreEqual("true", servicesPage.SubmitButtonDisabled("testmail@mail.ru"));
            Assert.IsTrue(servicesPage.SubmitForm(1), "Форма не отправлена.");

            Assert.IsTrue(servicesPage.FillAndSubmitForm(3, "Олег", "testmail@mail.ru", "89521100129"), "Форма не отправлена.");

            Assert.IsTrue(servicesPage.FillAndSubmitForm(4, "Олег", "testmail@mail.ru", "89521100129"), "Форма не отправлена.");

            Assert.IsTrue(servicesPage.ClearForm("Олег", "testmail@mail.ru", "89521100129"), "Форма не очищена");

        }

        [Test]
        //Test-case № 16
        public void TestContactPageFillForm()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(200);
            mainPage.MaintenancePageLinkClick();
            
            MaintenancePage maintenacePage = new MaintenancePage(driver);
            maintenacePage.ContactLinkClick();

            ContactPage contactPage = new ContactPage(driver);

            string Valid = contactPage.SetEmptyDropbox("Сережа", "sermail@gmail.com", "88005553535");

            Assert.AreEqual("Выберите один из пунктов списка.", Valid);

            Assert.IsTrue(contactPage.FillDropboxAndSubmitForm("Вопрос"), "");
            
        }

        [Test]
        //Test-case № 17
        public void TestContactPageFillFormDifferentValues()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.ContactPageLinkClick();
            ContactPage contactPage = new ContactPage(driver);

            string Valid = contactPage.FillIncorrectMail("Сережа", "sermail", "88005553535", "Вопрос");
            bool result = Valid.Contains("@");
            Assert.IsTrue(result, "Сообщение не выведено");
            Assert.IsTrue(contactPage.FixMailAndSubmitForm("sermail@gmail.com"));

            Assert.IsTrue(contactPage.FillAndSubmitForm("Сережа", "sermail@gmail.com", "88005553535", "Запись на техобслуживание"));

            Assert.IsTrue(contactPage.FillAndSubmitForm("Сережа", "sermail@gmail.com", "88005553535", "Жалобы и предложения"));

            Assert.IsTrue(contactPage.FillAndSubmitForm("Сережа", "sermail@gmail.com", "88005553535", "Проблемы"));

            Assert.IsTrue(contactPage.FillAndSubmitForm("Сережа", "sermail@gmail.com", "88005553535", "Проблемы"), "Форма не очищена");
            
        }

        [Test]
        //Test-case № 18

        public void TestGoToAllPages()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.ServicesPageTextLinkClick();
            ServicesPage servicesPage = new ServicesPage(driver);
            servicesPage.MaintenanceLinkClick();
            MaintenancePage maintenacePage = new MaintenancePage(driver);
            maintenacePage.ContactLinkClick();
            ContactPage contactPage = new ContactPage(driver);

            Assert.IsTrue(contactPage.FillNewsForm("Александр", "myemail@mail.ru"));

            bool isMainPageOpened = contactPage.MainPageHeaderLinkClick().MainPageOpen();
            Assert.IsTrue(isMainPageOpened, "Главная страница не открылась");
            
        }


        [Test]
        //Test-case № 19

        public void TestFillAllForms()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.LowerServicesTextLinkClick();

            ServicesPage servicesPage = new ServicesPage(driver);
            string date = DateTime.Now.ToShortDateString();
            servicesPage.FillDateAndComment(date, "Это простой комментарий");

            Assert.IsTrue(servicesPage.FillAndSubmitForm(4, "Павел", "pavmail@gmail.com", "88005553535"));

            Assert.IsTrue(servicesPage.FillNewsForm("Павел", "pavelmail@gmail.com"));

            servicesPage.ContactUsLinkClick();

            ContactPage contactPage = new ContactPage(driver);
            contactPage.ContactFormFillTextFields("Павел", "pavmail@gmail.com", "88005553535");
            contactPage.MaintenacePageLinkClick();

            MaintenancePage maintenancePage = new MaintenancePage(driver);
            Thread.Sleep(300);
            maintenancePage.ContactLinkClick();
            
            Assert.IsTrue(contactPage.ClearForm("Павел", "pavmail@gmail.com", "88005553535", "Проблемы"), "Форма не очищена");

            contactPage.FillRadioBtnAndComments(2, "Комментарий");
            Assert.IsTrue(contactPage.FillAndSubmitForm("Павел", "pavelmail@gmail.com", "88005553535", "Жалобы и предложения"));

            contactPage.FillRadioBtnAndComments(2, "Комментарий");
            Assert.IsTrue(contactPage.FillAndSubmitForm("Павел", "pavelmail@gmail.com", "88005553535", "Вопрос"));

            contactPage.FillRadioBtnAndComments(2, "Комментарий");
            Assert.IsTrue(contactPage.FillAndSubmitForm("Павел", "pavelmail@gmail.com", "88005553535", "Запись на техобслуживание"));

            Assert.IsTrue(contactPage.FillNewsForm("Павел", "pavelmail@gmail.com"));

           
            bool isMainPageOpened = contactPage.FourWheelsLinkClick().MainPageOpen();
            Assert.IsTrue(isMainPageOpened, "Главная страница не открылась");

            Assert.IsTrue(mainPage.FillNewsForm("Павел", "pavelmail@gmail.com"));
            mainPage.MaintenaceTextLinkClick();

            Assert.IsTrue(maintenancePage.FillNewsForm("Павел", "pavelmail@gmail.com"));
            maintenancePage.MainPageLinkClick();
        }


        [OneTimeTearDown]
        public void DriverClose()
        {
            driver.Close();
        }
    }


}
