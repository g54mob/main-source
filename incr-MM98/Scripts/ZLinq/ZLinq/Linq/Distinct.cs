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
	public struct Distinct<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private HashSetSlim<TSource>? set;

		public Distinct(TEnumerator source, IEqualityComparer<TSource>? comparer)
		{
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
			if (destination.Length == 1 && offset.Value == 0)
			{
				return source.TryCopyTo(destination, offset);
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			if (set == null)
			{
				set = new HashSetSlim<TSource>(_003Ccomparer_003EP ?? EqualityComparer<TSource>.Default);
			}
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				if (set.Add(current2))
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
