using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
 internal class MyStack<T>
 {
  LinkedList<T> mylist;
  public MyStack()
  {
   mylist = new LinkedList<T>();
  }




  public void Push(T data)
  {
   mylist.AddFirst(data);
  }
  public T Pop()
  {
   if (mylist.Count == 0)
   {
    throw new Exception("Stack Is Empty");
   }
   else
   {
    LinkedListNode<T> node = new LinkedListNode<T>(mylist.First());
    mylist.RemoveFirst();
    return node.Value;
   }
  }
  public T Peak()
  {
   if (mylist.Count == 0)
   {
    throw new Exception("Stack Is Empty");
   }
   else
   {
    return mylist.First();
   }
  }
  public bool IsEmpty()
  {
   return (mylist.Count == 0);
  }
  public int Size()
  {
   return mylist.Count;
  }
  public T Max()
  {
   return mylist.Max();
  }

  public void Revesr_String(String Word)
  {
   MyStack<char> myStack = new MyStack<char>();
   foreach (char c in Word)
   {
    myStack.Push(c);
   }

   while (!myStack.IsEmpty())
   {
    Console.Write(myStack.Pop() + " ");
   }
  }


  public void EvaluatePostfix(string expression)
  {
   String[] Bits;
   MyStack<int> myStack = new MyStack<int>();
   Bits = expression.Split(' ');
   int sum = 0;
   foreach (String elements in Bits)
   {
    if (int.TryParse(elements, out int result))
    {
     myStack.Push(result);
    }
    else
    {
     int var1 = myStack.Pop();
     int var2 = myStack.Pop();


     switch (elements)
     {
      case "+":
       sum = var1 + var2;
       break;
      case "-":
       sum = var1 - var2;
       break;
      case "*":
       sum = var1 * var2;
       break;
      case "/":
       sum = var2 / var1;
       break;
      default: throw new Exception("This Opperand Is Nashenakhte :)");
     }
     myStack.Push(sum);
    }

   }

   Console.WriteLine("\n" + myStack.Pop());
  }

  public bool SymbolCheck(string expression)
  {
   int i;
   int Index = 0;
   bool validator = false;
   char[] Bits;
   MyStack<char> myStack = new MyStack<char>();
   Bits = expression.ToCharArray();
   if (Bits.Length % 2 != 0)
   {
    Console.WriteLine("False");
    return false;
   }
   int Border = Bits.Length / 2;
   for (i = 0; i < Border; i++)
   {
    myStack.Push(Bits[i]);
   }

   for (int j = i; j < Bits.Length; j++)
   {
    switch (myStack.Pop())
    {
     case '(':
      if (Bits[i++] == ')')
      {
       validator = true;
      }
      else
      {
       validator = false;
      }
      break;

     case ')':
      if (Bits[i++] == '(')
      {
       validator = true;
      }
      else
      {
       validator = false;
      }
      break;

     case '[':
      if (Bits[i++] == ']')
      {
       validator = true;
      }
      else
      {
       validator = false;
      }
      break;

     case ']':
      if (Bits[i++] == '[')
      {
       validator = true;
      }
      else
      {
       validator = false;
      }
      break;

     case '{':
      if (Bits[i++] == '}')
      {
       validator = true;
      }
      else
      {
       validator = false;
      }
      break;

     case '}':
      if (Bits[i++] == '{')
      {
       validator = true;
      }
      else
      {
       validator = false;
      }
      break;

     default:
      throw new Exception("One Of Symbol is nashenakhte");
      break;
    }
   }





   if (validator)
   {
    Console.WriteLine("True");
    return true;
   }
   else
   {
    Console.WriteLine("False");
    return false;
   }

  }
 }
}
