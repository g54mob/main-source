using System;
using Unity.Collections;

namespace ZLinq.Linq
{
	public struct FromFixedList4096Bytes<T> : IValueEnumerator<T>, IDisposable where T : unmanaged
	{
		private FixedList4096Bytes<T> source;

		private int index;

		public FromFixedList4096Bytes(FixedList4096Bytes<T> source)
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
