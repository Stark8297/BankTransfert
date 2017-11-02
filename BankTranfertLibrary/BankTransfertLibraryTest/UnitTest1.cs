using BankTranfertLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTransfertLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var bankTransfert = new BankTransfert();
        //    bankTransfert.Transfert(1, 12.2m, "4514561", "8546129856");
        //}

        [TestMethod]
        public void TestTempsTransaction()
        {
            // Arrange
            var bankTransfert = new BankTransfert();          
            // Stopwatch pour mesurer le temps d'exécution
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Act
            bankTransfert.EmulateTransfert(1, 12.2m, "4514561", "8546129856"); e
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            // Assert
            Assert.IsTrue(elapsedMs > 5000, "La transaction n'a pas pris plus de 5 secondes.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullIBAN()
        {
            // Arrange
            var bankTransfert = new BankTransfert();
            // Act
            bankTransfert.Transfert(1, 12.2m, " ", "");
            //Assert dans le tag: [ExpectedException(typeof(ArgumentNullException))]
        }
    }
}