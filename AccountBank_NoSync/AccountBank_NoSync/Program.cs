using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountBank_NoSync
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 150;
            Account account = new Account()
            {
                Number = "KZ01020304050607080910",
                Depositor = "Иванов И.И.",
                Summa = 0
            };

            account.PrintInfo("При создании счета");

            var threads_plus = new Thread[n];

            for (int i = 0; i < threads_plus.Length; i++)
            {
                threads_plus[i] = new Thread(account.Change);
            }

            foreach (var thread in threads_plus)
            {
                thread.Start(1000);
            }

            account.PrintInfo("После всех зачислений суммм");

            var threads_minus = new Thread[n];

            for (int i = 0; i < threads_minus.Length; i++)
            {
                threads_minus[i] = new Thread(account.Change);
            }

            foreach (var thread in threads_minus)
            {
                thread.Start(-1000);
            }


            account.PrintInfo("После всех операций");

            Console.ReadLine();
        }
    }
}
