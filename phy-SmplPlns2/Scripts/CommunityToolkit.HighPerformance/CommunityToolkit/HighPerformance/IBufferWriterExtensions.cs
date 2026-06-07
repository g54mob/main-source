using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers;
using CommunityToolkit.HighPerformance.Streams;

namespace CommunityToolkit.HighPerformance
{
	public static class IBufferWriterExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream AsStream(this IBufferWriter<byte> writer)
		{
			if (writer.GetType() == typeof(ArrayPoolBufferWriter<byte>))
			{
				return new IBufferWriterStream<ArrayBufferWriterOwner>(new ArrayBufferWriterOwner(Unsafe.As<ArrayPoolBufferWriter<byte>>(writer)));
			}
			return new IBufferWriterStream<IBufferWriterOwner>(new IBufferWriterOwner(writer));
		}

		public unsafe static void Write<T>(this IBufferWriter<byte> writer, T value) where T : unmanaged
		{
			int num = sizeof(T);
			Span<byte> span = writer.GetSpan(1);
			if (span.Length < num)
			{
				ThrowArgumentExceptionForEndOfBuffer();
			}
			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
			writer.Advance(num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Write<T>(this IBufferWriter<T> writer, T value)
		{
			Span<T> span = writer.GetSpan(1);
			if (span.Length < 1)
			{
				ThrowArgumentExceptionForEndOfBuffer();
			}
			MemoryMarshal.GetReference(span) = value;
			writer.Advance(1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Write<T>(this IBufferWriter<byte> writer, ReadOnlySpan<T> span) where T : unmanaged
		{
			ReadOnlySpan<byte> readOnlySpan = MemoryMarshal.AsBytes(span);
			Span<byte> span2 = writer.GetSpan(readOnlySpan.Length);
			readOnlySpan.CopyTo(span2);
			writer.Advance(readOnlySpan.Length);
		}

		private static void ThrowArgumentExceptionForEndOfBuffer()
		{
			throw new ArgumentException("The current buffer writer can't contain the requested input data.");
		}
	}
}
