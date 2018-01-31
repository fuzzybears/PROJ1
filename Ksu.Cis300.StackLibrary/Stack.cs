using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Frank Hatcher
/// </summary>
namespace Ksu.Cis300.StackLibrary
{
    /// <summary>
    /// Stack class of an undefined type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        private T[]_elements = new T[5];
        public int Count { get; private set; }

        public int Capacity { get => _elements.Length; }
        /// <summary>
        /// Add a new item to the stack
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
        if (_elements.Length == Count)
            {
                T[] newElements = new T[Capacity * 2];
                _elements.CopyTo(newElements, 0);
                _elements = newElements;
            }
            _elements[Count] = x;
            Count++;
        }
        /// <summary>
        /// If there is nothing in the stack throw an error, otherwise return the top element in the stack
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
            {
                    throw new InvalidOperationException();


               
            }
                return _elements[Count - 1];

            }
        public T Pop()
        {
            T temp = Peek();


            Count--;
            _elements[Count] = default(T);
                return temp;

        }
        /// <summary>
        /// Clear the Stack
        /// </summary>
        public void Clear()
        {
            Count = 0;
            T[] newArray = new T[Capacity];
            _elements = newArray;
        }
    }
    
    
}
