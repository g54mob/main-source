using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromMemory<T> : IValueEnumerator<T>, IDisposable
	{
		private int index;

		public FromMemory(ReadOnlyMemory<T> source)
		{
			_003Csource_003EP = source;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = _003Csource_003EP.Length;
			return true;
		}

		public bool TryCopyTo([ScopedRef] Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice(_003Csource_003EP.Span, offset, destination.Length, out var slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = _003Csource_003EP.Span;
			return true;
		}

		public bool TryGetNext(out T current)
		{
			if ((uint)index < (uint)_003Csource_003EP.Length)
			{
				current = _003Csource_003EP.Span[index];
				index++;
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
