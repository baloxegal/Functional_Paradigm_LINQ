using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Paradigm_LINQ
{
    class Program
    {
        public delegate int MethodMultiply(int i);
        public delegate void MethodAdd(int i);
        
        private static void Main(string[] args)
        {
            List<int> collection = new List<int>();

            MethodMultiply method_1 = MyClass.MyFunction_1;
                        
            Console.WriteLine(method_1(100));
            Console.WriteLine("=================================");

            MethodMultiply method_2 = (x) => x * 2000;

            Console.WriteLine(method_2(100));
            Console.WriteLine("=================================");

            Console.WriteLine(MyClass.MyFunction_2(100, method_2));
            Console.WriteLine("=================================");

            Console.WriteLine(MyClass.MyFunction_2(100, x => x * 2));
            Console.WriteLine("=================================");

            Func<int, int> func = (x) => x * 2;

            Console.WriteLine(MyClass.MyFunction_3(100, func));
            Console.WriteLine("=================================");

            Console.WriteLine(MyClass.MyFunction_3(100, x => x * 2));
            Console.WriteLine("=================================");

            MethodAdd method_3 = collection.Add;
            
            MethodAdd method_4 = delegate (int i)
            {
                collection.Remove(i);
            };

            method_4 += Console.WriteLine;

            Action<int> action = (x) => collection.Add(x);            

            

            method_1(500);
            method_1(600);
            method_1(700);
            method_1(800);
            method_1(900);
            method_1(1000);

            method_2(600);
            method_2(800);
            method_2(1000);
            Console.WriteLine("=================================");           
            action(100);
            action(200);
            action(300);
            action(400);

            foreach (int a in collection)
            {
                Console.WriteLine(a);
            }
        }
    }

    class MyClass
    {
        public int MyProperty_1 { get; set; } = 100;
        public int MyProperty_2 { get; set; } = 200;

        public MyClass()
        {

        }
        public static int MyFunction_1(int i)
        {
            return i * 20000;
        }
        public static int MyFunction_2(int i, Program.MethodMultiply method)
        {
            return i * method(i);
        }
        public static int MyFunction_3(int i, Func<int, int> func)
        {
            return i * func(i);
        }
    }
}
