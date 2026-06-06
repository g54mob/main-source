using System;
using Unity.Collections;

namespace ZLinq.Linq
{
	public struct FromFixedList32Bytes<T> : IValueEnumerator<T>, IDisposable where T : unmanaged
	{
		private FixedList32Bytes<T> source;

		private int index;

		public FromFixedList32Bytes(FixedList32Bytes<T> source)
		{
			this.source = source;
			index = 0;
		}

		public void Dispose()
		{
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out T current)
		{
			if ((uint)index < (uint)source.Length)
			{
				current = source[index++];
				return true;
			}
			current = default(T);
			return false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = source.Length;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}
	}
}
