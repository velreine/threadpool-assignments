using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Øvelse_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //ThreadPool.QueueUserWorkItem(Process);
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Thread Pooling Execution");
            watch.Start();
            ProcessWithThreadPoolMethod();
            watch.Stop();

            Console.WriteLine($"Time consumed by ProcessWithThreadPoolMethod: {watch.ElapsedMilliseconds}ms");
            watch.Reset();

            Console.WriteLine("Thread Execution");
            watch.Start();
            ProcessWithThreadMethod();
            watch.Stop();
            Console.WriteLine($"Time consumed by ProcessWithThreadMethod: {watch.ElapsedMilliseconds}ms");

            Console.ReadKey();


        }

        // Process metoden skal tage et state object ind, for at vi kan passe metoden til ThreadPool.QueueUserWorkItem();
        static void Process(object state)
        {
            // Tidsforbruget er meget ens til Øvelse 1 når den indre løkke ikke er på.
            for (int i = 0; i < 10000; i++)
            {
                // Tidsforbruget stiger markant når denne indre løkke er sat til for ProcessWithThreadMethod,
                // ProcessWithThreadPool eksekvere stadig på få millisekunder.
                for (int j = 0; j < 10000; j++)
                {
                    
                }
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
    }
}
