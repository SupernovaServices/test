using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    //https://csharp-video-tutorials.blogspot.com/2016/10/async-and-await-in-c-example.html
    class Program
    {
        static  void Main(string[] args)
        {
            Abc();

            Console.WriteLine("Inside main thread id: " + Thread.CurrentThread.ManagedThreadId);
            while (true) ;
            Console.ReadKey();
        }

        private async static void Abc()
        {
            Task<int> task = new Task<int>(MyFunction);
            task.Start();

            Console.WriteLine("doing other task...");
            //   Thread.Sleep(10000);

            int res = await task;

            Console.WriteLine("Result us: " + res + ", obtain @ thread: "+ Thread.CurrentThread.ManagedThreadId);
        }

        static int MyFunction()
        {
            Console.WriteLine("Inside Myfunction, doing long task... @ thread: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);

            Random r = new Random();

            Console.WriteLine("Long task finished, now returning result...@ thread: " + Thread.CurrentThread.ManagedThreadId);
            return r.Next(1, 100);
        }
    }
}
