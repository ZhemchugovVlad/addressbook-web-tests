using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa", "bbb", "ccc");
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
