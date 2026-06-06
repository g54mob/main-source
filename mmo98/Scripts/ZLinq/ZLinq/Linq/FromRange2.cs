using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[Obsolete("Use ValueEnumerable.Sequence instead. This will be removed in a future version.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRange2 : IValueEnumerator<int>, IDisposable
	{
		private readonly int count;

		private readonly int start;

		private readonly int to;

		private readonly bool isInfinite;

		private int value;

		public FromRange2(int start, int count, bool isInfinite)
		{
			this.count = count;
			this.start = start;
			to = (isInfinite ? (int.MaxValue - start) : (start + count));
			this.isInfinite = isInfinite;
			value = start;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (isInfinite)
			{
				count = 0;
				return false;
			}
			count = this.count;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<int> span)
		{
			span = default(ReadOnlySpan<int>);
			return false;
		}

		public bool TryCopyTo(Span<int> destination, Index offset)
		{
			if (isInfinite)
			{
				return false;
			}
			if (EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var num, out var length))
			{
				FromRange.FillIncremental(destination.Slice(0, length), start + num);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out int current)
		{
			checked
			{
				if (value < to)
				{
					current = value;
					value++;
					return true;
				}
				current = 0;
				return false;
			}
		}

		public void Dispose()
		{
		}
	}
}
