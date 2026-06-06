using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal sealed class RentedArrayBox<T> : IDisposable
	{
		internal static readonly RentedArrayBox<T> Empty = new RentedArrayBox<T>(Array.Empty<T>(), 0);

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _003Clength_003EP;
			}
		}

		public Span<T> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _003Carray_003EP.AsSpan(0, _003Clength_003EP);
			}
		}

		public RentedArrayBox(T[] array, int length)
		{
			_003Carray_003EP = array;
			_003Clength_003EP = length;
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref T UnsafeGetAt(int index)
		{
			return ref _003Carray_003EP[index];
		}

		public void Dispose()
		{
			if (_003Carray_003EP != null && _003Clength_003EP != 0)
			{
				ArrayPool<T>.Shared.Return(_003Carray_003EP, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
				_003Carray_003EP = null;
			}
		}
	}
}
