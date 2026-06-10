using System;
using System.Collections;
using System.Collections.Generic;

namespace NSMedieval.Utils.Pool.Janitors
{
	public struct PooledStack<T> : IDisposable, IEnumerable<T>, IEnumerable
	{
		private readonly Stack<T> stack;

		public int Count => stack.Count;

		public PooledStack(Stack<T> stack)
		{
			this.stack = stack;
		}

		public void Dispose()
		{
			StackPool<T>.Return(stack);
		}

		public Stack<T>.Enumerator GetEnumerator()
		{
			return stack.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return stack.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return stack.GetEnumerator();
		}

		public void Push(T item)
		{
			stack.Push(item);
		}

		public T Peek()
		{
			return stack.Peek();
		}

		public T Pop()
		{
			return stack.Pop();
		}

		public void Clear()
		{
			stack.Clear();
		}
	}
}
