// <copyright file="MainProgram.cs" company="Katya.com">
//     Katya.com. All rights reserved.
// </copyright>
// <author>Katya</author>
namespace MainProgram
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// Project's entry point.
    /// </summary>
    public class MainProgram
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            IWebDriver wdriver = new ChromeDriver(@"dependencies");
            wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
        }
    }
}