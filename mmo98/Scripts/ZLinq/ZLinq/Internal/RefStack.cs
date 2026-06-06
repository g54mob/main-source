using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ZLinq.Internal
{
	internal sealed class RefStack<T> where T : IDisposable
	{
		internal static readonly RefStack<T> DisposeSentinel = new RefStack<T>(0);

		private static volatile int gate = 0;

		private static volatile RefStack<T>? Last = null;

		private RefStack<T>? Prev;

		private T[] array;

		private int size;

		public static RefStack<T> Rent()
		{
			if (Interlocked.CompareExchange(ref gate, 1, 0) == 0)
			{
				if (Last == null)
				{
					gate = 0;
					return new RefStack<T>(4);
				}
				RefStack<T>? last = Last;
				Last = Last.Prev;
				gate = 0;
				return last;
			}
			return new RefStack<T>(4);
		}

		public static void Return(RefStack<T> stack)
		{
			stack.Reset();
			if (Interlocked.CompareExchange(ref gate, 1, 0) == 0)
			{
				stack.Prev = Last;
				Last = stack;
				gate = 0;
			}
		}

		private RefStack(int initialSize)
		{
			array = ((initialSize == 0) ? Array.Empty<T>() : new T[initialSize]);
			size = 0;
		}

		public void Push(T value)
		{
			if (size == array.Length)
			{
				Array.Resize(ref array, array.Length * 2);
			}
			array[size++] = value;
		}

		public void Pop()
		{
			size--;
		}

		public ref T PeekRefOrNullRef()
		{
			if (size == 0)
			{
				return ref Unsafe.NullRef<T>();
			}
			return ref array[size - 1];
		}

		public void Reset()
		{
			for (int i = 0; i < size; i++)
			{
				array[i].Dispose();
			}
			size = 0;
		}
	}
}
