using System;

namespace Stack
{
 internal class Program
 {
  static void Main(string[] args)
  {
   MyStack<int> myStack = new MyStack<int>();
   myStack.Push(100);
   myStack.Push(20);
   myStack.Push(10);
   Console.WriteLine(myStack.Max());
   Console.WriteLine(myStack.Peak());
   Console.WriteLine(myStack.Pop());
   Console.WriteLine(myStack.Pop());
   myStack.Revesr_String("hello");
   myStack.EvaluatePostfix("3 4 + 2 * 7 /");
   myStack.SymbolCheck("{[()]}");

   Console.ReadKey();
  }
 }
}
