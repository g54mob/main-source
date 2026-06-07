using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Streams;

namespace CommunityToolkit.HighPerformance
{
	public static class MemoryExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory2D<T> AsMemory2D<T>(this Memory<T> memory, int height, int width)
		{
			return new Memory2D<T>(memory, height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory2D<T> AsMemory2D<T>(this Memory<T> memory, int offset, int height, int width, int pitch)
		{
			return new Memory2D<T>(memory, offset, height, width, pitch);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<byte> AsBytes<T>(this Memory<T> memory) where T : unmanaged
		{
			return MemoryMarshal.AsMemory(ReadOnlyMemoryExtensions.Cast<T, byte>(memory));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<TTo> Cast<TFrom, TTo>(this Memory<TFrom> memory) where TFrom : unmanaged where TTo : unmanaged
		{
			return MemoryMarshal.AsMemory(ReadOnlyMemoryExtensions.Cast<TFrom, TTo>(memory));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream AsStream(this Memory<byte> memory)
		{
			return CommunityToolkit.HighPerformance.Streams.MemoryStream.Create(memory, isReadOnly: false);
		}
	}
}
