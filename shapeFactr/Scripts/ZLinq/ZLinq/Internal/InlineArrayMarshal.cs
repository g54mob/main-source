using System;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal static class InlineArrayMarshal
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Span<TElement?> AsSpan<TBuffer, TElement>(ref TBuffer buffer, int length)
		{
			return default(Span<TElement>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref TElement FirstElementRef<TBuffer, TElement>(ref TBuffer buffer) where TBuffer : notnull where TElement : notnull
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref TElement ElementRef<TBuffer, TElement>(ref TBuffer buffer, int index) where TBuffer : notnull where TElement : notnull
		{
			throw null;
		}
	}
}
