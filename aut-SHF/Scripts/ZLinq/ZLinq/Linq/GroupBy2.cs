using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct GroupBy2<TEnumerator, TSource, TKey, TElement> : IValueEnumerator<IGrouping<TKey, TElement>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
	{
		private TEnumerator source;

		private bool init;

		private Grouping<TKey, TElement>? rootGrouping;

		private Grouping<TKey, TElement>? currentGrouping;

		public GroupBy2(TEnumerator source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = null;
			_003CelementSelector_003EP = null;
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

		public bool TryGetSpan(out ReadOnlySpan<IGrouping<TKey, TElement>> span)
		{
			span = default(ReadOnlySpan<IGrouping<TKey, TElement>>);
			return false;
		}

		public bool TryCopyTo(Span<IGrouping<TKey, TElement>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out IGrouping<TKey, TElement> current)
		{
			current = null;
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
