using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BankTranfertLibrary
{
    public class BankTransfert
    {
        // Logger
        FileLogger log = new FileLogger();
        // Sauvegarde transaction en .csv
        CsvWriter csv = new CsvWriter();

        // Méthode de transfert
        public bool Transfert(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
            // Transfert non effectué par défault.
            bool hasTransfered = false;

            try
            {
                // Test des paramètres IBAN
                string.IsNullOrEmpty(fromBankIban);
                string.IsNullOrEmpty(toBankIban);

                // On effectue le transfert
                hasTransfered = EmulateTransfert(amount, fromBankIban, toBankIban);
                // On appelle la sauvegarde de transaction
                csv.writeTransaction(transactionId, amount, fromBankIban, toBankIban);
            }
            catch (ArgumentNullException e) when ((string.IsNullOrEmpty(fromBankIban)) || (string.IsNullOrEmpty(toBankIban)))
            {
                log.Handle(Severity.Error, e.ToString());
                throw e;
            }
            catch (InvalidOperationException e) when (!hasTransfered)
            {
                log.Handle(Severity.Error, e.ToString());
                throw e;
            }
            catch (Exception e)
            {
                log.Handle(Severity.Error, e.ToString());
                throw e;
            }
            return hasTransfered;
        }

        /// <summary>
        /// Cette méthode émule une transfert bancaire vers un tiers
        /// Elle se compose d'un timeout et renvoie true
        /// Tester le temps d'execution de la méthod transfert car elle doit toujours être inférieur à 5sec
        /// </summary>
        /// <returns></returns>
        public bool EmulateTransfert(decimal amount, string fromBankIban, string toBankIban)
        {
            System.Threading.Thread.Sleep((int)TimeSpan.FromSeconds(4).TotalMilliseconds);
            return true;
        }
    }
}
