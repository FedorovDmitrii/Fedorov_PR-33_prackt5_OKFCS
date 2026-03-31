using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Fedorov_PR_33_prackt5_OKFCS
{
    public class OperationsWithNotesTest
    {
        [Fact]
        public void Test_CreateNote_ShowsSuccessMessage ()
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
            string noteTitle = "Тестовая заметка";
            IWebElement titleInput = driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(noteTitle);
            IWebElement contentInput = driver.FindElement(By.Id("noteContent"));
            contentInput.SendKeys("Содержание тестовой заметки");
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            saveButton.Click( );
            Thread.Sleep(1500);
            IWebElement message = driver.FindElement(By.Id("message"));
            Assert.DoesNotContain("error", message.GetAttribute("class"));
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.Contains(noteTitle, notesList.Text);
            driver.Quit( );
        }
        [Fact]
        public void Test_CreateNoteWithEmptyTitle_ShowsError ()
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
            titleInput.Clear( );
            IWebElement contentInput = driver.FindElement(By.Id("noteContent"));
            contentInput.SendKeys("Текст без заголовка");
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            saveButton.Click( );
            Thread.Sleep(1000);
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.DoesNotContain("Текст без заголовка", notesList.Text);
            driver.Quit( );
        }
        [Fact]
        public void Test_EditNote ()
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
            string originalTitle = "Заметка для редактирования";
            IWebElement titleInput = driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(originalTitle);
            IWebElement contentInput = driver.FindElement(By.Id("noteContent"));
            contentInput.SendKeys("Исходный текст");
            IWebElement saveButton = driver.FindElement(By.Id("saveBtn"));
            saveButton.Click( );
            Thread.Sleep(1500);
            var noteElements = driver.FindElements(By.TagName("li"));
            IWebElement targetNote = null;
            foreach (var li in noteElements)
            {
                if (li.Text.Contains(originalTitle))
                {
                    targetNote = li;
                    break;
                }
            }
            targetNote?.Click( );
            Thread.Sleep(500);
            titleInput.Clear( );
            titleInput.SendKeys("Измененный заголовок");
            contentInput.Clear( );
            contentInput.SendKeys("Измененный текст");
            saveButton.Click( );
            Thread.Sleep(1500);
            IWebElement message = driver.FindElement(By.Id("message"));
            Assert.DoesNotContain("error", message.GetAttribute("class"));
            IWebElement notesList = driver.FindElement(By.Id("notesList"));
            Assert.Contains("Измененный заголовок", notesList.Text);
            driver.Quit( );
        }
        [Fact]
        public void DeleteNoteTest ()
        {
            IWebDriver driver = new ChromeDriver( );
            driver.Navigate( ).GoToUrl("https://test.webmx.ru");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("authUsername")).SendKeys("testFDA");
            driver.FindElement(By.Id("authPassword")).SendKeys("testFDA");
            driver.FindElement(By.Id("authSubmit")).Click( );
            Thread.Sleep(2000);
            string noteTitle = "Заметка для удаления";
            driver.FindElement(By.Id("noteTitle")).SendKeys(noteTitle);
            driver.FindElement(By.Id("noteContent")).SendKeys("Текст");
            driver.FindElement(By.Id("saveBtn")).Click( );
            Thread.Sleep(2000);
            int countBefore = driver.FindElements(By.TagName("li")).Count;
            var notes = driver.FindElements(By.TagName("li"));
            foreach (var note in notes)
            {
                if (note.Text.Contains(noteTitle))
                {
                    note.Click( );
                    break;
                }
            }
            Thread.Sleep(1000);
            driver.FindElement(By.Id("deleteBtn")).Click( );
            Thread.Sleep(500);
            driver.SwitchTo( ).Alert( ).Accept( );
            Thread.Sleep(2000);
            int countAfter = driver.FindElements(By.TagName("li")).Count;
            Assert.True(countAfter < countBefore);
            driver.Quit( );
        }
    }
}