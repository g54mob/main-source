using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding.Util
{
	public struct SlabAllocator<T> where T : unmanaged
	{
		private struct AllocatorData
		{
			public UnsafeList<byte> mem;

			public unsafe fixed int freeHeads[11];
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

			public int Length => span.Length;

			public ref T this[int index]
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return ref span[index];
				}
			}

			public List(SlabAllocator<T> allocator, int allocationIndex)
			{
				span = allocator.GetSpan(allocationIndex);
				this.allocator = allocator;
				this.allocationIndex = allocationIndex;
			}

			public void Add(T value)
			{
				allocator.Realloc(ref allocationIndex, span.Length + 1);
				span = allocator.GetSpan(allocationIndex);
				span[span.Length - 1] = value;
			}

			public void RemoveAt(int index)
			{
				span.Slice(index + 1).CopyTo(span.Slice(index, span.Length - index - 1));
				allocator.Realloc(ref allocationIndex, span.Length - 1);
				span = allocator.GetSpan(allocationIndex);
			}

			public void Clear()
			{
				allocator.Realloc(ref allocationIndex, 0);
				span = allocator.GetSpan(allocationIndex);
			}
		}

		public const int MaxAllocationSizeIndex = 10;

		private const uint UsedBit = 2147483648u;

		private const uint AllocatedBit = 1073741824u;

		private const uint LengthMask = 1073741823u;

		public const int InvalidAllocation = -2;

		public const int ZeroLengthArray = -1;

		[NativeDisableUnsafePtrRestriction]
		private unsafe AllocatorData* data;

		public unsafe bool IsCreated => data != null;

		public unsafe int ByteSize => data->mem.Length;

		public unsafe SlabAllocator(int initialCapacityBytes, AllocatorManager.AllocatorHandle allocator)
		{
			data = AllocatorManager.Allocate<AllocatorData>(allocator);
			data->mem = new UnsafeList<byte>(initialCapacityBytes, allocator);
			Clear();
		}

		public unsafe void Clear()
		{
			CheckDisposed();
			data->mem.Clear();
			for (int i = 0; i < 11; i++)
			{
				data->freeHeads[i] = -1;
			}
		}

		public unsafe UnsafeSpan<T> GetSpan(int allocatedIndex)
		{
			CheckDisposed();
			if (allocatedIndex == -1)
			{
				return new UnsafeSpan<T>(null, 0);
			}
			byte* num = data->mem.Ptr + allocatedIndex;
			Header* ptr = (Header*)num - 1;
			uint length = ptr->length & 0x3FFFFFFF;
			return new UnsafeSpan<T>(num, (int)length);
		}

		public List GetList(int allocatedIndex)
		{
			return new List(this, allocatedIndex);
		}

		public unsafe void Realloc(ref int allocatedIndex, int nElements)
		{
			CheckDisposed();
			if (allocatedIndex == -1)
			{
				allocatedIndex = Allocate(nElements);
				return;
			}
			Header* ptr = (Header*)(data->mem.Ptr + allocatedIndex) - 1;
			uint num = ptr->length & 0x3FFFFFFF;
			int num2 = ElementsToSizeIndex((int)num);
			int num3 = ElementsToSizeIndex(nElements);
			if (num2 == num3)
			{
				ptr->length = (uint)(nElements | 0x40000000 | int.MinValue);
				return;
			}
			int num4 = Allocate(nElements);
			UnsafeSpan<T> span = GetSpan(allocatedIndex);
			UnsafeSpan<T> span2 = GetSpan(num4);
			span.Slice(0, math.min((int)num, nElements)).CopyTo(span2);
			Free(allocatedIndex);
			allocatedIndex = num4;
		}

		internal static int SizeIndexToElements(int sizeIndex)
		{
			return 1 << sizeIndex;
		}

		internal static int ElementsToSizeIndex(int nElements)
		{
			if (nElements < 0)
			{
				throw new Exception("SlabAllocator cannot allocate less than 1 element");
			}
			if (nElements == 0)
			{
				return 0;
			}
			int num = CollectionHelper.Log2Ceil(nElements);
			if (num > 10)
			{
				throw new Exception("SlabAllocator cannot allocate more than 2^(MaxAllocationSizeIndex-1) elements");
			}
			return num;
		}

		public int Allocate(List<T> values)
		{
			int num = Allocate(values.Count);
			UnsafeSpan<T> span = GetSpan(num);
			for (int i = 0; i < span.Length; i++)
			{
				span[i] = values[i];
			}
			return num;
		}

		public int Allocate(NativeList<T> values)
		{
			int num = Allocate(values.Length);
			GetSpan(num).CopyFrom(values.AsArray());
			return num;
		}

		public unsafe int Allocate(int nElements)
		{
			CheckDisposed();
			if (nElements == 0)
			{
				return -1;
			}
			int num = ElementsToSizeIndex(nElements);
			int num2 = data->freeHeads[num];
			if (num2 != -1)
			{
				byte* ptr = data->mem.Ptr;
				data->freeHeads[num] = ((NextBlock*)(ptr + num2))->next;
				*((Header*)(ptr + num2) - 1) = new Header
				{
					length = (uint)(nElements | int.MinValue | 0x40000000)
				};
				return num2;
			}
			int length = data->mem.Length;
			int num3 = length + sizeof(Header) + SizeIndexToElements(num) * sizeof(T);
			if (Hint.Unlikely(num3 > data->mem.Capacity))
			{
				data->mem.SetCapacity(math.max(data->mem.Capacity * 2, num3));
			}
			data->mem.m_length = num3;
			*(Header*)(data->mem.Ptr + length) = new Header
			{
				length = (uint)(nElements | int.MinValue | 0x40000000)
			};
			return length + sizeof(Header);
		}

		public unsafe void Free(int allocatedIndex)
		{
			CheckDisposed();
			if (allocatedIndex != -1)
			{
				byte* ptr = data->mem.Ptr;
				Header* ptr2 = (Header*)(ptr + allocatedIndex) - 1;
				int num = ElementsToSizeIndex((int)(ptr2->length & 0x3FFFFFFF));
				*(NextBlock*)(ptr + allocatedIndex) = new NextBlock
				{
					next = data->freeHeads[num]
				};
				data->freeHeads[num] = allocatedIndex;
				ptr2->length &= 1073741823u;
			}
		}

		public unsafe void CopyTo(SlabAllocator<T> other)
		{
			CheckDisposed();
			other.CheckDisposed();
			other.data->mem.CopyFrom(data->mem);
			for (int i = 0; i < 11; i++)
			{
				other.data->freeHeads[i] = data->freeHeads[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckDisposed()
		{
		}

		public unsafe void Dispose()
		{
			if (data != null)
			{
				AllocatorManager.AllocatorHandle allocator = data->mem.Allocator;
				data->mem.Dispose();
				AllocatorManager.Free(allocator, data);
				data = null;
			}
		}
	}
}
