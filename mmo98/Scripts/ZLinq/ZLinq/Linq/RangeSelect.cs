using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct RangeSelect<TResult> : IValueEnumerator<TResult>, IDisposable
	{
		internal readonly int count;

		internal readonly int start;

		internal readonly int to;

		private int value;

		internal readonly Func<int, TResult> selector;

		public RangeSelect(FromRange source, Func<int, TResult> selector)
		{
			count = source.count;
			start = source.start;
			to = source.to;
			value = source.start;
			this.selector = selector;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = this.count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var num, out var num2))
			{
				int num3 = start + num;
				for (int i = 0; i < num2; i++)
				{
					destination[i] = selector(num3);
					num3++;
				}
				return true;
			}
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			if (value < to)
			{
				current = selector(value);
				value++;
				return true;
			}
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
