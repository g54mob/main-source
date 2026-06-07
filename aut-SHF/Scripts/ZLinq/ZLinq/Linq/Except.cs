using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Except<TEnumerator, TEnumerator2, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private ValueEnumerable<TEnumerator2, TSource> second;

		private HashSetSlim<TSource>? set;

		public Except(TEnumerator source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer)
		{
			_003Ccomparer_003EP = null;
			this.source = default(TEnumerator);
			this.second = default(ValueEnumerable<TEnumerator2, TSource>);
			set = null;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo(Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			current = default(TSource);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
