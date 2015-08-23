// <copyright file="SoftUniWebsiteSeleniumTests.cs" company="Katya.com">
//     Katya.com. All rights reserved.
// </copyright>
// <author>Katya</author>
namespace SoftUniWebsiteSeleniumTests
{
    using System.Collections;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// The SoftUniWebsiteSeleniumTests class contains 8 methods testing the functionality of the SoftUni website.
    /// </summary>
    [TestClass]
    public class SoftUniWebsiteSeleniumTests
    {
        /// <summary>
        /// Tests the redirect to login from home page - should pass test.
        /// </summary>
        [TestMethod]
        public void Login_RedirectToLoginFromHomePage_ShouldPassTest()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg");
                wdriver.FindElement(By.Id("loginLink")).Click();

                Assert.AreEqual(wdriver.Url, "https://softuni.bg/account/authenticate");
                wdriver.Quit();
            }
        }

        /// <summary>
        /// Tests login with wrong password - should produce error message.
        /// </summary>
        [TestMethod]
        public void Login_TryToLoginWithWrongPassword_ShouldProduceErrorMessage()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://softuni.bg/account/authenticate");
                driver.FindElement(By.Id("LoginUserName")).SendKeys("KatyaMarincheva");
                driver.FindElement(By.Id("LoginPassword")).SendKeys("password");
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/form/div/div[2]/input")).Click();

                string actualErrorMessage = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]")).Text;
                const string ExpectedErrorMessage = "Невалиден потребител или парола";

                Assert.AreEqual(ExpectedErrorMessage, actualErrorMessage);
                driver.Quit();
            }
        }

        /// <summary>
        /// Tests login with correct password - should pass test.
        /// </summary>
        [TestMethod]
        public void Login_TryToLoginWithCorrectPassword_ShouldPassTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://softuni.bg/account/authenticate");
                driver.FindElement(By.Id("LoginUserName")).SendKeys("testtest1234test");
                driver.FindElement(By.Id("LoginPassword")).SendKeys("testtest");
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/form/div/div[2]/input")).Click();

                string actualEmailAddress = driver.FindElement(By.PartialLinkText("@")).Text;
                const string ExpectedEmailAddress = "testtest1234test@abv.bg";

                Assert.AreEqual(ExpectedEmailAddress, actualEmailAddress);
                driver.Quit();
            }
        }

        /// <summary>
        /// Tests query functionality - after the logging in and running a search should returns search results for the keyword "Боровец".
        /// </summary>
        [TestMethod]
        public void Query_LoginAndRunASearch_ShouldPassTest()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://softuni.bg/account/authenticate");
                driver.FindElement(By.Id("LoginUserName")).SendKeys("testtest1234test");
                driver.FindElement(By.Id("LoginPassword")).SendKeys("testtest");
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/form/div/div[2]/input")).Click();

                IWebElement query = driver.FindElement(By.Name("query"));

                query.SendKeys("Боровец");

                query.Submit();

                const string ExpectedUrl =
                    "https://softuni.bg/Search/Results?query=%D0%91%D0%BE%D1%80%D0%BE%D0%B2%D0%B5%D1%86";
                Assert.AreEqual(ExpectedUrl, driver.Url);

                driver.Quit();
            }
        }

        /// <summary>
        /// Tests the navigation through the Actives the courses dropdown menu - should pass test.
        /// </summary>
        [TestMethod]
        public void ActiveCourses_NavigateThroughDropDownMenu_ShouldPassTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://softuni.bg/");
                driver.FindElement(By.XPath("/html/body/header/div/div/div/div/nav/ul[2]/li[2]/a")).Click();
                driver.FindElement(By.LinkText("Качествен програмен код - юли 2015")).Click();

                const string ExpectedUrl = "https://softuni.bg/trainings/1175/High-Quality-Code-July-2015";
                Assert.AreEqual(ExpectedUrl, driver.Url);

                driver.Quit();
            }
        }

        /// <summary>
        /// Tests the finding of the Previous course instances link by link text - should pass test.
        /// </summary>
        [TestMethod]
        public void PreviousCourseInstances_FindLinkByLinkText_ShouldPassTest()
        {
            using (IWebDriver wdriver = new FirefoxDriver())
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                string actualLinkText = wdriver.FindElement(By.LinkText("Предишни инстанции на курса")).Text;

                Assert.AreEqual("Предишни инстанции на курса", actualLinkText);
                wdriver.Quit();
            }
        }

        /// <summary>
        /// Tests if the rows number in the lectures table is correct - should pass test.
        /// </summary>
        [TestMethod]
        public void Lectures_CountRowsNumberInLecturesTable_ShouldPassTest()
        {
            using (IWebDriver wdriver = new ChromeDriver())
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                IWebElement simpleTable = wdriver.FindElement(By.Id("lectures-table"));
                IList rows = simpleTable.FindElements(By.TagName("tr"));

                const int ExpectedRowsNumber = 30;
                int actualRowsNumber = rows.Count;

                Assert.AreEqual(ExpectedRowsNumber, actualRowsNumber);
                wdriver.Quit();
            }
        }

        /// <summary>
        /// Tests the redirect to application page from sign in page - should pass test.
        /// </summary>
        [TestMethod]
        public void Apply_RedirectToApplyFromSignInPage_ShouldPassTest()
        {
            using (IWebDriver wdriver = new FirefoxDriver())
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg");
                wdriver.Manage().Window.Maximize();
                wdriver.FindElement(By.Id("loginLink")).Click();

                Assert.AreEqual(wdriver.Url, "https://softuni.bg/account/authenticate");
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void Softuni_OpenSoftUniWebsite_ShouldPassTest()
        {
            using (IWebDriver wdriver = new InternetExplorerDriver())
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                wdriver.FindElement(By.TagName("body")).Click();
                string actualLinkText = wdriver.FindElement(By.LinkText("Предишни инстанции на курса")).Text;

                wdriver.Quit();
            }
        }
    }
}