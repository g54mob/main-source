using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

namespace ZLogger
{
	internal class StreamBufferWriter : IBufferWriter<byte>
	{
		private readonly Stream stream;

		private byte[] buffer;

		private byte[] defaultBuffer;

		private int written;

		public StreamBufferWriter(Stream stream)
		{
			this.stream = stream;
			defaultBuffer = (buffer = new byte[65536]);
			written = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
			written += count;
		}

		public Memory<byte> GetMemory(int sizeHint = 0)
		{
			if (buffer != defaultBuffer)
			{
				Flush();
			}
			if (written + sizeHint > buffer.Length)
			{
				Flush();
			}
			if (buffer.Length - written < sizeHint)
			{
				Flush();
				buffer = ArrayPool<byte>.Shared.Rent(sizeHint);
			}
			return new Memory<byte>(buffer, written, buffer.Length - written);
		}

		public Span<byte> GetSpan(int sizeHint = 0)
		{
			return GetMemory(sizeHint).Span;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryGetForNewLine([NotNullWhen(true)] out byte[]? rawBuffer, out int rawWritten)
		{
			if (buffer.Length - written > 2)
			{
				rawBuffer = buffer;
				rawWritten = written;
				return true;
			}
			rawBuffer = null;
			rawWritten = 0;
			return false;
		}

		public void Flush()
		{
			if (written != 0)
			{
				stream.Write(buffer, 0, written);
				stream.Flush();
				written = 0;
				if (buffer != defaultBuffer)
				{
					ArrayPool<byte>.Shared.Return(buffer);
					buffer = defaultBuffer;
				}
			}
		}
	}
}
