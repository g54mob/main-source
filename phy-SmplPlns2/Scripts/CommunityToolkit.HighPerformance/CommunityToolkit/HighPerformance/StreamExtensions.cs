using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityToolkit.HighPerformance
{
	public static class StreamExtensions
	{
		[Obsolete("This API is only available for binary compatibility, but Stream.ReadAsync should be used instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static ValueTask<int> ReadAsync(this Stream stream, Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			return stream.ReadAsync(buffer, cancellationToken);
		}

		[Obsolete("This API is only available for binary compatibility, but Stream.WriteAsync should be used instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static ValueTask WriteAsync(this Stream stream, ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			return stream.WriteAsync(buffer, cancellationToken);
		}

		[Obsolete("This API is only available for binary compatibility, but Stream.Read should be used instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Read(this Stream stream, Span<byte> buffer)
		{
			return stream.Read(buffer);
		}

		[Obsolete("This API is only available for binary compatibility, but Stream.Read should be used instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Write(this Stream stream, ReadOnlySpan<byte> buffer)
		{
			stream.Write(buffer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static T Read<T>(this Stream stream) where T : unmanaged
		{
			int num = 0;
			Unsafe.SkipInit(out T result);
			do
			{
				int num2 = stream.Read(new Span<byte>((byte*)(&result) + num, sizeof(T) - num));
				if (num2 == 0)
				{
					ThrowEndOfStreamException();
				}
				num += num2;
			}
			while (num < sizeof(T));
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Write<T>(this Stream stream, in T value) where T : unmanaged
		{
			ref byte reference = ref Unsafe.As<T, byte>(ref Unsafe.AsRef(in value));
			int length = sizeof(T);
			ReadOnlySpan<byte> buffer = MemoryMarshal.CreateReadOnlySpan(ref reference, length);
			stream.Write(buffer);
		}

		private static void ThrowEndOfStreamException()
		{
			throw new EndOfStreamException("The stream didn't contain enough data to read the requested item.");
		}
	}
}
