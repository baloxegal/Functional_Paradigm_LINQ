using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Paradigm_LINQ
{
    class Program
    {
        delegate void MethodAdd(int i);

        static void Main(string[] args)
        {
            var collection = new List<int>();

            MethodAdd method_1 = collection.Add;

            Action<int> action = (int i) =>
            {
                collection.Add(i);
            };

            MethodAdd method_2 = delegate (int i)
             {
                 collection.Add(i);
             };

            method_1(500);
            method_1(600);
            method_1(700);
            method_1(800);

            method_2(6);
            method_2(20);
            method_2(30);
            method_2(50);

            action(100);
            action(200);
            action(300);
            action(400);

            foreach (var a in collection)
                Console.WriteLine(a);
        }
    }
}
