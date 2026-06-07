using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers.Views;

namespace CommunityToolkit.HighPerformance.Buffers
{
	[DebuggerTypeProxy(typeof(MemoryDebugView<>))]
	[DebuggerDisplay("{ToString(),raw}")]
	public sealed class MemoryBufferWriter<T> : IBuffer<T>, IBufferWriter<T>
	{
		private readonly Memory<T> memory;

		private int index;

		public ReadOnlyMemory<T> WrittenMemory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return memory.Slice(0, index);
			}
		}

		public ReadOnlySpan<T> WrittenSpan
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return memory.Slice(0, index).Span;
			}
		}

		public int WrittenCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return index;
			}
		}

		public int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return memory.Length;
			}
		}

		public int FreeCapacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return memory.Length - index;
			}
		}

		public MemoryBufferWriter(Memory<T> memory)
		{
			this.memory = memory;
		}

		public void Clear()
		{
			memory.Slice(0, index).Span.Clear();
			index = 0;
		}

		public void Advance(int count)
		{
			if (count < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeCount();
			}
			if (index > memory.Length - count)
			{
				ThrowArgumentExceptionForAdvancedTooFar();
			}
			index += count;
		}

		public Memory<T> GetMemory(int sizeHint = 0)
		{
			ValidateSizeHint(sizeHint);
			return memory.Slice(index);
		}

		public Span<T> GetSpan(int sizeHint = 0)
		{
			ValidateSizeHint(sizeHint);
			return memory.Slice(index).Span;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ValidateSizeHint(int sizeHint)
		{
			if (sizeHint < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeSizeHint();
			}
			if (sizeHint == 0)
			{
				sizeHint = 1;
			}
			if (sizeHint > FreeCapacity)
			{
				ThrowArgumentExceptionForCapacityExceeded();
			}
		}

		public override string ToString()
		{
			if (typeof(T) == typeof(char))
			{
				return memory.Slice(0, index).ToString();
			}
			return $"CommunityToolkit.HighPerformance.Buffers.MemoryBufferWriter<{typeof(T)}>[{index}]";
		}

		private static void ThrowArgumentOutOfRangeExceptionForNegativeCount()
		{
			throw new ArgumentOutOfRangeException("count", "The count can't be a negative value.");
		}

		private static void ThrowArgumentOutOfRangeExceptionForNegativeSizeHint()
		{
			throw new ArgumentOutOfRangeException("sizeHint", "The size hint can't be a negative value.");
		}

		private static void ThrowArgumentExceptionForAdvancedTooFar()
		{
			throw new ArgumentException("The buffer writer has advanced too far.");
		}

		private static void ThrowArgumentExceptionForCapacityExceeded()
		{
			throw new ArgumentException("The buffer writer doesn't have enough capacity left.");
		}
	}
}
