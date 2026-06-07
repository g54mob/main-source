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
	public struct DistinctBy<TEnumerator, TSource, TKey> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private HashSetSlim<TKey>? set;

		public DistinctBy(TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = keySelector;
			_003Ccomparer_003EP = comparer;
			set = null;
			this.source = source;
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
				set = new HashSetSlim<TKey>(_003Ccomparer_003EP ?? EqualityComparer<TKey>.Default);
			}
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				if (set.Add(_003CkeySelector_003EP(current2)))
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
