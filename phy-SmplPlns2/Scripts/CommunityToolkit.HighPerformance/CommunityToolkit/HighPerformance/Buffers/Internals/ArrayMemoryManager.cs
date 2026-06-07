using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance.Buffers.Internals
{
	internal sealed class ArrayMemoryManager<TFrom, TTo> : MemoryManager<TTo>, IMemoryManager where TFrom : unmanaged where TTo : unmanaged
	{
		private readonly TFrom[] array;

		private readonly int offset;

		private readonly int length;

		public ArrayMemoryManager(TFrom[] array, int offset, int length)
		{
			this.array = array;
			this.offset = offset;
			this.length = length;
		}

		public override Span<TTo> GetSpan()
		{
			ref TTo reference = ref Unsafe.As<TFrom, TTo>(ref array.DangerousGetReferenceAt(offset));
			int num = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.ConvertLength<TFrom, TTo>(length);
			return MemoryMarshal.CreateSpan(ref reference, num);
		}

		public unsafe override MemoryHandle Pin(int elementIndex = 0)
		{
			if ((uint)elementIndex >= (uint)(length * sizeof(TFrom) / sizeof(TTo)))
			{
				ThrowArgumentOutOfRangeExceptionForInvalidIndex();
			}
			nint num = offset * sizeof(TFrom);
			nint num2 = elementIndex * sizeof(TTo);
			nint byteOffset = num + num2;
			GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
			return new MemoryHandle(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref Unsafe.As<TFrom, byte>(ref array.DangerousGetReference()), byteOffset)), handle);
		}

		public override void Unpin()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public Memory<T> GetMemory<T>(int offset, int length) where T : unmanaged
		{
			int start = this.offset + CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.ConvertLength<TTo, TFrom>(offset);
			int num = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.ConvertLength<TTo, TFrom>(length);
			if (typeof(T) == typeof(TFrom))
			{
				return (Memory<T>)(object)array.AsMemory(start, num);
			}
			return new ArrayMemoryManager<TFrom, T>(array, start, num).Memory;
		}

		private static void ThrowArgumentOutOfRangeExceptionForInvalidIndex()
		{
			throw new ArgumentOutOfRangeException("elementIndex", "The input index is not in the valid range");
		}
	}
}
