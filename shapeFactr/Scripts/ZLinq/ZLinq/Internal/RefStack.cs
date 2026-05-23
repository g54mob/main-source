using System;

namespace ZLinq.Internal
{
	internal sealed class RefStack<T> where T : notnull, IDisposable
	{
		internal static readonly RefStack<T> DisposeSentinel;

		private static int gate;

		private static RefStack<T>? Last;

		private RefStack<T>? Prev;

		private T[] array;

		private int size;

		public static RefStack<T> Rent()
		{
			return null;
		}

		public static void Return(RefStack<T> stack)
		{
		}

		private RefStack(int initialSize)
		{
		}

		public void Push(T value)
		{
		}

		public void Pop()
		{
		}

		public ref T PeekRefOrNullRef()
		{
			throw null;
		}

		public void Reset()
		{
		}
	}
}
