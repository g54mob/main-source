using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces;
using CommunityToolkit.HighPerformance.Helpers.Internals;

namespace CommunityToolkit.HighPerformance.Buffers.Internals
{
	internal sealed class StringMemoryManager<TTo> : MemoryManager<TTo>, IMemoryManager where TTo : unmanaged
	{
		private readonly string text;

		private readonly int offset;

		private readonly int length;

		public StringMemoryManager(string text, int offset, int length)
		{
			this.text = text;
			this.offset = offset;
			this.length = length;
		}

		public override Span<TTo> GetSpan()
		{
			ref TTo reference = ref Unsafe.As<char, TTo>(ref text.DangerousGetReferenceAt(offset));
			int num = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.ConvertLength<char, TTo>(length);
			return MemoryMarshal.CreateSpan(ref reference, num);
		}

		public unsafe override MemoryHandle Pin(int elementIndex = 0)
		{
			if ((uint)elementIndex >= (uint)(length * 2 / sizeof(TTo)))
			{
				ThrowArgumentOutOfRangeExceptionForInvalidIndex();
			}
			nint num = offset * 2;
			nint num2 = elementIndex * sizeof(TTo);
			nint byteOffset = num + num2;
			GCHandle handle = GCHandle.Alloc(text, GCHandleType.Pinned);
			return new MemoryHandle(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref Unsafe.As<char, byte>(ref text.DangerousGetReference()), byteOffset)), handle);
		}

		public override void Unpin()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public Memory<T> GetMemory<T>(int offset, int length) where T : unmanaged
		{
			int start = this.offset + CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.ConvertLength<TTo, char>(offset);
			int num = CommunityToolkit.HighPerformance.Helpers.Internals.RuntimeHelpers.ConvertLength<TTo, char>(length);
			if (typeof(T) == typeof(char))
			{
				return (Memory<T>)(object)MemoryMarshal.AsMemory(text.AsMemory(start, num));
			}
			return new StringMemoryManager<T>(text, start, num).Memory;
		}

		private static void ThrowArgumentOutOfRangeExceptionForInvalidIndex()
		{
			throw new ArgumentOutOfRangeException("elementIndex", "The input index is not in the valid range");
		}
	}
}
