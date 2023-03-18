using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        public int Capacity { get; }

        T[] stack;

        public Stack(int stackSize = 100)
        {
            if (stackSize < 0)
                throw new ArgumentException("Емкость стека имеет отрицательное значение, чего не должно быть");

            Capacity = stackSize;
            stack = new T[stackSize];
        }

        public void Push(T stackValues)
        {
            if (Count >= Capacity)
                throw new InvalidOperationException("Превышена емкость стека");

            stack[Count] = stackValues;
            Count = Count + 1;
        }

        public T Top()
        {
            if (IsEmpty()) 
                throw new InvalidOperationException("В стеке нет элементов");

            return stack[Count - 1];
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("В стеке нет элементов");

            Count = Count - 1;
            return stack[Count];
        }

        public bool IsEmpty()
        {
            return Count == 0 ? true : false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
