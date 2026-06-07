using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Internal
{
	internal static class InlineArrayMarshal
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Span<TElement> AsSpan<TBuffer, TElement>(ref TBuffer buffer, int length)
		{
			return MemoryMarshal.CreateSpan(ref Unsafe.As<TBuffer, TElement>(ref buffer), length);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref TElement FirstElementRef<TBuffer, TElement>(ref TBuffer buffer)
		{
			return ref Unsafe.As<TBuffer, TElement>(ref buffer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref TElement ElementRef<TBuffer, TElement>(ref TBuffer buffer, int index)
		{
			return ref Unsafe.Add(ref Unsafe.As<TBuffer, TElement>(ref buffer), index);
		}
	}
}
