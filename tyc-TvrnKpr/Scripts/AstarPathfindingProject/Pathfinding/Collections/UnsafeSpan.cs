using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;

namespace Pathfinding.Collections
{
	public readonly struct UnsafeSpan<T> where T : struct
	{
		[NativeDisableUnsafePtrRestriction]
		internal unsafe readonly T* ptr;

		internal readonly uint length;

		public readonly Allocator Allocator;

		public int Length => 0;

		public ref T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				throw null;
			}
		}

		public ref T this[uint index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe UnsafeSpan(void* ptr, int length, Allocator allocator = Allocator.None)
		{
			this.ptr = null;
			this.length = 0u;
			Allocator = default(Allocator);
		}

		public unsafe UnsafeSpan(T[] data, Allocator allocator)
		{
			ptr = null;
			length = 0u;
			Allocator = default(Allocator);
		}

		public unsafe UnsafeSpan(T[] data, out ulong gcHandle)
		{
			ptr = null;
			length = 0u;
			Allocator = default(Allocator);
			gcHandle = default(ulong);
		}

		public unsafe UnsafeSpan(T[,] data, out ulong gcHandle)
		{
			ptr = null;
			length = 0u;
			Allocator = default(Allocator);
			gcHandle = default(ulong);
		}

		public unsafe UnsafeSpan(Allocator allocator, int length)
		{
			ptr = null;
			this.length = 0u;
			Allocator = default(Allocator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public UnsafeSpan<U> Reinterpret<U>() where U : struct
		{
			return default(UnsafeSpan<U>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public UnsafeSpan<U> Reinterpret<U>(int expectedOriginalTypeSize) where U : struct
		{
			return default(UnsafeSpan<U>);
		}

		public UnsafeSpan<T> Slice(int start, int length)
		{
			return default(UnsafeSpan<T>);
		}

		public UnsafeSpan<T> Slice(int start)
		{
			return default(UnsafeSpan<T>);
		}

		public void Move(int startIndex, int toIndex, int count)
		{
		}

		public static void RemoveAt(ref UnsafeSpan<T> span, int index)
		{
		}

		public void CopyTo(UnsafeSpan<T> other)
		{
		}

		public void CopyTo(List<T> buffer)
		{
		}

		public UnsafeSpan<T> Clone(Allocator allocator)
		{
			return default(UnsafeSpan<T>);
		}

		public T[] ToArray()
		{
			return null;
		}

		public NativeArray<T> MoveToNativeArray(Allocator allocator)
		{
			return default(NativeArray<T>);
		}

		public void Free(Allocator expectedAllocator)
		{
		}

		public void Free()
		{
		}

		public UnsafeSpan<T> Reallocate(Allocator allocator, int newSize)
		{
			return default(UnsafeSpan<T>);
		}
	}
}
