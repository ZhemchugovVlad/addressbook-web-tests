using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class RemoveGroupTests : TestBase
    {
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
    }
}

