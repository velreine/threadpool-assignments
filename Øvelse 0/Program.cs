using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Øvelse_0
{
    class ThreadPoolDemo    
    {
        static void Main(string[] args)
        {

            // Lav en ny instans af ThreadPoolDemo klassen.
            ThreadPoolDemo tpd = new ThreadPoolDemo();

            for (int i = 0; i < 2; i++)
            {
                // Sæt den nye instans metode 1 og 2 i kø til at blive eksekveret vha. ThreadPool.
                ThreadPool.QueueUserWorkItem(tpd.task1);

                // Da metoderne tager et objekt som parameter og ikke er asynkrone, er deres signatur magen til "delegate void WaitCallback(object state)"
                // Derfor er new WaitCallback redundant.
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
            }

            // Bloker applikation fra at quit før taste tryk.
            Console.Read();

        }

        // Generisk opgave 1
        public void task1(object obj)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }

        // Generisk opgave 2
        public void task2(object obj)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }

    }
}
