using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Paradigm_LINQ
{
    class Program
    {
        delegate void MethodAdd (int i);
        static void Main(string[] args)
        {
            var c = new List<int>();           
            MethodAdd method = delegate (int i)
            {
                c.Add(i);
            };
            MethodAdd method1 = c.Add;
            
            Action<int> action = (int i) =>
            {
                c.Add(i);
            };
            

            method(6);
            method(20);
            method(30);
            method(50);

            action(100);
            action(200);
            action(300);
            action(400);

            method1(500);
            method1(600);
            method1(700);
            method1(800);


            foreach (var a in c)
                Console.WriteLine(a);
        }        
    }
}
