using System;
using System.Collections.Generic;
using System.Linq;

namespace StackCalculator
{
    class Program
    {
        public static Stack<UInt10> MyStack = new();
        public static bool Run = true;

        static void Main(string[] args)
        {
            while (Run)
            {
                string input = Console.ReadLine();

                if (input.StartsWith("push", StringComparison.CurrentCultureIgnoreCase))
                    Push((UInt10)input[5..]);
                else
                {
                    switch (input.Replace(" ", string.Empty).ToLower())
                    {
                        case "pop":
                            Pop();
                            break;

                        case "add":
                            Add();
                            break;

                        case "sub":
                            Sub();
                            break;

                        case "quit":
                            Quit();
                            break;

                        default:
                            Console.WriteLine("Such command does not exist!");
                            break;
                    }
                }
            }
        }

        static void Push(UInt10 value)
        {
            if (MyStack.Count >= 5)
                Console.WriteLine("Value not inserted. Stack limit reached!");
            else
                MyStack.Push(value);
        }

        static UInt10 Pop()
        {
            return MyStack.Count > 0 ? MyStack.Pop() : 0;
        }

        static void Add()
        {
            if (MyStack.Count >= 2)
            {
                UInt10 result = Pop() + Pop();
                Push(result);
                Console.WriteLine($"Result: {MyStack.Peek()}");
            }
            else
                Console.WriteLine("Not enough values inserted!");
        }

        static void Sub()
        {
            if (MyStack.Count >= 2)
            {
                UInt10 result = Pop() - Pop();
                Push(result);
                Console.WriteLine($"Result: {MyStack.Peek()}");
            }
            else
                Console.WriteLine("Not enough values inserted!");
        }

        static void Quit()
        {
            Console.WriteLine("Do You really want to quit? y | n");

            if (Console.ReadLine().StartsWith("y", StringComparison.CurrentCultureIgnoreCase))
                Run = false;
        }
    }
}
