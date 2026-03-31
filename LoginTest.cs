using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Fedorov_PR_33_prackt5_OKFCS
{
    public class LoginTest
    {
        [Fact]
        public void Test_Login_WithValidCredentials_User1 ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement loginInput = driver.FindElement(By.Id("authUsername"));
            loginInput.SendKeys("testFDA");
            IWebElement passwordInput = driver.FindElement(By.Id("authPassword"));
            passwordInput.SendKeys("testFDA");
            IWebElement loginButton = driver.FindElement(By.Id("authSubmit"));
            loginButton.Click( );
            Thread.Sleep(2000);
            IWebElement userPanel = driver.FindElement(By.Id("userPanel"));
            Assert.DoesNotContain("hidden", userPanel.GetAttribute("class"));
            IWebElement welcomeText = driver.FindElement(By.Id("welcomeText"));
            Assert.Contains("testFDA", welcomeText.Text);
            IWebElement notesSection = driver.FindElement(By.Id("notesSection"));
            Assert.DoesNotContain("hidden", notesSection.GetAttribute("class"));
            driver.Quit( );
        }
        [Fact]
        public void Test_Login_WithValidCredentials_User2 ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement loginInput = driver.FindElement(By.Id("authUsername"));
            loginInput.SendKeys("testFDA2");
            IWebElement passwordInput = driver.FindElement(By.Id("authPassword"));
            passwordInput.SendKeys("testFDA");
            IWebElement loginButton = driver.FindElement(By.Id("authSubmit"));
            loginButton.Click( );
            Thread.Sleep(2000);
            IWebElement welcomeText = driver.FindElement(By.Id("welcomeText"));
            Assert.Contains("testFDA2", welcomeText.Text);
            driver.Quit( );
        }
        [Fact]
        public void Test_Login_WithWrongPassword_ShowsError ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement loginInput = driver.FindElement(By.Id("authUsername"));
            loginInput.SendKeys("testFDA");
            IWebElement passwordInput = driver.FindElement(By.Id("authPassword"));
            passwordInput.SendKeys("wrongpassword");
            IWebElement submitButton = driver.FindElement(By.Id("authSubmit"));
            submitButton.Click( );
            Thread.Sleep(1500);
            IWebElement message = driver.FindElement(By.Id("message"));
            Assert.Contains("error", message.GetAttribute("class"));
            Assert.DoesNotContain("hidden", message.GetAttribute("class"));
            driver.Quit( );
        }
        [Fact]
        public void Test_Login_WithEmptyFields ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement submitButton = driver.FindElement(By.Id("authSubmit"));
            submitButton.Click( );
            Thread.Sleep(500);
            IWebElement loginInput = driver.FindElement(By.Id("authUsername"));
            Assert.True(loginInput.Displayed);
            driver.Quit( );
        }
        [Fact]
        public void Test_Logout ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement loginInput = driver.FindElement(By.Id("authUsername"));
            loginInput.SendKeys("testFDA");
            IWebElement passwordInput = driver.FindElement(By.Id("authPassword"));
            passwordInput.SendKeys("testFDA");
            IWebElement loginButton = driver.FindElement(By.Id("authSubmit"));
            loginButton.Click( );
            Thread.Sleep(2000);
            IWebElement logoutButton = driver.FindElement(By.Id("logoutBtn"));
            logoutButton.Click( );
            Thread.Sleep(1500);
            IWebElement authSection = driver.FindElement(By.Id("authSection"));
            Assert.DoesNotContain("hidden", authSection.GetAttribute("class"));
            IWebElement notesSection = driver.FindElement(By.Id("notesSection"));
            Assert.Contains("hidden", notesSection.GetAttribute("class"));
            driver.Quit( );
        }
    }
}