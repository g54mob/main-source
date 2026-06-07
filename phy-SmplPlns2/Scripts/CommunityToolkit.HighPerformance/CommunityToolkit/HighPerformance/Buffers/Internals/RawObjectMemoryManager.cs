using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance.Helpers;

namespace CommunityToolkit.HighPerformance.Buffers.Internals
{
	internal sealed class RawObjectMemoryManager<T> : MemoryManager<T>
	{
		private readonly object instance;

		private readonly IntPtr offset;

		private readonly int length;

		public RawObjectMemoryManager(object instance, IntPtr offset, int length)
		{
			this.instance = instance;
			this.offset = offset;
			this.length = length;
		}

		public override Span<T> GetSpan()
		{
			return MemoryMarshal.CreateSpan(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(instance, offset), length);
		}

		public unsafe override MemoryHandle Pin(int elementIndex = 0)
		{
			if ((uint)elementIndex >= (uint)length)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidElementIndex();
			}
			GCHandle handle = GCHandle.Alloc(instance, GCHandleType.Pinned);
			return new MemoryHandle(Unsafe.AsPointer(ref Unsafe.Add(ref ObjectMarshal.DangerousGetObjectDataReferenceAt<T>(instance, offset), (nint)(uint)elementIndex)), handle);
		}

		public override void Unpin()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private static void ThrowArgumentOutOfRangeExceptionForInvalidElementIndex()
		{
			throw new ArgumentOutOfRangeException("elementIndex", "The input element index was not in the valid range");
		}
	}
}
