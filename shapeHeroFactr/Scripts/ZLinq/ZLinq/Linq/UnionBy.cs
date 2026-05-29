using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct UnionBy<TEnumerator, TEnumerator2, TSource, TKey> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private TEnumerator2 second;

		private HashSetSlim<TKey>? set;

		private byte state;

		public UnionBy(TEnumerator source, TEnumerator2 second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		{
			_003CkeySelector_003EP = null;
			_003Ccomparer_003EP = null;
			this.source = default(TEnumerator);
			this.second = default(TEnumerator2);
			set = null;
			state = 0;
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
