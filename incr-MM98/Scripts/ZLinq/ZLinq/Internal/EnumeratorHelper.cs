using System;

namespace ZLinq.Internal
{
	public static class EnumeratorHelper
	{
		public static bool TryGetSliceRange(int sourceLength, Index offset, int destinationLength, out int start, out int count)
		{
			int offset2 = offset.GetOffset(sourceLength);
			if ((uint)offset2 < sourceLength)
			{
				start = offset2;
				count = Math.Min(sourceLength - offset2, destinationLength);
				return true;
			}
			start = 0;
			count = 0;
			return false;
		}

		public static bool TryGetSlice<T>(ReadOnlySpan<T> source, Index offset, int destinationLength, out ReadOnlySpan<T> slice)
		{
			int offset2 = offset.GetOffset(source.Length);
			if ((uint)offset2 < source.Length)
			{
				int length = Math.Min(source.Length - offset2, destinationLength);
				slice = source.Slice(offset2, length);
				return true;
			}
			slice = default(ReadOnlySpan<T>);
			return false;
		}

		public static bool TryConsumeGetAt<TEnumerator, T>(ref TEnumerator enumerator, Index offset, out T value) where TEnumerator : struct, IValueEnumerator<T>
		{
			if (offset.IsFromEnd)
			{
				if (offset.Value == 1)
				{
					return TryConsumeGetLast<TEnumerator, T>(ref enumerator, out value);
				}
				return TryConsumeGetFromLast<TEnumerator, T>(ref enumerator, offset.Value, out value);
			}
			if (offset.Value == 0)
			{
				return TryConsumeGetFirst<TEnumerator, T>(ref enumerator, out value);
			}
			return TryConsumeGetAt<TEnumerator, T>(ref enumerator, offset.Value, out value);
		}

		private static bool TryConsumeGetFirst<TEnumerator, T>(ref TEnumerator enumerator, out T first) where TEnumerator : struct, IValueEnumerator<T>
		{
			if (enumerator.TryGetNext(out T current))
			{
				first = current;
				return true;
			}
			first = default(T);
			return false;
		}

		private static bool TryConsumeGetAt<TEnumerator, T>(ref TEnumerator enumerator, int index, out T value) where TEnumerator : struct, IValueEnumerator<T>
		{
			int num = 0;
			T current;
			while (enumerator.TryGetNext(out current))
			{
				if (num++ == index)
				{
					value = current;
					return true;
				}
			}
			value = default(T);
			return false;
		}

		private static bool TryConsumeGetLast<TEnumerator, T>(ref TEnumerator enumerator, out T last) where TEnumerator : struct, IValueEnumerator<T>
		{
			if (enumerator.TryGetNext(out T current))
			{
				T current2;
				while (enumerator.TryGetNext(out current2))
				{
					current = current2;
				}
				last = current;
				return true;
			}
			last = default(T);
			return false;
		}

		private static bool TryConsumeGetFromLast<TEnumerator, T>(ref TEnumerator enumerator, int indexFromEnd, out T value) where TEnumerator : struct, IValueEnumerator<T>
		{
			if (indexFromEnd == 0)
			{
				value = default(T);
				return false;
			}
			using ValueQueue<T> valueQueue = new ValueQueue<T>(4);
			T current;
			while (enumerator.TryGetNext(out current))
			{
				if (valueQueue.Count == indexFromEnd)
				{
					valueQueue.Dequeue();
				}
				valueQueue.Enqueue(current);
			}
			if (valueQueue.Count == indexFromEnd)
			{
				value = valueQueue.Dequeue();
				return true;
			}
			value = default(T);
			return false;
		}
	}
}
