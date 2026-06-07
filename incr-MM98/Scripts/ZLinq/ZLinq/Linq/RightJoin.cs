using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
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
			_003CouterKeySelector_003EP = outerKeySelector;
			_003CinnerKeySelector_003EP = innerKeySelector;
			_003CresultSelector_003EP = resultSelector;
			_003Ccomparer_003EP = comparer;
			outerLookup = null;
			currentGroup = null;
			currentGroupIndex = 0;
			this.source = source;
			this.inner = inner;
			currentInner = default(TInner);
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
			if (outerLookup == null)
			{
				try
				{
					outerLookup = Lookup.CreateForJoin(ref source, _003CouterKeySelector_003EP, _003Ccomparer_003EP);
				}
				finally
				{
					source.Dispose();
				}
			}
			while (true)
			{
				if (currentGroup != null)
				{
					if (currentGroupIndex < currentGroup.Count)
					{
						current = _003CresultSelector_003EP(currentGroup[currentGroupIndex], currentInner);
						currentGroupIndex++;
						return true;
					}
					currentGroup = null;
				}
				if (!inner.TryGetNext(out TInner current2))
				{
					break;
				}
				TKey key = _003CinnerKeySelector_003EP(current2);
				Grouping<TKey, TOuter> grouping = outerLookup.GetGroup(key);
				if (grouping != null)
				{
					currentInner = current2;
					currentGroup = grouping;
					currentGroupIndex = 0;
					continue;
				}
				current = _003CresultSelector_003EP(default(TOuter), current2);
				return true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			if (outerLookup == null)
			{
				source.Dispose();
			}
			inner.Dispose();
		}
	}
}
