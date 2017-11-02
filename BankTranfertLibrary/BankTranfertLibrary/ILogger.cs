using System;
using System.Collections.Generic;
using System.Text;

namespace BankTranfertLibrary
{
    interface ILogger
    {
        void Handle(Severity sev, string error);
    }
}
