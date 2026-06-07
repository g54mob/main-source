using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
	{
		private TEnumerator source;

		private TEnumerator2 inner;

		private Lookup<TKey, TInner>? innerLookup;

		private Grouping<TKey, TInner>? currentGroup;

		private int currentGroupIndex;

		private TOuter currentOuter;

		public Join(TEnumerator source, TEnumerator2 inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CouterKeySelector_003EP = outerKeySelector;
			_003CinnerKeySelector_003EP = innerKeySelector;
			_003CresultSelector_003EP = resultSelector;
			_003Ccomparer_003EP = comparer;
			innerLookup = null;
			currentGroup = null;
			currentGroupIndex = 0;
			this.source = source;
			this.inner = inner;
			currentOuter = default(TOuter);
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
			if (innerLookup.Count != 0)
			{
				while (true)
				{
					if (currentGroup != null)
					{
						if (currentGroupIndex < currentGroup.Count)
						{
							current = _003CresultSelector_003EP(currentOuter, currentGroup[currentGroupIndex]);
							currentGroupIndex++;
							return true;
						}
						currentGroup = null;
					}
					TOuter current2;
					Grouping<TKey, TInner> grouping;
					while (source.TryGetNext(out current2))
					{
						TKey val = _003CouterKeySelector_003EP(current2);
						if (val != null)
						{
							grouping = innerLookup.GetGroup(val);
							if (grouping != null)
							{
								goto IL_00dd;
							}
						}
					}
					break;
					IL_00dd:
					currentOuter = current2;
					currentGroup = grouping;
					currentGroupIndex = 0;
				}
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
