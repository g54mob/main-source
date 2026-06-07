using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct RangeSelect<TResult> : IValueEnumerator<TResult>, IDisposable where TResult : notnull
	{
		internal readonly int count;

		internal readonly int start;

		internal readonly int to;

		private int value;

		internal readonly Func<int, TResult> selector;

		public RangeSelect(FromRange source, Func<int, TResult> selector)
		{
			count = 0;
			start = 0;
			to = 0;
			value = 0;
			this.selector = null;
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
