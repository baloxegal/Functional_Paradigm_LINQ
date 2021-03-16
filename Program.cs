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

            MethodAdd method_5 = i => collection.Remove(i);
            
            method_4 += Console.WriteLine;

            Action<int> action = x => collection.Add(x);
            Action<int> action_1 = collection.Add;
            Action<int> action_2 = delegate (int x)
            {
                collection.Add(x);
            };
            Action action_3 = delegate ()
            {
                Console.WriteLine("gsdajhdbajk");
            };

            method_3(500);
            method_3(600);
            method_3(700);
            method_3(800);
            method_3(900);
            method_3(1000);

            method_4(600);
            method_4(800);
            method_4(1000);

            Console.WriteLine("=================================");           
            
            action(100);
            action(200);
            action(300);
            action(400);

            Predicate<int> func_1 = delegate (int i)
            {
                return collection.Contains(i);
            };

            Predicate<int> func_2 = i => collection.Contains(i);

            Console.WriteLine(func_1(500));
            Console.WriteLine("=================================");
            foreach (int a in collection)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("=================================");
            var newCollection_1 = collection.Where(x => x > 700);
            foreach(var z in newCollection_1)
                Console.WriteLine(z);
            Console.WriteLine("=================================");
            var newCollection_2 = collection.Take(4);
            foreach (var z in newCollection_2)
                Console.WriteLine(z);
            Console.WriteLine("=================================");
            var newCollection_3 = collection.FirstOrDefault();
            Console.WriteLine(newCollection_3);
            Console.WriteLine("=================================");

            List<MyClass> myClassList = new List<MyClass>();
            myClassList.Add(new MyClass { MyProperty_2 = 100 });
            myClassList.Add(new MyClass { MyProperty_2 = 200 });
            myClassList.Add(new MyClass { MyProperty_2 = 300 });
            myClassList.Add(new MyClass { MyProperty_2 = 400 });
            myClassList.Add(new MyClass { MyProperty_2 = 500 });
            myClassList.Add(new MyClass { MyProperty_2 = 600 });

            var newCollection_4 = myClassList.Where(x => x.MyProperty_2 > 100).Select(x => x.MyProperty_2);
            foreach (var z in newCollection_4)
                Console.WriteLine(z);
            Console.WriteLine("=================================");
            var newCollection_5 = myClassList.Reverse<MyClass>();
            foreach (var z in newCollection_5)
                Console.WriteLine(z.MyProperty_2);
            Console.WriteLine("=================================");
            var newCollection_6 = myClassList.SkipWhile(x => x.MyProperty_2 <= 300).Select(x => x.MyProperty_2);
            foreach (var z in newCollection_6)
                Console.WriteLine(z);
            Console.WriteLine("=================================");
        }
    }

    class MyClass
    {
        public int MyProperty_1 { get; set; } = 100;
        public int MyProperty_2 { get; set; }

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
