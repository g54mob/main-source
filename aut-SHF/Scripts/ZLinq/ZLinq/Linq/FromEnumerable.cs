using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	public struct FromEnumerable<T> : IValueEnumerator<T>, IDisposable where T : notnull
	{
		private readonly CollectionIterator<T> iterator;

		private FromEnumerableContent content;

		public FromEnumerable(IEnumerable<T> source)
		{
			iterator = null;
			content = default(FromEnumerableContent);
		}

		internal IEnumerable<T> GetSource()
		{
			return null;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
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
