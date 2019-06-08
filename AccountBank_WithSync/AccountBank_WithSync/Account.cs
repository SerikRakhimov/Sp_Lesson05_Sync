using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountBank_WithSync
{
    //public class Account
    [Synchronization]
    public class Account : ContextBoundObject
    {
        public string Number;
        public string Depositor;
        public int Summa;

        private object lockObject = new object();

        // поступление/снятие денег на счет
        public void Change(object value)
        {
            //lock (lockObject)
            //{

                Console.WriteLine($"\nПоток ({Thread.CurrentThread.ManagedThreadId}) начал работу.");
                //Thread.Sleep(new Random().Next(500));
                Thread.Sleep(200);
                Console.WriteLine($"Поток ({Thread.CurrentThread.ManagedThreadId}), Сумма до изменения = {Summa}, изменение = {(int)value}");
                Summa += (int)value;
                Console.WriteLine($"Поток ({Thread.CurrentThread.ManagedThreadId}) закончил работу, Сумма после изменения = {Summa}");
            //}
        }

        public void PrintInfo(string info)
        {
            Console.WriteLine($"\n{info}:");
            Console.WriteLine($"Информация по счету № {Number}, вкладчик = {Depositor}");
            Console.WriteLine($"Остаток суммы на счете = {Summa}");
        }

    }
}
