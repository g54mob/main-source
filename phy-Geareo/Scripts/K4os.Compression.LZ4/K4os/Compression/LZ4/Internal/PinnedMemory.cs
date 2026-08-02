using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace K4os.Compression.LZ4.Internal
{
	public struct PinnedMemory
	{
		private unsafe byte* _pointer;

		private GCHandle _handle;

		private int _size;

		public static int MaxPooledSize { get; set; }

		public unsafe readonly byte* Pointer
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return null;
			}
		}

		public Span<byte> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(Span<byte>);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe readonly T* Reference<T>() where T : unmanaged
		{
			return null;
		}

		public static PinnedMemory Alloc(int size, bool zero = true)
		{
			return default(PinnedMemory);
		}

		public static void Alloc(out PinnedMemory memory, int size, bool zero = true)
		{
			memory = default(PinnedMemory);
		}

		public static void Alloc<T>(out PinnedMemory memory, bool zero = true) where T : struct
		{
			memory = default(PinnedMemory);
		}

		private static void AllocateNative(out PinnedMemory memory, int size, bool zero)
		{
			memory = default(PinnedMemory);
		}

		private static void RentManagedFromPool(out PinnedMemory memory, int size, bool zero)
		{
			memory = default(PinnedMemory);
		}

		public void Clear()
		{
		}

		public void Free()
		{
		}

		private void ReleaseManaged()
		{
		}

		private void ReleaseNative()
		{
		}

		private void ClearFields()
		{
		}
	}
}
