using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverLoginTest
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Principal;
    using OpenQA.Selenium.Support.UI;

    [TestClass]
    public class WebDriverLogin
    {
        [TestMethod]
        public void RedirectToLoginFromHomePage()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg");
                wdriver.Manage().Window.Maximize();
                wdriver.FindElement(By.Id("loginLink")).Click();

                Assert.AreEqual(wdriver.Url, "https://softuni.bg/account/authenticate");
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void FindLinkByLinkTextTest()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                IWebElement firstLink = wdriver.FindElement(By.LinkText("Предишни инстанции на курса"));

                Assert.AreEqual("https://softuni.bg/courses/high-quality-code/", firstLink.GetAttribute("href"));
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void TestTable()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                IWebElement simpleTable = wdriver.FindElement(By.Id("lectures-table"));

                //Get all rows
                IList rows = simpleTable.FindElements(By.TagName("tr"));
                Assert.AreEqual(30, rows.Count);
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void FindEelementLinkTextTest()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/account/authenticate");
                wdriver.FindElement(By.LinkText("Кандидатствай")).Click();

                Assert.AreEqual(wdriver.Url, "https://softuni.bg/account/authenticate?returnUrl=%2Fusers%2Fcandidate%2Fregister");
                wdriver.Quit();
            }
        }
    }
}
