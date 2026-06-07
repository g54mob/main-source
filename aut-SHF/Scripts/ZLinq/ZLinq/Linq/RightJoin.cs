using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
	{
		private TEnumerator source;

		private TEnumerator2 inner;

		private Lookup<TKey, TOuter>? outerLookup;

		private Grouping<TKey, TOuter>? currentGroup;

		private int currentGroupIndex;

		private TInner currentInner;

		public RightJoin(TEnumerator source, TEnumerator2 inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CouterKeySelector_003EP = null;
			_003CinnerKeySelector_003EP = null;
			_003CresultSelector_003EP = null;
			_003Ccomparer_003EP = null;
			this.source = default(TEnumerator);
			this.inner = default(TEnumerator2);
			outerLookup = null;
			currentGroup = null;
			currentGroupIndex = 0;
			currentInner = default(TInner);
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
	}
}
