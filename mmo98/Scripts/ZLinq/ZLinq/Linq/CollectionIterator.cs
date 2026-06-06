using System;
using System.Collections.Generic;

namespace ZLinq.Linq
{
	internal abstract class CollectionIterator<T>
	{
		public abstract bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count);

		public virtual bool TryGetSpan(IEnumerable<T> source, out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public virtual bool TryCopyTo(IEnumerable<T> source, Span<T> destination, Index offset)
		{
			return false;
		}

		public abstract bool TryGetNext(ref FromEnumerableContent content, out T current);
	}
}
