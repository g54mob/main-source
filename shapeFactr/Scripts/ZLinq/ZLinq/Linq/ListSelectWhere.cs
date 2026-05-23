using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ListSelectWhere<TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TSource : notnull where TResult : notnull
	{
		private List<TSource> source;

		private readonly Func<TSource, TResult> selector;

		private Func<TResult, bool> predicate;

		private int index;

		public ListSelectWhere(List<TSource> source, Func<TSource, TResult> selector, Func<TResult, bool> predicate)
		{
			this.source = null;
			this.selector = null;
			this.predicate = null;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo(Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
