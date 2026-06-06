using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
	{
		private TEnumerator source;

		private TEnumerator2 inner;

		private Lookup<TKey, TInner>? innerLookup;

		public GroupJoin(TEnumerator source, TEnumerator2 inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CouterKeySelector_003EP = outerKeySelector;
			_003CinnerKeySelector_003EP = innerKeySelector;
			_003CresultSelector_003EP = resultSelector;
			_003Ccomparer_003EP = comparer;
			innerLookup = null;
			this.source = source;
			this.inner = inner;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			if (innerLookup == null)
			{
				try
				{
					innerLookup = Lookup.CreateForJoin(ref inner, _003CinnerKeySelector_003EP, _003Ccomparer_003EP);
				}
				finally
				{
					inner.Dispose();
				}
			}
			if (source.TryGetNext(out TOuter current2))
			{
				TKey key = _003CouterKeySelector_003EP(current2);
				Grouping<TKey, TInner> grouping = innerLookup.GetGroup(key);
				if (grouping != null)
				{
					current = _003CresultSelector_003EP(current2, grouping);
					return true;
				}
				current = _003CresultSelector_003EP(current2, Array.Empty<TInner>());
				return true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			if (innerLookup == null)
			{
				inner.Dispose();
			}
			source.Dispose();
		}
	}
}
