using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Øvelse_3
{
    class Program
    {
        private static readonly Random rng = new Random();

        static void Main(string[] args)
        {

            ThreadPool.QueueUserWorkItem(WorkerMethod);
            ThreadPool.QueueUserWorkItem(WorkerMethod);
            ThreadPool.QueueUserWorkItem(WorkerMethod);
            ThreadPool.QueueUserWorkItem(WorkerMethod);


            Console.ReadKey();


        }

        private static void WorkerMethod(object stateObj)
        {
            Thread t = Thread.CurrentThread;
            t.Name = Environment.CurrentManagedThreadId.ToString();

            switch (rng.Next(1, 4))
            {
                case 1:
                    t.Priority = ThreadPriority.Highest;
                    t.IsBackground = true;
                    break;
                case 2:
                    t.Priority = ThreadPriority.AboveNormal;
                    t.IsBackground = false;
                    break;
                case 3:
                    t.Priority = ThreadPriority.Normal;
                    t.IsBackground = true;
                    break;
                case 4:
                    t.Priority = ThreadPriority.Lowest;
                    t.IsBackground = false;
                    break;
            }

            /**
             *          [Method]                [Beskrivelse]
             *          
             *          Thread.Start            Starts the thread.
             *          Thread.Sleep(x)         Sleeps the thread for x milliseconds.
             *          Thread.Suspend          Places the thread in suspended mode. (depecrated)
             *          Thread.Resume           Resumes a suspended thread. (deprecated)
             *          Thread.Abort            Raises an ThreadAbortException on the invoking(calling) thread.
             *          Thread.Join             Blocks the calling thread, untill the referenced thread has terminated.
             *                                  ^Invoking Thread.Join when running in the same thread will cause the thread to wait for itself and deadlock.
             */
             
            //A background thread will be terminated when all foreground threads are finished.
            //A Foreground thread keeps the process running until it is finished.
            Console.WriteLine($"[{t.Name}]: IsAlive {t.IsAlive}, IsBackground {t.IsBackground}, Priority {t.Priority.ToString()}");
        }


    }
}
