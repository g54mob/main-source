using System;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal sealed class RentedArrayBox<T> : IDisposable where T : notnull
	{
		internal static readonly RentedArrayBox<T> Empty;

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0;
			}
		}

		public Span<T> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(Span<T>);
			}
		}

		public RentedArrayBox(T[] array, int length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref T UnsafeGetAt(int index)
		{
			throw null;
		}

		public void Dispose()
		{
		}
	}
}
