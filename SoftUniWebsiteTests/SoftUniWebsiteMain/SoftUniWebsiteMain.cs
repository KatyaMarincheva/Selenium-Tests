// <copyright file="SoftUniWebsiteMain.cs" company="Katya.com">
//     Katya.com. All rights reserved.
// </copyright>
// <author>Katya</author>
namespace SoftUniWebsiteMain
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// The SoftUniWebsiteMain class holds the entry point of the application.
    /// </summary>
    public class SoftUniWebsiteMain
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            using (IWebDriver wdriver = new FirefoxDriver())
            {
                wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
                wdriver.FindElement(By.XPath("/html/body/div[1]/div/div/h2/a"));


                wdriver.Quit();
            }
        }
    }
}