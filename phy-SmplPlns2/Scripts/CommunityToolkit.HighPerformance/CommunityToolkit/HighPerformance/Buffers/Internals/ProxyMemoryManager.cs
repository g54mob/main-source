using System;
using System.Buffers;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance.Buffers.Internals
{
	internal sealed class ProxyMemoryManager<TFrom, TTo> : MemoryManager<TTo>, IMemoryManager where TFrom : unmanaged where TTo : unmanaged
	{
		private readonly MemoryManager<TFrom> memoryManager;

		private readonly int offset;

		private readonly int length;

		public ProxyMemoryManager(MemoryManager<TFrom> memoryManager, int offset, int length)
		{
			this.memoryManager = memoryManager;
			this.offset = offset;
			this.length = length;
		}

		public override Span<TTo> GetSpan()
		{
			return MemoryMarshal.Cast<TFrom, TTo>(memoryManager.GetSpan().Slice(offset, length));
		}

		public unsafe override MemoryHandle Pin(int elementIndex = 0)
		{
			if ((uint)elementIndex >= (uint)(length * sizeof(TFrom) / sizeof(TTo)))
			{
				ThrowArgumentExceptionForInvalidIndex();
			}
			int num = offset * sizeof(TFrom);
			int num2 = elementIndex * sizeof(TTo);
			int result;
			int elementIndex2 = Math.DivRem(num + num2, sizeof(TFrom), out result);
			if (result != 0)
			{
				ThrowArgumentExceptionForInvalidAlignment();
			}
			return memoryManager.Pin(elementIndex2);
		}

		public override void Unpin()
		{
			memoryManager.Unpin();
		}

		protected override void Dispose(bool disposing)
		{
			((IDisposable)memoryManager).Dispose();
		}

		public Memory<T> GetMemory<T>(int offset, int length) where T : unmanaged
		{
			int start = this.offset + RuntimeHelpers.ConvertLength<TTo, TFrom>(offset);
			int num = RuntimeHelpers.ConvertLength<TTo, TFrom>(length);
			if (typeof(T) == typeof(TFrom))
			{
				return (Memory<T>)(object)memoryManager.Memory.Slice(start, num);
			}
			return new ProxyMemoryManager<TFrom, T>(memoryManager, start, num).Memory;
		}

		private static void ThrowArgumentExceptionForInvalidIndex()
		{
			throw new ArgumentOutOfRangeException("elementIndex", "The input index is not in the valid range");
		}

		private static void ThrowArgumentExceptionForInvalidAlignment()
		{
			throw new ArgumentOutOfRangeException("elementIndex", "The input index doesn't result in an aligned item access");
		}
	}
}
