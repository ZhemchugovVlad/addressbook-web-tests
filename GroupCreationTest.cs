using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver driver;
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "fff";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }

        private void ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[type='text']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("form [name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("form [name='group_footer']")).SendKeys(group.Footer);
        }

        private void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("[id='content'] input[name='new']")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("[id='LoginForm'] input[name='user']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("[id='LoginForm'] input[name='pass']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("[id='LoginForm'] input[type='submit']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }
    }
}