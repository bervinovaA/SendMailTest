using OpenQA.Selenium;
using NUnit.Framework;



namespace SendMailTest
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By LoginButton = By.XPath("//input[@name='login']");
        private readonly By PasswordButton = By.XPath("//input[@name='password']");
        private readonly By ContinueButton = By.XPath("//button[@type='submit']");
        private readonly By SendButton = By.XPath("//button[@class='button primary compose']");
        private readonly By ToButton = By.XPath("//a[text()='Кому:']");
        private readonly By ContactButton = By.XPath("//span[text()='alinabervinova5@gmail.com']");
        private readonly By Write = By.XPath("//button[text()='Написати']");
        private readonly By SendButtom2 = By.XPath("//div[@class='sendmsg__bottom-controls']/button[@class='button primary send']");
        private readonly By SendButton3 = By.XPath("//button[@class='button primary default']");
        private readonly By ActualConfirmation = By.XPath("//button[text()='Написати ще']");
        
        private const string ExpectedConfirmation = "Написати ще";
        private const string login = "alinabervinovatest@ukr.net";
        private const string password = "trewq1234";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(@"C:\Users\User\source\repos\SendMailTest\SendMailTest\drivers");
            driver.Navigate().GoToUrl("https://accounts.ukr.net/");
        }

        [Test]
        public void Test1()
        {
            
            var Login = driver.FindElement(LoginButton);
            Login.SendKeys(login);

            var passwordInput = driver.FindElement(PasswordButton);
            passwordInput.SendKeys(password);

            Thread.Sleep(1000);
            var Cont = driver.FindElement(ContinueButton);
            Cont.Click();

            Thread.Sleep(2000);
            var Send = driver.FindElement(SendButton);
            Send.Click();

            Thread.Sleep(1000);
            var To = driver.FindElement(ToButton);
            To.Click();

            var contact = driver.FindElement(ContactButton);
            contact.Click();

            Thread.Sleep(1000);
            var write = driver.FindElement(Write);
            write.Click();

            Thread.Sleep(2000);
            var send2 = driver.FindElement(SendButtom2);
            send2.Click();

            var send3 = driver.FindElement(SendButton3);
            send3.Click();

            Thread.Sleep(2000);
            var actualconf = driver.FindElement(ActualConfirmation).Text;
            Assert.That(actualconf, Is.EqualTo(ExpectedConfirmation), "Messadge was not send");




        }

        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}