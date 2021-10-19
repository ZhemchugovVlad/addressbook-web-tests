using System;
using System.Collections.Generic;
using System.Text;

namespace WebAdressbookTests
{
    public class GroupData
    {
        public string Name { get; set; }
        public string Header { get; set; } =  "";
        public string Footer { get; set; } = "";

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
    }
}
