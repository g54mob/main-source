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
	public struct ListSelect<TSource, TResult> : IValueEnumerator<TResult>, IDisposable
	{
		internal List<TSource> source;

		internal readonly Func<TSource, TResult> selector;

		private int index;

		public ListSelect(List<TSource> source, Func<TSource, TResult> selector)
		{
			index = 0;
			this.source = source;
			this.selector = selector;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = source.Count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<TSource>)source.AsSpan(), offset, destination.Length, out ReadOnlySpan<TSource> slice))
			{
				for (int i = 0; (uint)i < (uint)slice.Length; i++)
				{
					destination[i] = selector(slice[i]);
				}
				return true;
			}
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			if ((uint)index < (uint)source.Count)
			{
				current = selector(source[index++]);
				return true;
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
		}

		internal ListSelectWhere<TSource, TResult> Where(Func<TResult, bool> predicate)
		{
			return new ListSelectWhere<TSource, TResult>(source, selector, predicate);
		}
	}
}
