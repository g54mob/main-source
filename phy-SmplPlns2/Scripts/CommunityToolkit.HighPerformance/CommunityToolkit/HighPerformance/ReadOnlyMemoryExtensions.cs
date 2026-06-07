using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers.Internals;
using CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces;
using CommunityToolkit.HighPerformance.Streams;

namespace CommunityToolkit.HighPerformance
{
	public static class ReadOnlyMemoryExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory2D<T> AsMemory2D<T>(this ReadOnlyMemory<T> memory, int height, int width)
		{
			return new ReadOnlyMemory2D<T>(memory, height, width);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory2D<T> AsMemory2D<T>(this ReadOnlyMemory<T> memory, int offset, int height, int width, int pitch)
		{
			return new ReadOnlyMemory2D<T>(memory, offset, height, width, pitch);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory<byte> AsBytes<T>(this ReadOnlyMemory<T> memory) where T : unmanaged
		{
			return memory.Cast<T, byte>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory<TTo> Cast<TFrom, TTo>(this ReadOnlyMemory<TFrom> memory) where TFrom : unmanaged where TTo : unmanaged
		{
			if (memory.IsEmpty)
			{
				return default(ReadOnlyMemory<TTo>);
			}
			if (typeof(TFrom) == typeof(char) && MemoryMarshal.TryGetString((ReadOnlyMemory<char>)(object)memory, out var text, out var start, out var length))
			{
				return new StringMemoryManager<TTo>(text, start, length).Memory;
			}
			if (MemoryMarshal.TryGetArray(memory, out var segment))
			{
				return new ArrayMemoryManager<TFrom, TTo>(segment.Array, segment.Offset, segment.Count).Memory;
			}
			if (MemoryMarshal.TryGetMemoryManager<TFrom, MemoryManager<TFrom>>(memory, out var manager, out start, out length))
			{
				if (manager is IMemoryManager memoryManager)
				{
					return memoryManager.GetMemory<TTo>(start, length);
				}
				return new ProxyMemoryManager<TFrom, TTo>(manager, start, length).Memory;
			}
			return ThrowArgumentExceptionForUnsupportedMemory();
			static ReadOnlyMemory<TTo> ThrowArgumentExceptionForUnsupportedMemory()
			{
				throw new ArgumentException("The input instance doesn't have a supported underlying data store.");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream AsStream(this ReadOnlyMemory<byte> memory)
		{
			return CommunityToolkit.HighPerformance.Streams.MemoryStream.Create(memory, isReadOnly: true);
		}
	}
}
