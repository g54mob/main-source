using System;
using System.Collections.Generic;

namespace ZLinq.Linq
{
	internal sealed class ArrayIterator<T> : CollectionIterator<T> where T : notnull
	{
		public static readonly ArrayIterator<T> Instance;

		private ArrayIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			count = default(int);
			return false;
		}

		public override bool TryGetSpan(IEnumerable<T> source, out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public override bool TryCopyTo(IEnumerable<T> source, Span<T> destination, Index offset)
		{
			return false;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			current = default(T);
			return false;
		}
	}
}
