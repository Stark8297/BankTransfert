﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankTranfertLibrary
{
    public enum Severity
    {
        Info, 
        Warning,
        Error,
    }
    public class Logger : ILogger
    {
        public void Handle(Severity severity, string message)
        {
            Console.WriteLine($"{severity.ToString()} - {message}");
        }
    }
}
