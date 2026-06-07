using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Select2<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private int index;

		public Select2(TEnumerator source, Func<TSource, int, TResult> selector)
		{
			_003Cselector_003EP = selector;
			this.source = source;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			return source.TryGetNonEnumeratedCount(out count);
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
			if (source.TryGetNext(out TSource current2))
			{
				current = _003Cselector_003EP(current2, index++);
				return true;
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
