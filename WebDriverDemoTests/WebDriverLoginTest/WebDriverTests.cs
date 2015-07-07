// <copyright file="WebDriverTests.cs" company="Katya.com">
//     Katya.com. All rights reserved.
// </copyright>
// <author>Katya</author>
namespace WebDriverLoginTest
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// Test methods for the https://softuni.bg functionality.
    /// </summary>
    [TestClass]
    public class WebDriverTests
    {
        /// <summary>
        /// Redirects to login from home page.
        /// </summary>
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

        /// <summary>
        /// Finds the link by link text.
        /// </summary>
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

        /// <summary>
        /// Tests the table for rows number.
        /// </summary>
        [TestMethod]
        public void TestTable()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                IWebElement simpleTable = wdriver.FindElement(By.Id("lectures-table"));

                // Get all rows
                IList rows = simpleTable.FindElements(By.TagName("tr"));
                Assert.AreEqual(30, rows.Count);
                wdriver.Quit();
            }
        }

        /// <summary>
        /// Redirects from sign-in page to apply-page.
        /// </summary>
        [TestMethod]
        public void RedirectToApplyBySignInPage()
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