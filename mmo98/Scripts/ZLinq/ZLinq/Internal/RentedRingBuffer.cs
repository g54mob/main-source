using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal class RentedRingBuffer<T> : IDisposable
	{
		public T[]? Buffer;

		public readonly int Capacity;

		private int head;

		public int Count;

		public RentedRingBuffer(int capacity)
		{
			Buffer = ArrayPool<T>.Shared.Rent(4);
			Capacity = capacity;
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Enqueue(T item)
		{
			if (head == Buffer.Length && Count != Capacity)
			{
				Expand();
			}
			Buffer[head] = item;
			int num = head + 1;
			head = num % Capacity;
			Count = Math.Min(Count + 1, Capacity);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryDequeue(out T item)
		{
			if (Count == 0)
			{
				item = default(T);
				return false;
			}
			long num = ((long)head - (long)Count + Capacity) % Capacity;
			ref T reference = ref Buffer[num];
			item = reference;
			reference = default(T);
			Count--;
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Expand()
		{
			T[] array = ArrayPool<T>.Shared.Rent(Buffer.Length * 2);
			Span<T> span = Buffer.AsSpan();
			span.CopyTo(array);
			if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
			{
				span.Clear();
			}
			ArrayPool<T>.Shared.Return(Buffer);
			Buffer = array;
		}

		public void Dispose()
		{
			if (Buffer != null)
			{
				if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
				{
					Buffer.AsSpan(0, Count).Clear();
				}
				ArrayPool<T>.Shared.Return(Buffer);
				Buffer = null;
			}
		}
	}
}
