using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> IntegerList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // using query syntax of LINQ fetch all the numbers which are greater than 6.
            // LINQ Query has 3 parts - 
            // 1. Initialization
            // 2. Condition
            // 3. Selection

            Console.WriteLine("--- First way to write LINQ Query - Query Syntax--- ");

            var greaterThan6List = from obj in IntegerList where obj > 6 select obj; // this is called LINQ Query


            foreach(var item1 in greaterThan6List)
            {
                Console.WriteLine(item1);
            }

            Console.WriteLine("--- using GetEnumerator() --- ");


            var item = greaterThan6List.GetEnumerator();

            while (item.MoveNext())
            {
                Console.WriteLine(item.Current);
            }

            Console.WriteLine("--- Second way to write LINQ Query - Method Syntax--- ");

            var greaterThan5List = IntegerList.Where(x => x > 5).ToList();

            foreach (var item1 in greaterThan5List)
            {
                Console.WriteLine(item1);
            }

            Console.WriteLine("--- Third way to write LINQ Query - Mixed Syntax--- ");

            var SumofGreaterThan7List = (from obj in IntegerList where obj > 7 select obj).Sum();

            Console.WriteLine("sum of greater than 7 numbers from the list: {0}", SumofGreaterThan7List);

            Console.WriteLine("------------------LINQ OPERATIONS----------------");

            Console.WriteLine();

            MovieBusinessLogic mbl = new MovieBusinessLogic();
            mbl.LINQMethodsOpeations();


            Console.ReadKey();

        }
    }
}
