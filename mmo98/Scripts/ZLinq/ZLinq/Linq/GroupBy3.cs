using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct GroupBy3<TEnumerator, TSource, TKey, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private bool init;

		private Grouping<TKey, TSource>? rootGrouping;

		private Grouping<TKey, TSource>? currentGrouping;

		public GroupBy3(TEnumerator source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = keySelector;
			_003CresultSelector_003EP = resultSelector;
			_003Ccomparer_003EP = comparer;
			init = false;
			rootGrouping = null;
			currentGrouping = null;
			this.source = source;
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
			if (!init)
			{
				init = true;
				rootGrouping = BuildRoot();
				if (rootGrouping != null)
				{
					current = _003CresultSelector_003EP(rootGrouping.Key, rootGrouping);
					currentGrouping = rootGrouping;
					return true;
				}
			}
			currentGrouping = currentGrouping?.NextGroupInAddOrder;
			if (currentGrouping == null || currentGrouping == rootGrouping)
			{
				current = default(TResult);
				return false;
			}
			current = _003CresultSelector_003EP(currentGrouping.Key, currentGrouping);
			return true;
		}

		public void Dispose()
		{
			source.Dispose();
		}

		private Grouping<TKey, TSource>? BuildRoot()
		{
			LookupBuilder<TKey, TSource> lookupBuilder = new LookupBuilder<TKey, TSource>(_003Ccomparer_003EP ?? EqualityComparer<TKey>.Default);
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val = readOnlySpan[i];
					lookupBuilder.Add(_003CkeySelector_003EP(val), val);
				}
			}
			else
			{
				using (source)
				{
					TSource current;
					while (source.TryGetNext(out current))
					{
						lookupBuilder.Add(_003CkeySelector_003EP(current), current);
					}
				}
			}
			return lookupBuilder.GetRootGroupAndClear();
		}
	}
}
