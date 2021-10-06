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
    public class RemoveGroupTests
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup();
            RemoveGroup();
            ReturnToGroupsPage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }

        private void ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("[class='msgbox'] i a")).Click();
        }

        private void RemoveGroup()
        {
            driver.FindElement(By.CssSelector("[method='post'] input[name='delete']")).Click();
        }

        private void SelectGroup()
        {
            driver.FindElement(By.CssSelector("[class='group'] input[type='checkbox']")).Click();
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
