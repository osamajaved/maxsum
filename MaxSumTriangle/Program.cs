using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSumTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Input.ReadLines(@"F:\Input.txt").Result;
            
            var result = ProcessTriangle.ProcessInput(list);
            var path = string.Join(",", result.Select(n => n.ToString()).ToArray());

            Console.WriteLine("Max sum: " + result.Sum(x => x));
            Console.WriteLine("Path:" + path);

            Console.ReadLine();
        }
    }

   

    

}
