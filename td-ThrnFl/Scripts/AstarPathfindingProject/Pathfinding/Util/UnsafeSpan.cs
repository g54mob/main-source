using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pathfinding.Util
{
	public readonly struct UnsafeSpan<T> where T : unmanaged
	{
		[NativeDisableUnsafePtrRestriction]
		internal unsafe readonly T* ptr;

		internal readonly uint length;

		public int Length => (int)length;

		public unsafe ref T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if ((uint)index >= length)
				{
					throw new IndexOutOfRangeException();
				}
				Hint.Assume(ptr != null);
				return ref ptr[index];
			}
		}

		public unsafe ref T this[uint index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (index >= length)
				{
					throw new IndexOutOfRangeException();
				}
				Hint.Assume(ptr != null);
				Hint.Assume(ptr + index != null);
				return ref ptr[index];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe UnsafeSpan(void* ptr, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (length > 0 && ptr == null)
			{
				throw new ArgumentNullException();
			}
			this.ptr = (T*)ptr;
			this.length = (uint)length;
		}

		public unsafe UnsafeSpan(T[] data, out ulong gcHandle)
		{
			ptr = (T*)UnsafeUtility.PinGCArrayAndGetDataAddress(data, out gcHandle);
			length = (uint)data.Length;
		}

		public unsafe UnsafeSpan(T[,] data, out ulong gcHandle)
		{
			ptr = (T*)UnsafeUtility.PinGCArrayAndGetDataAddress(data, out gcHandle);
			length = (uint)data.Length;
		}

		public unsafe UnsafeSpan(Allocator allocator, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (length > 0)
			{
				ptr = AllocatorManager.Allocate<T>(allocator, length);
			}
			else
			{
				ptr = null;
			}
			this.length = (uint)length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe UnsafeSpan<U> Reinterpret<U>() where U : unmanaged
		{
			if (sizeof(T) != sizeof(U))
			{
				throw new InvalidOperationException("Cannot reinterpret span because the size of the types do not match");
			}
			return new UnsafeSpan<U>(ptr, (int)length);
		}

		public unsafe UnsafeSpan<T> Slice(int start, int length)
		{
			if (start < 0 || length < 0 || start + length > this.length)
			{
				throw new ArgumentOutOfRangeException();
			}
			return new UnsafeSpan<T>(ptr + start, length);
		}

		public UnsafeSpan<T> Slice(int start)
		{
			return Slice(start, (int)length - start);
		}

		public unsafe void Move(int startIndex, int toIndex, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (startIndex < 0 || startIndex + count > length)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (toIndex < 0 || toIndex + count > length)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (count != 0)
			{
				UnsafeUtility.MemMove(ptr + toIndex, ptr + startIndex, (long)sizeof(T) * (long)count);
			}
		}

		public unsafe void CopyTo(UnsafeSpan<T> other)
		{
			if (other.length < length)
			{
				throw new ArgumentException();
			}
			if (length != 0)
			{
				UnsafeUtility.MemCpy(other.ptr, ptr, sizeof(T) * length);
			}
		}

		public void CopyTo(List<T> buffer)
		{
			if (buffer.Capacity < buffer.Count + Length)
			{
				buffer.Capacity = buffer.Count + Length;
			}
			for (int i = 0; i < Length; i++)
			{
				buffer.Add(this[i]);
			}
		}

		public UnsafeSpan<T> Clone(Allocator allocator)
		{
			UnsafeSpan<T> unsafeSpan = new UnsafeSpan<T>(allocator, (int)length);
			CopyTo(unsafeSpan);
			return unsafeSpan;
		}

		public unsafe T[] ToArray()
		{
			T[] array = new T[length];
			if (length != 0)
			{
				fixed (T* destination = array)
				{
					UnsafeUtility.MemCpy(destination, ptr, sizeof(T) * length);
				}
			}
			return array;
		}

		public unsafe NativeArray<T> MoveToNativeArray(Allocator allocator)
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(ptr, Length, allocator);
		}

		public unsafe void Free(Allocator allocator)
		{
			if (length != 0)
			{
				AllocatorManager.Free(allocator, ptr, (int)length);
			}
		}

		public UnsafeSpan<T> Reallocate(Allocator allocator, int newSize)
		{
			UnsafeSpan<T> unsafeSpan = new UnsafeSpan<T>(allocator, newSize);
			Slice(0, Math.Min(newSize, Length)).CopyTo(unsafeSpan);
			Free(allocator);
			return unsafeSpan;
		}
	}
}
