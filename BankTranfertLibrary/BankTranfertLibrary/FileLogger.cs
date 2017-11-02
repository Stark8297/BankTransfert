using System;
using System.Collections.Generic;
using System.Text;

namespace BankTranfertLibrary
{
    public class FileLogger : ILogger
    {
        public void Handle(Severity sev, string error)
        {
            System.IO.File.WriteAllText(@"\", error);
        }
    }
}
