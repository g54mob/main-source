using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ListSelectWhere<TSource, TResult> : IValueEnumerator<TResult>, IDisposable
	{
		private List<TSource> source;

		private readonly Func<TSource, TResult> selector;

		private Func<TResult, bool> predicate;

		private int index;

		public ListSelectWhere(List<TSource> source, Func<TSource, TResult> selector, Func<TResult, bool> predicate)
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
			Span<TSource> span = source.AsSpan();
			while ((uint)index < (uint)span.Length)
			{
				current = selector(span[index++]);
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
