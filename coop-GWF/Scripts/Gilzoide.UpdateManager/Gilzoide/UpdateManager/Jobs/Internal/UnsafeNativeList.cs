using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Gilzoide.UpdateManager.Jobs.Internal
{
	public struct UnsafeNativeList<T> : IDisposable where T : struct
	{
		public const float TrimCapacityThreshold = 0.9f;

		public static readonly long SizeOfT = UnsafeUtility.SizeOf<T>();

		public static readonly int AlignOfT = UnsafeUtility.AlignOf<T>();

		[NativeDisableUnsafePtrRestriction]
		private unsafe void* _buffer;

		private int _length;

		private int _capacity;

		private Allocator Allocator;

		public int Length => _length;

		public long BufferLength => _length * SizeOfT;

		public int Capacity => _capacity;

		public unsafe T this[int index]
		{
			get
			{
				return UnsafeUtility.ReadArrayElement<T>(_buffer, index);
			}
			set
			{
				UnsafeUtility.WriteArrayElement(_buffer, index, value);
			}
		}

		public unsafe UnsafeNativeList(Allocator allocator)
		{
			_buffer = null;
			_capacity = 0;
			_length = 0;
			Allocator = allocator;
		}

		public unsafe void Dispose()
		{
			if (_buffer != null)
			{
				UnsafeUtility.Free(_buffer, Allocator);
				_buffer = null;
			}
			_capacity = 0;
			_length = 0;
		}

		public void EnsureCapacity(int capacity, bool keepData = true)
		{
			if (_capacity < capacity)
			{
				Realloc(capacity, keepData);
			}
		}

		public unsafe void Realloc(int newCapacity, bool keepData = true)
		{
			if (newCapacity == _capacity)
			{
				return;
			}
			if (newCapacity == 0)
			{
				Dispose();
				return;
			}
			void* ptr = UnsafeUtility.Malloc(newCapacity * SizeOfT, AlignOfT, Allocator);
			if (_buffer != null)
			{
				if (keepData)
				{
					UnsafeUtility.MemCpy(ptr, _buffer, Mathf.Min(_capacity, newCapacity) * SizeOfT);
				}
				UnsafeUtility.Free(_buffer, Allocator);
			}
			_buffer = ptr;
			_capacity = newCapacity;
		}

		public void Add(T value)
		{
			_length++;
			ItemRefAt(_length - 1) = value;
		}

		public void RemoveAtSwapBack(int index)
		{
			int num = _length - 1;
			if (num > 0 && num != index)
			{
				ItemRefAt(index) = ItemRefAt(num);
			}
			_length--;
		}

		public unsafe ref T ItemRefAt(int index)
		{
			return ref UnsafeUtility.ArrayElementAsRef<T>(_buffer, index);
		}

		public unsafe void CopyFrom(UnsafeNativeList<T> other)
		{
			EnsureCapacity(other._length, keepData: false);
			UnsafeUtility.MemCpy(_buffer, other._buffer, other.BufferLength);
		}

		public void TrimExcess()
		{
			if ((float)_length < (float)_capacity * 0.9f)
			{
				Realloc(_length);
			}
		}
	}
}
