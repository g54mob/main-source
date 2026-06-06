using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	public struct FromNativeArray<T> : IValueEnumerator<T>, IDisposable where T : struct
	{
		private NativeArray<T>.ReadOnly source;

		private int index;

		public FromNativeArray(NativeArray<T>.ReadOnly source)
		{
			this.source = source;
			index = 0;
		}

		public void Dispose()
		{
		}

		public bool TryCopyTo(Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice((ReadOnlySpan<T>)source, offset, destination.Length, out ReadOnlySpan<T> slice))
			{
				slice.CopyTo(destination);
				return true;
			}
			return false;
		}

		public bool TryGetNext(out T current)
		{
			if ((uint)index < (uint)source.Length)
			{
				current = source[index++];
				return true;
			}
			current = default(T);
			return false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = source.Length;
			return true;
		}

		public bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = source;
			return true;
		}
	}
}
