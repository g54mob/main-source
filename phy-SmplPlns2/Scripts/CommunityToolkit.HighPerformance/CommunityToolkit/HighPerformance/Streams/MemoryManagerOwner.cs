using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal readonly struct MemoryManagerOwner : ISpanOwner
	{
		private readonly MemoryManager<byte> memoryManager;

		private readonly int offset;

		private readonly int length;

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return length;
			}
		}

		public Span<byte> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return memoryManager.GetSpan().Slice(offset, length);
			}
		}

		public Memory<byte> Memory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return memoryManager.Memory.Slice(offset, length);
			}
		}

		public MemoryManagerOwner(MemoryManager<byte> memoryManager, int offset, int length)
		{
			this.memoryManager = memoryManager;
			this.offset = offset;
			this.length = length;
		}
	}
}
