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
    public class TestBase
    {
        protected IWebDriver driver;
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
        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }
        protected void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("[id='LoginForm'] input[name='user']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("[id='LoginForm'] input[name='pass']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("[id='LoginForm'] input[type='submit']")).Click();
        }
        protected void GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("[id='nav'] [class='admin']")).Click();
        }
        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[type='text']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("form [name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("form [name='group_footer']")).SendKeys(group.Footer);
        }
        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }
        protected void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("[id='content'] input[name='new']")).Click();
        }
        protected void ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("[class='msgbox'] i a")).Click();
        }
        protected void Logout()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }
        protected void SelectGroup()
        {
            driver.FindElement(By.CssSelector("[class='group'] input[type='checkbox']")).Click();
        }
        protected void RemoveGroup()
        {
            driver.FindElement(By.CssSelector("[method='post'] input[name='delete']")).Click();
        }
    }
}
