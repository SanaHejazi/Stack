using System;

namespace Stack
{
 internal class Program
 {
  static void Main(string[] args)
  {
   //Testing All Functions...

   MyStack<int> myStack = new MyStack<int>();
   myStack.Push(100);
   myStack.Push(20);
   myStack.Push(10);
   Console.WriteLine(myStack.Max());
   Console.WriteLine(myStack.Peak());
   Console.WriteLine(myStack.Pop());
   Console.WriteLine(myStack.Pop());
   myStack.Revesr_String("hello");
   myStack.EvaluatePostfix("4 5 2 + * 5 +");
   myStack.SymbolCheck("{[()]}");
   myStack.pre_to_post("* + 3 4 2");
   myStack.Daily_Temperatures("73, 74, 75, 71, 69, 72, 76, 73");
   Console.WriteLine();
   myStack.longest_valid_parentheses(")()())");
   //---------------------------------------------
   Console.WriteLine();
   MyStack<int> myStack2 = new MyStack<int>();
   myStack2.Push(3);
   myStack2.Push(1);
   myStack2.Push(4);
   SortedStack<int> sortedStack = new SortedStack<int>(myStack2);
   Console.WriteLine(sortedStack.Pop());
   Console.WriteLine(sortedStack.Pop());
   Console.WriteLine(sortedStack.Pop());
   //-----------------------------------------------
   MyStack<int> mystack3 = new MyStack<int>();
   mystack3.inix_to_postfix("3 + 4 * 2 / ( 1 - 5 )");
   //-----------------------------------------------



   Console.ReadKey();
  }
 }
}
