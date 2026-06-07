using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding.Util
{
	public struct NativeCircularBuffer<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : unmanaged
	{
		[NativeDisableUnsafePtrRestriction]
		internal unsafe T* data;

		internal int head;

		private int length;

		private int capacityMask;

		public AllocatorManager.AllocatorHandle Allocator;

		public readonly int Length => length;

		public readonly int AbsoluteStartIndex => head;

		public readonly int AbsoluteEndIndex => head + length - 1;

		public unsafe readonly ref T First
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref data[head & capacityMask];
			}
		}

		public unsafe readonly ref T Last
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref data[(head + length - 1) & capacityMask];
			}
		}

		readonly int IReadOnlyCollection<T>.Count => Length;

		public unsafe readonly bool IsCreated => data != null;

		public unsafe T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				return data[(index + head) & capacityMask];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				data[(index + head) & capacityMask] = value;
			}
		}

		public unsafe NativeCircularBuffer(AllocatorManager.AllocatorHandle allocator)
		{
			data = null;
			Allocator = allocator;
			capacityMask = -1;
			head = 0;
			length = 0;
		}

		public unsafe NativeCircularBuffer(int initialCapacity, AllocatorManager.AllocatorHandle allocator)
		{
			initialCapacity = math.ceilpow2(initialCapacity);
			data = AllocatorManager.Allocate<T>(allocator, initialCapacity);
			capacityMask = initialCapacity - 1;
			Allocator = allocator;
			head = 0;
			length = 0;
		}

		public NativeCircularBuffer(CircularBuffer<T> buffer, out ulong gcHandle)
			: this(buffer.data, buffer.head, buffer.Length, out gcHandle)
		{
		}

		public unsafe NativeCircularBuffer(T[] data, int head, int length, out ulong gcHandle)
		{
			this.data = (T*)UnsafeUtility.PinGCArrayAndGetDataAddress(data, out gcHandle);
			capacityMask = data.Length - 1;
			this.head = head;
			this.length = length;
			Allocator = Unity.Collections.Allocator.None;
		}

		public void Clear()
		{
			length = 0;
			head = 0;
		}

		public void AddRange(List<T> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				PushEnd(items[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PushStart(T item)
		{
			if (length > capacityMask)
			{
				Grow();
			}
			length++;
			head--;
			this[0] = item;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PushEnd(T item)
		{
			if (length > capacityMask)
			{
				Grow();
			}
			length++;
			this[length - 1] = item;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Push(bool toStart, T item)
		{
			if (toStart)
			{
				PushStart(item);
			}
			else
			{
				PushEnd(item);
			}
		}

		public T PopStart()
		{
			T result = this[0];
			head++;
			length--;
			return result;
		}

		public T PopEnd()
		{
			T result = this[length - 1];
			length--;
			return result;
		}

		public T Pop(bool fromStart)
		{
			if (fromStart)
			{
				return PopStart();
			}
			return PopEnd();
		}

		public readonly T GetBoundaryValue(bool start)
		{
			if (!start)
			{
				return GetAbsolute(AbsoluteEndIndex);
			}
			return GetAbsolute(AbsoluteStartIndex);
		}

		public void TrimTo(int length)
		{
			this.length = math.min(this.length, length);
		}

		public void Splice(int startIndex, int toRemove, List<T> toInsert)
		{
			SpliceAbsolute(startIndex + head, toRemove, toInsert);
		}

		public unsafe void SpliceAbsolute(int startIndex, int toRemove, List<T> toInsert)
		{
			SpliceUninitializedAbsolute(startIndex, toRemove, toInsert.Count);
			for (int i = 0; i < toInsert.Count; i++)
			{
				data[(startIndex + i) & capacityMask] = toInsert[i];
			}
		}

		public void SpliceUninitialized(int startIndex, int toRemove, int toInsert)
		{
			SpliceUninitializedAbsolute(startIndex + head, toRemove, toInsert);
		}

		public void SpliceUninitializedAbsolute(int startIndex, int toRemove, int toInsert)
		{
			int num = toInsert - toRemove;
			while (length + num > capacityMask + 1)
			{
				Grow();
			}
			MoveAbsolute(startIndex + toRemove, AbsoluteEndIndex, num);
			length += num;
		}

		private unsafe void MoveAbsolute(int startIndex, int endIndex, int deltaIndex)
		{
			if (deltaIndex > 0)
			{
				for (int num = endIndex; num >= startIndex; num--)
				{
					data[(num + deltaIndex) & capacityMask] = data[num & capacityMask];
				}
			}
			else if (deltaIndex < 0)
			{
				for (int i = startIndex; i <= endIndex; i++)
				{
					data[(i + deltaIndex) & capacityMask] = data[i & capacityMask];
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe readonly T GetAbsolute(int index)
		{
			return data[index & capacityMask];
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe void Grow()
		{
			int num = capacityMask + 1;
			int num2 = math.max(4, num * 2);
			T* ptr = AllocatorManager.Allocate<T>(Allocator, num2);
			if (data != null)
			{
				int num3 = num - (head & capacityMask);
				UnsafeUtility.MemCpy(ptr + (head & (num2 - 1)), data + (head & capacityMask), num3 * sizeof(T));
				int num4 = length - num3;
				if (num4 > 0)
				{
					UnsafeUtility.MemCpy(ptr + ((head + num3) & (num2 - 1)), data, num4 * sizeof(T));
				}
				AllocatorManager.Free(Allocator, data);
			}
			capacityMask = num2 - 1;
			data = ptr;
		}

		public unsafe void Dispose()
		{
			capacityMask = -1;
			length = 0;
			head = 0;
			AllocatorManager.Free(Allocator, data);
			data = null;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < length; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < length; i++)
			{
				yield return this[i];
			}
		}

		public unsafe NativeCircularBuffer<T> Clone()
		{
			T* destination = AllocatorManager.Allocate<T>(Allocator, capacityMask + 1);
			UnsafeUtility.MemCpy(destination, data, length * sizeof(T));
			return new NativeCircularBuffer<T>
			{
				data = destination,
				head = head,
				length = length,
				capacityMask = capacityMask,
				Allocator = Allocator
			};
		}
	}
}
