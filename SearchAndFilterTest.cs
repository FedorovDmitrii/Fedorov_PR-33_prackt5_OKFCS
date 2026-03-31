using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Fedorov_PR_33_prackt5_OKFCS
{
    public class SearchAndFilterTest
    {
        [Fact]
        public void Test_SearchNotes ()
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
            IWebElement titleInput = driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys("Моя тестовая заметка");
            IWebElement contentInput = driver.FindElement(By.Id("noteContent"));
            contentInput.SendKeys("Содержание для поиска");
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            saveButton.Click( );
            Thread.Sleep(1500);
            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));
            searchInput.SendKeys("для поиска");
            Thread.Sleep(1000);
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.Contains("Моя тестовая заметка", notesList.Text);
            driver.Quit( );
        }
        [Fact]
        public void Test_FilterNotes_All ()
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
            IWebElement filterDropdown = driver.FindElement(By.Id("noteScopeFilter"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(filterDropdown);
            selectElement.SelectByValue("all");
            Thread.Sleep(1000);
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.True(notesList.Displayed);
            driver.Quit( );
        }
        [Fact]
        public void Test_FilterNotes_Mine ()
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
            IWebElement titleInput = driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys("Моя личная заметка");
            IWebElement contentInput = driver.FindElement(By.Id("noteContent"));
            contentInput.SendKeys("Содержание");
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            saveButton.Click( );
            Thread.Sleep(1500);
            IWebElement filterDropdown = driver.FindElement(By.Id("noteScopeFilter"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(filterDropdown);
            selectElement.SelectByValue("mine");
            Thread.Sleep(1000);
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.Contains("Моя личная заметка", notesList.Text);
            driver.Quit( );
        }
        [Fact]
        public void Test_FilterNotes_Shared ()
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
            IWebElement filterDropdown = driver.FindElement(By.Id("noteScopeFilter"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(filterDropdown);
            selectElement.SelectByValue("shared");
            Thread.Sleep(1000);
            IWebElement notesSection = driver.FindElement(By.Id("notesSection"));
            Assert.DoesNotContain("hidden", notesSection.GetAttribute("class"));
            driver.Quit( );
        }
    }
}