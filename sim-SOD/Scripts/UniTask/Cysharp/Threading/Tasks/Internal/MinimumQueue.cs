using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks.Internal
{
	internal class MinimumQueue<T>
	{
		private T[] array;

		private int head;

		private int tail;

		private int size;

		public int Count
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0;
			}
		}

		public MinimumQueue(int capacity)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Enqueue(T item)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Dequeue()
		{
			return default(T);
		}

		private void Grow()
		{
		}

		private void SetCapacity(int capacity)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void MoveNext(ref int index)
		{
		}

		private void ThrowForEmptyQueue()
		{
		}
	}
}
