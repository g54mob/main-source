using System;
using System.Runtime.CompilerServices;

namespace MemoryPack.Internal
{
	internal struct BufferSegment
	{
		private byte[] buffer;

		private int written;

		public bool IsNull => false;

		public int WrittenCount => 0;

		public Span<byte> WrittenBuffer => default(Span<byte>);

		public Memory<byte> WrittenMemory => default(Memory<byte>);

		public Span<byte> FreeBuffer => default(Span<byte>);

		public BufferSegment(int size)
		{
			buffer = null;
			written = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
		}
	}
}
