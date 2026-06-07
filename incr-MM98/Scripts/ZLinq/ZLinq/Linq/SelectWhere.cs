using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SelectWhere<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		public SelectWhere(TEnumerator source, Func<TSource, TResult> selector, Func<TResult, bool> predicate)
		{
			_003Cselector_003EP = selector;
			_003Cpredicate_003EP = predicate;
			this.source = source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				TResult val = _003Cselector_003EP(current2);
				if (_003Cpredicate_003EP(val))
				{
					current = val;
					return true;
				}
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}
	}
}
