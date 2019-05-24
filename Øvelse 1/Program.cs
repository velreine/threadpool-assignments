using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Øvelse_1
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
