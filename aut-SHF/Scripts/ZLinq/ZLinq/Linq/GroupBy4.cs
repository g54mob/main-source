using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct GroupBy4<TEnumerator, TSource, TKey, TElement, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull where TResult : notnull
	{
		private TEnumerator source;

		private bool init;

		private Grouping<TKey, TElement>? rootGrouping;

		private Grouping<TKey, TElement>? currentGrouping;

		public GroupBy4(TEnumerator source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = null;
			_003CelementSelector_003EP = null;
			_003CresultSelector_003EP = null;
			_003Ccomparer_003EP = null;
			this.source = default(TEnumerator);
			init = false;
			rootGrouping = null;
			currentGrouping = null;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo(Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}

		private Grouping<TKey, TElement> BuildRoot()
		{
			return null;
		}
	}
}
