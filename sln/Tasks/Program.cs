using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("frist");
            Task t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("I am the first task");
            });

            var t2 = t.ContinueWith(delegate
            {
                //simulate compute intensive
                Thread.Sleep(10000);
                return "Devlifestyle";
            });

            //block1
            string result = t2.Result;
            Console.WriteLine("result of second task is: " + result);
            //end block1

            //block2
         var t3=t2.ContinueWith(delegate
                {
                    Console.WriteLine("Here i am");
                    return "Devlifestyle222";
                });
            Console.WriteLine(t3.Result+"Waiting my task");
            //end block2

            Console.ReadLine();

        }
    }
}
