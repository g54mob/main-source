using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct GroupBy<TEnumerator, TSource, TKey> : IValueEnumerator<IGrouping<TKey, TSource>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private bool init;

		private Grouping<TKey, TSource>? rootGrouping;

		private Grouping<TKey, TSource>? currentGrouping;

		public GroupBy(TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = null;
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

		public bool TryGetSpan(out ReadOnlySpan<IGrouping<TKey, TSource>> span)
		{
			span = default(ReadOnlySpan<IGrouping<TKey, TSource>>);
			return false;
		}

		public bool TryCopyTo(Span<IGrouping<TKey, TSource>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out IGrouping<TKey, TSource> current)
		{
			current = null;
			return false;
		}

		public void Dispose()
		{
		}

		private Grouping<TKey, TSource> BuildRoot()
		{
			return null;
		}
	}
}
