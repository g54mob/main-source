using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRepeat<T> : IValueEnumerator<T>, IDisposable
	{
		private int index;

		public FromRepeat(T _element, int _count)
		{
			_003C_element_003EP = _element;
			_003C_count_003EP = _count;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = _003C_count_003EP;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = default(ReadOnlySpan<T>);
			return false;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSliceRange(_003C_count_003EP, offset, destination.Length, out var _, out var count))
			{
				destination.Slice(0, count).Fill(_003C_element_003EP);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out T current)
		{
			if (index++ < _003C_count_003EP)
			{
				current = _003C_element_003EP;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
