using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ArraySelectWhere<TSource, TResult> : IValueEnumerator<TResult>, IDisposable
	{
		private TSource[] source;

		private readonly Func<TSource, TResult> selector;

		private Func<TResult, bool> predicate;

		private int index;

		public ArraySelectWhere(TSource[] source, Func<TSource, TResult> selector, Func<TResult, bool> predicate)
		{
			index = 0;
			this.source = source;
			this.selector = selector;
			this.predicate = predicate;
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
			while ((uint)index < (uint)source.Length)
			{
				current = selector(source[index++]);
				if (predicate(current))
				{
					return true;
				}
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
