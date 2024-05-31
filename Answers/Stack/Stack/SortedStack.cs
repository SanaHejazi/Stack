using System;

namespace Stack
{
 internal class SortedStack<T>
 {
  MyStack<int> MySortedStack = new MyStack<int>();
  int[] array;

  public SortedStack(MyStack<int> myStack)
  {
   int i = 0;
   array = new int[myStack.Size()];
   while (!myStack.IsEmpty())
   {
    array[i] = Convert.ToInt32(myStack.Pop());
    i++;
   }
   for (int m = 0; m < array.Length; m++)
   {
    int max = 0;
    int currentindex = 0;
    for (int j = 0; j < array.Length; j++)
    {
     if (array[j] > max)
     {
      max = array[j];
      currentindex = j;
     }
    }
    array[currentindex] = 0;
    MySortedStack.Push(max);
   }
  }

  public int Pop()
  {
   return MySortedStack.Pop();
  }

 }
}

