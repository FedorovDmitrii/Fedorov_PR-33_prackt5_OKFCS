using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Fedorov_PR_33_prackt5_OKFCS
{
    public class ShareNote
    {
        [Fact]
        public void Test_ShareNote_WithUser ()
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
            titleInput.SendKeys("Общая заметка");
            IWebElement contentInput = driver.FindElement(By.Id("noteContent"));
            contentInput.SendKeys("Заметка для совместного доступа");
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            saveButton.Click( );
            Thread.Sleep(1500);
            var noteElements = driver.FindElements(By.TagName("li"));
            IWebElement targetNote = null;
            foreach (var li in noteElements)
            {
                if (li.Text.Contains("Общая заметка"))
                {
                    targetNote = li;
                    break;
                }
            }
            targetNote?.Click( );
            Thread.Sleep(1000);
            IWebElement shareBlock = driver.FindElement(By.Id("shareBlock"));
            Assert.DoesNotContain("hidden", shareBlock.GetAttribute("class"));
            IWebElement shareUsernameInput = driver.FindElement(By.Id("shareUsername"));
            shareUsernameInput.SendKeys("testFDA2");
            IWebElement shareButton = driver.FindElement(By.Id("shareBtn"));
            shareButton.Click( );
            Thread.Sleep(1500);
            IWebElement message = driver.FindElement(By.Id("message"));
            Assert.False(message.GetAttribute("class").Contains("hidden"));
            driver.Quit( );
        }
    }
}