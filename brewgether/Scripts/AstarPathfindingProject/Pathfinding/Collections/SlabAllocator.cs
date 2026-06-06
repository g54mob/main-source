using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pathfinding.Collections
{
	public struct SlabAllocator<T> where T : struct
	{
		private struct AllocatorData
		{
			public UnsafeList<byte> mem;

			public unsafe fixed int freeHeads[13];
		}

		private struct Header
		{
			public uint length;
		}

		private struct NextBlock
		{
			public int next;
		}

		public ref struct List
		{
			public UnsafeSpan<T> span;

			private SlabAllocator<T> allocator;

			public int allocationIndex;

			public int Length => 0;

			public ref T this[int index]
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					throw null;
				}
			}

			public List(SlabAllocator<T> allocator, int allocationIndex)
			{
				span = default(UnsafeSpan<T>);
				this.allocator = default(SlabAllocator<T>);
				this.allocationIndex = 0;
			}

			public void Add(T value)
			{
			}

			public void RemoveAt(int index)
			{
			}

			public void Clear()
			{
			}
		}

		public const int InvalidAllocation = -2;

		public const int ZeroLengthArray = -1;

		public const int MaxAllocationSizeIndex = 12;

		public const int MaxAllocationSize = 4096;

		private const uint UsedBit = 2147483648u;

		private const uint AllocatedBit = 1073741824u;

		private const uint LengthMask = 1073741823u;

		[NativeDisableUnsafePtrRestriction]
		private unsafe AllocatorData* data;

		public bool IsDebugAllocator => false;

		public bool IsCreated => false;

		public int ByteSize => 0;

		internal static int SizeIndexToElements(int sizeIndex)
		{
			return 0;
		}

		internal static int ElementsToSizeIndex(int nElements)
		{
			return 0;
		}

		public unsafe SlabAllocator(int initialCapacityBytes, AllocatorManager.AllocatorHandle allocator)
		{
			data = null;
		}

		public void Clear()
		{
		}

		public UnsafeSpan<T> GetSpan(int allocatedIndex)
		{
			return default(UnsafeSpan<T>);
		}

		public void Realloc(ref int allocatedIndex, int nElements)
		{
		}

		public int Allocate(List<T> values)
		{
			return 0;
		}

		public int Allocate(NativeList<T> values)
		{
			return 0;
		}

		public int Allocate(int nElements)
		{
			return 0;
		}

		public void Free(int allocatedIndex)
		{
		}

		public void CopyTo(SlabAllocator<T> other)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckDisposed()
		{
		}

		public void Dispose()
		{
		}

		public List GetList(int allocatedIndex)
		{
			return default(List);
		}
	}
}
