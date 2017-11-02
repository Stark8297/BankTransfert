using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankTranfertLibrary
{
    public class CsvWriter
    {
        // Sauvegarde la transaction dans le CSV et appelle le FileLogger en cas d'erreur.
        public void writeTransaction(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
            FileLogger fl = new FileLogger();
            try
            {
                // chemin : BankTranfertLibrary\BankTransfertLibraryTest\bin\Debug\netcoreapp2.0
                var csvTitle = $"transaction_{DateTime.Now.ToString("dd_MM_yy")}.csv";
                string curFile = @".\BankTranfertLibrary\BankTransfertLibraryTest\bin\Debug\netcoreapp2.0\" + csvTitle;              

                if (!File.Exists(curFile))
                {
                    using (StreamWriter sw = File.CreateText(curFile))
                    {
                        sw.WriteLine("Transaction;Amount;From;To");
                    }
                }
                else
                    fl.Handle(Severity.Error, "File " + csvTitle + " does not exist.");


                var line = $"{transactionId};{amount};{fromBankIban};{toBankIban}";
                using (StreamWriter sw = File.AppendText(curFile))
                {
                    sw.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                fl.Handle(Severity.Error, e.ToString());
                throw e;
            }
        }
    }
}
