namespace MainProgram
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    class MainProgram
    {
        static void Main()
        {
            IWebDriver wdriver = new ChromeDriver(@"dependencies");
            wdriver.Navigate().GoToUrl("https://softuni.bg/trainings/1175/High-Quality-Code-July-2015");
        }
    }
}
