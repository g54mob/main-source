using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct IntersectBy<TEnumerator, TEnumerator2, TSource, TKey> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey>
	{
		private TEnumerator source;

		private ValueEnumerable<TEnumerator2, TKey> second;

		private HashSetSlim<TKey>? set;

		public IntersectBy(TEnumerator source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = keySelector;
			_003Ccomparer_003EP = comparer;
			set = null;
			this.source = source;
			this.second = second;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			if (set == null)
			{
				set = second.ToHashSetSlim(_003Ccomparer_003EP);
			}
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				if (set.Remove(_003CkeySelector_003EP(current2)))
				{
					current = current2;
					return true;
				}
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			set?.Dispose();
			source.Dispose();
		}
	}
}
