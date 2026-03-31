using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Fedorov_PR_33_prackt5_OKFCS
{
    public class AccessTest
    {
        [Fact]
        public void Test_LoginAndRegistrationPage_LoadedCorrectly()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement heading = driver.FindElement(By.Id("mainView"));
            Assert.True(heading.Displayed);
            IWebElement loginTab = driver.FindElement(By.Id("loginTab"));
            Assert.True(loginTab.Displayed);
            Assert.Contains("active", loginTab.GetAttribute("class"));
            IWebElement registerTab = driver.FindElement(By.Id("registerTab"));
            Assert.True(registerTab.Displayed);
            IWebElement loginInput = driver.FindElement(By.Id("authUsername"));
            Assert.True(loginInput.Displayed);
            Assert.Equal("3", loginInput.GetAttribute("minlength"));
            IWebElement passwordInput = driver.FindElement(By.Id("authPassword"));
            Assert.True(passwordInput.Displayed);
            Assert.Equal("6", passwordInput.GetAttribute("minlength"));
            IWebElement submitButton = driver.FindElement(By.Id("authSubmit"));
            Assert.Equal("Войти", submitButton.Text);
            driver.Quit();
        }
        [Fact]
        public void Test_SwitchLoginAndRegistrationTabs ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            IWebElement loginTab = driver.FindElement(By.Id("loginTab"));
            Assert.Contains("active", loginTab.GetAttribute("class"));
            IWebElement registerTab = driver.FindElement(By.Id("registerTab"));
            registerTab.Click( );
            Thread.Sleep(500);
            Assert.Contains("active", registerTab.GetAttribute("class"));
            Assert.DoesNotContain("active", loginTab.GetAttribute("class"));
            IWebElement submitButton = driver.FindElement(By.Id("authSubmit"));
            Assert.Equal("Зарегистрироваться", submitButton.Text);
            driver.Quit( );
        }
        [Fact]
        public void Test_InterfaceElements_AfterLogin ()
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
            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));
            Assert.True(searchInput.Displayed);
            IWebElement filterDropdown = driver.FindElement(By.Id("noteScopeFilter"));
            Assert.True(filterDropdown.Displayed);
            IWebElement newNoteButton = driver.FindElement(By.Id("newNoteBtn"));
            Assert.True(newNoteButton.Displayed);
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.True(notesList.Displayed);
            IWebElement noteTitle = driver.FindElement(By.Id("noteTitle"));
            Assert.True(noteTitle.Displayed);
            IWebElement noteContent = driver.FindElement(By.Id("noteContent"));
            Assert.True(noteContent.Displayed);
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            Assert.True(saveButton.Displayed);
            IWebElement logoutButton = driver.FindElement(By.Id("logoutBtn"));
            Assert.True(logoutButton.Displayed);
            driver.Quit( );
        }
    }
}