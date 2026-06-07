using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal readonly struct IBufferWriterOwner : IBufferWriter<byte>
	{
		private readonly IBufferWriter<byte> writer;

		public IBufferWriterOwner(IBufferWriter<byte> writer)
		{
			this.writer = writer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
			writer.Advance(count);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Memory<byte> GetMemory(int sizeHint = 0)
		{
			return writer.GetMemory(sizeHint);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<byte> GetSpan(int sizeHint = 0)
		{
			return writer.GetSpan(sizeHint);
		}
	}
}
