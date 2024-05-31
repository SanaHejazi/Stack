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

  public void pre_to_post(string expression)
  {
   String[] Bits;
   String Result = null;
   MyStack<String> myStack = new MyStack<String>();
   Bits = expression.Split(' ');
   Array.Reverse(Bits);
   foreach (String elements in Bits)
   {
    if (int.TryParse(elements, out int result))
    {
     myStack.Push(Convert.ToString(result));
    }
    else
    {
     String var1 = myStack.Pop();
     String var2 = myStack.Pop();


     switch (elements)
     {
      case "+":
       Result = var1 + " " + var2 + " " + "+";
       break;
      case "-":
       Result = var1 + " " + var2 + " " + "-";
       break;
      case "*":
       Result = var1 + " " + var2 + " " + "*";
       break;
      case "/":
       Result = var1 + " " + var2 + " " + "/";
       break;
      default: throw new Exception("This Opperand Is Nashenakhte :)");
     }
     myStack.Push(Result);
    }

   }

   Console.WriteLine(myStack.Pop());
  }

  public void inix_to_postfix(string expression)
  {
   String[] Bits;
   String Result = null;
   MyStack<String> myStack = new MyStack<String>();
   Bits = expression.Split(' ');
   int sum = 0;
   foreach (String elements in Bits)
   {
    if (int.TryParse(elements, out int result))
    {
     Result = Result + elements;
    }
    else
    {
     if (elements == ")")
     {
      while (myStack.Peak() != "(")
      {
       Result = Result + myStack.Pop();
      }
      myStack.Pop();
     }
     else if (elements == "(")
     {
      myStack.Push(elements);
     }
     else
     {
      //Here
      if (myStack.IsEmpty())
      {
       myStack.Push(elements);
      }
      else
      {
       switch (myStack.Peak())
       {
        case "^":
         switch (elements)
         {
          case "^":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "*":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "/":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "+":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "-":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
         }
         break;
        case "+":
         switch (elements)
         {
          case "^":
           myStack.Push(elements);
           break;
          case "*":
           myStack.Push(elements);
           break;
          case "/":
           myStack.Push(elements);
           break;
          case "+":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "-":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
         }
         break;
        case "-":
         switch (elements)
         {
          case "^":
           myStack.Push(elements);
           break;
          case "*":
           myStack.Push(elements);
           break;
          case "/":
           myStack.Push(elements);
           break;
          case "+":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "-":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
         }
         break;
        case "*":
         switch (elements)
         {
          case "^":
           myStack.Push(elements);
           break;
          case "+":
           myStack.Push(elements);
           break;
          case "-":
           myStack.Push(elements);
           break;
          case "*":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "/":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
         }
         break;
        case "/":
         switch (elements)
         {
          case "^":
           myStack.Push(elements);
           break;
          case "+":
           myStack.Push(elements);
           break;
          case "-":
           myStack.Push(elements);
           break;
          case "*":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
          case "/":
           Result = Result + myStack.Pop();
           myStack.Push(elements);
           break;
         }
         break;
        default:
         myStack.Push(elements);
         break;
       }
      }
     }

    }
   }
   if (myStack.IsEmpty())
   {
    Console.WriteLine(Result);
   }
   else
   {
    do
    {
     Result = Result + myStack.Pop();
    } while (!myStack.IsEmpty());
    Console.WriteLine(Result);
   }

  }

  public void Daily_Temperatures(String ST)
  {
   String[] MyArray = ST.Split(',');
   Array.Reverse(MyArray);

   MyStack<int> myStack = new MyStack<int>();
   for (int i = 0; i < MyArray.Length; i++)
   {
    myStack.Push(Convert.ToInt32(MyArray[i]));
   }
   int counter = 0;
   Console.Write("[");
   while (!myStack.IsEmpty())
   {
    counter++;
    int Bigger = 0;
    int index = 0;
    int count = 0;
    int x = myStack.Pop();
    while (!myStack.IsEmpty())
    {
     count++;
     if (x < myStack.Pop())
     {
      index = count;
      break;
     }

    }
    Console.Write(index + " ");

    myStack = new MyStack<int>();
    for (int a = 0; a < MyArray.Length; a++)
    {
     myStack.Push(Convert.ToInt32(MyArray[a]));
    }
    for (int m = 0; m < counter; m++)
    {
     myStack.Pop();
    }
   }
   Console.Write("]");
  }

  public void longest_valid_parentheses(String input)
  {
   char[] chars = new char[input.Length];
   MyStack<String> stack = new MyStack<String>();
   int i = 0;
   foreach (char ch in input)
   {
    chars[i] = ch;
    i++;
   }
   int j = 0;
   while (j < chars.Length)
   {
    stack.Push(Convert.ToString(input[j]));
    j++;
   }
   int count = 0;
   while (stack.Size() != 0)
   {
    if (stack.Pop() == ")")
    {
     while (stack.Size() > 0)
     {
      if (stack.Pop() == "(")
      {
       count = count + 2;
      }
     }
    }
   }

   Console.WriteLine(count);
  }
 }
}

