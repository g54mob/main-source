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
	public struct GroupBy2<TEnumerator, TSource, TKey, TElement> : IValueEnumerator<IGrouping<TKey, TElement>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private bool init;

		private Grouping<TKey, TElement>? rootGrouping;

		private Grouping<TKey, TElement>? currentGrouping;

		public GroupBy2(TEnumerator source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = keySelector;
			_003CelementSelector_003EP = elementSelector;
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

		public bool TryGetSpan(out ReadOnlySpan<IGrouping<TKey, TElement>> span)
		{
			span = default(ReadOnlySpan<IGrouping<TKey, TElement>>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<IGrouping<TKey, TElement>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out IGrouping<TKey, TElement> current)
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

		private Grouping<TKey, TElement>? BuildRoot()
		{
			LookupBuilder<TKey, TElement> lookupBuilder = new LookupBuilder<TKey, TElement>(_003Ccomparer_003EP ?? EqualityComparer<TKey>.Default);
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					lookupBuilder.Add(_003CkeySelector_003EP(arg), _003CelementSelector_003EP(arg));
				}
			}
			else
			{
				using (source)
				{
					TSource current;
					while (source.TryGetNext(out current))
					{
						lookupBuilder.Add(_003CkeySelector_003EP(current), _003CelementSelector_003EP(current));
					}
				}
			}
			return lookupBuilder.GetRootGroupAndClear();
		}
	}
}
