using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ArraySelect<TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TSource : notnull where TResult : notnull
	{
		internal TSource[] source;

		internal readonly Func<TSource, TResult> selector;

		private int index;

		public ArraySelect(TSource[] source, Func<TSource, TResult> selector)
		{
			this.source = null;
			this.selector = null;
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

		internal ArraySelectWhere<TSource, TResult> Where(Func<TResult, bool> predicate)
		{
			return default(ArraySelectWhere<TSource, TResult>);
		}
	}
}
