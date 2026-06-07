using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromArray<T> : IValueEnumerator<T>, IDisposable
	{
		private int index;

		public FromArray(T[] source)
		{
			_003Csource_003EP = source;
			index = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal T[] GetSource()
		{
			return _003Csource_003EP;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = _003Csource_003EP.Length;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			if (_003Csource_003EP.GetType() != typeof(T[]))
			{
				span = default(ReadOnlySpan<T>);
				return false;
			}
			span = _003Csource_003EP.AsSpan();
			return true;
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<T>)_003Csource_003EP, offset, destination.Length, out ReadOnlySpan<T> slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out T current)
		{
			if ((uint)index < (uint)_003Csource_003EP.Length)
			{
				current = _003Csource_003EP[index];
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
