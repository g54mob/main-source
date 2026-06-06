using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromNativeList<T> : IValueEnumerator<T>, IDisposable where T : unmanaged
	{
		private NativeList<T> source;

		private int index;

		public FromNativeList(NativeList<T> source)
		{
			this.source = source;
			index = 0;
		}

		public void Dispose()
		{
		}

		public unsafe bool TryCopyTo(Span<T> destination, Index offset)
		{
			if (EnumeratorHelper.TryGetSlice(new ReadOnlySpan<T>(source.GetUnsafePtr(), source.Length), offset, destination.Length, out var slice))
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

		public unsafe bool TryGetSpan(out ReadOnlySpan<T> span)
		{
			span = new ReadOnlySpan<T>(source.GetUnsafePtr(), source.Length);
			return true;
		}
	}
}
