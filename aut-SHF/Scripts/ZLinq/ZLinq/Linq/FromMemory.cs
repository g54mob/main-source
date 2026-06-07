using System;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	public struct FromMemory<T> : IValueEnumerator<T>, IDisposable
	{
		private int index;

		public FromMemory(ReadOnlyMemory<T> source)
		{
			_003Csource_003EP = default(ReadOnlyMemory<T>);
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public bool TryGetNext(out T current)
		{
			current = default(T);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
