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
        public void ServicesPageFormTest()
        {

            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.ServicesPageLink();
            
            ServicesPage servicesPage = new ServicesPage(driver);
            string Valid = servicesPage.ServisePageMailField("Олег", "123", "89521100129");
            bool result = Valid.Contains("@");
            Assert.IsTrue(result, "Сообщение не выведено");
            Assert.AreEqual("true", servicesPage.ServicePageSubmitButtonDisable("testmail@mail.ru"));

            Assert.IsTrue(servicesPage.ServicePageSubmitForm(1), "Форма не отправлена.");

            Assert.IsTrue(servicesPage.ServicePageFillForm(3, "Олег", "testmail@mail.ru", "89521100129"), "");

            Assert.IsTrue(servicesPage.ServicePageFillForm(4, "Олег", "testmail@mail.ru", "89521100129"), "");

            Assert.IsTrue(servicesPage.ServicesPageClearForm("Олег", "testmail@mail.ru", "89521100129"), "Форма не очищена");

            driver.Close();
        }

        [Test]
        //Test-case № 16
        public void ContactPageFormTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(200);
            mainPage.MaintenancePageLink();
            
            MaintenancePage maintenacePage = new MaintenancePage(driver);
            maintenacePage.ContactLinkClick();

            ContactPage contactPage = new ContactPage(driver);

            string Valid = contactPage.ContactPageDropboxMessage("Сережа", "sermail@gmail.com", "88005553535");

            Assert.AreEqual("Выберите один из пунктов списка.", Valid);

            Assert.IsTrue(contactPage.ContactPageSubmitForm("Вопрос"), "");
            
        }

        [Test]
        //Test-case № 17
        public void ContactPageAllFormElementsTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.ContactPageLink();
            ContactPage contactPage = new ContactPage(driver);

            string Valid = contactPage.ContactPageMailFieldError("Сережа", "sermail", "88005553535", "Вопрос");
            bool result = Valid.Contains("@");
            Assert.IsTrue(result, "Сообщение не выведено");
            Assert.IsTrue(contactPage.ContactPageFixMail("sermail@gmail.com"));

            Assert.IsTrue(contactPage.ContactPageFillForm("Сережа", "sermail@gmail.com", "88005553535", "Запись на техобслуживание"));

            Assert.IsTrue(contactPage.ContactPageFillForm("Сережа", "sermail@gmail.com", "88005553535", "Жалобы и предложения"));

            Assert.IsTrue(contactPage.ContactPageFillForm("Сережа", "sermail@gmail.com", "88005553535", "Проблемы"));

            Assert.IsTrue(contactPage.ContactPageClearForm("Сережа", "sermail@gmail.com", "88005553535", "Проблемы"), "Форма не очищена");
            
        }

        [Test]
        //Test-case № 18

        public void GoToAllPagesTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.ServicesPageTextLink();
            ServicesPage servicesPage = new ServicesPage(driver);
            servicesPage.MaintenanceLinkClick();
            MaintenancePage maintenacePage = new MaintenancePage(driver);
            maintenacePage.ContactLinkClick();
            ContactPage contactPage = new ContactPage(driver);

            Assert.IsTrue(contactPage.ContactPageNewsForm("Александр", "myemail@mail.ru"));

            bool isMainPageOpened = contactPage.ContactPageMainPageHeaderLink().MainPageOpen();
            Assert.IsTrue(isMainPageOpened, "Главная страница не открылась");
            
        }


        [Test]
        //Test-case № 19

        public void AllPagesFormTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Url = "file:///C:/Administration_IS/Application/index.html";
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(300);
            mainPage.ServicesTextLinkTwo();

            ServicesPage servicesPage = new ServicesPage(driver);
            string date = DateTime.Now.ToShortDateString();
            servicesPage.ServicesPageFillDateAndComment(date, "Это простой комментарий");

            Assert.IsTrue(servicesPage.ServicePageFillForm(4, "Павел", "pavmail@gmail.com", "88005553535"));

            Assert.IsTrue(servicesPage.ServicePageFillNewsForm("Павел", "pavelmail@gmail.com"));

            servicesPage.ContactUsLinkClick();

            ContactPage contactPage = new ContactPage(driver);
            contactPage.ContactFormFillTextFields("Павел", "pavmail@gmail.com", "88005553535");
            contactPage.MaintenacePageLinkClick();

            MaintenancePage maintenancePage = new MaintenancePage(driver);
            Thread.Sleep(300);
            maintenancePage.ContactLinkClick();
            
            Assert.IsTrue(contactPage.ContactPageClearForm("Павел", "pavmail@gmail.com", "88005553535", "Проблемы"), "Форма не очищена");

            contactPage.ContactPageFormFillRadioAndComments(2, "Комментарий");
            Assert.IsTrue(contactPage.ContactPageFillForm("Павел", "pavelmail@gmail.com", "88005553535", "Жалобы и предложения"));

            contactPage.ContactPageFormFillRadioAndComments(2, "Комментарий");
            Assert.IsTrue(contactPage.ContactPageFillForm("Павел", "pavelmail@gmail.com", "88005553535", "Вопрос"));

            contactPage.ContactPageFormFillRadioAndComments(2, "Комментарий");
            Assert.IsTrue(contactPage.ContactPageFillForm("Павел", "pavelmail@gmail.com", "88005553535", "Запись на техобслуживание"));

            Assert.IsTrue(contactPage.ContactPageNewsForm("Павел", "pavelmail@gmail.com"));

           
            bool isMainPageOpened = contactPage.FourWheelsLinkClick().MainPageOpen();
            Assert.IsTrue(isMainPageOpened, "Главная страница не открылась");

            Assert.IsTrue(mainPage.MainPageFillNewsForm("Павел", "pavelmail@gmail.com"));
            mainPage.MaintenaceTextLinkClick();

            Assert.IsTrue(maintenancePage.MaintenancePageFillNewsForm("Павел", "pavelmail@gmail.com"));
            maintenancePage.MainPageLinkClick();
        }
    }


}
