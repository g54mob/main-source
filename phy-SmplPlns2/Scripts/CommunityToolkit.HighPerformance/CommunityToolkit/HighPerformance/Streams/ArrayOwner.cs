using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal readonly struct ArrayOwner : ISpanOwner
	{
		private readonly byte[] array;

		private readonly int offset;

		private readonly int length;

		public static ArrayOwner Empty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new ArrayOwner(Array.Empty<byte>(), 0, 0);
			}
		}

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
				return MemoryMarshal.CreateSpan(ref array.DangerousGetReferenceAt(offset), length);
			}
		}

		public Memory<byte> Memory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return array.AsMemory(offset, length);
			}
		}

		public ArrayOwner(byte[] array, int offset, int length)
		{
			this.array = array;
			this.offset = offset;
			this.length = length;
		}
	}
}
