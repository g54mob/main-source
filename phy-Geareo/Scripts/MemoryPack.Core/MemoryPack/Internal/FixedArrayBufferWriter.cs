using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace MemoryPack.Internal
{
	internal struct FixedArrayBufferWriter : IBufferWriter<byte>
	{
		private byte[] buffer;

		private int written;

		public FixedArrayBufferWriter(byte[] buffer)
		{
			this.buffer = null;
			written = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Memory<byte> GetMemory(int sizeHint = 0)
		{
			return default(Memory<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<byte> GetSpan(int sizeHint = 0)
		{
			return default(Span<byte>);
		}

		public byte[] GetFilledBuffer()
		{
			return null;
		}
	}
}
