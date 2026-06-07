using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct GroupBy<TEnumerator, TSource, TKey> : IValueEnumerator<IGrouping<TKey, TSource>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private bool init;

		private Grouping<TKey, TSource>? rootGrouping;

		private Grouping<TKey, TSource>? currentGrouping;

		public GroupBy(TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = keySelector;
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

		public bool TryGetSpan(out ReadOnlySpan<IGrouping<TKey, TSource>> span)
		{
			span = default(ReadOnlySpan<IGrouping<TKey, TSource>>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<IGrouping<TKey, TSource>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out IGrouping<TKey, TSource> current)
		{
			if (!init)
			{
				init = true;
				rootGrouping = BuildRoot();
				if (rootGrouping != null)
				{
					current = rootGrouping;
					currentGrouping = rootGrouping;
					return true;
				}
			}
			currentGrouping = currentGrouping?.NextGroupInAddOrder;
			if (currentGrouping == null || currentGrouping == rootGrouping)
			{
				current = null;
				return false;
			}
			current = currentGrouping;
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
