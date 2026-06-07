using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers.Views;

namespace CommunityToolkit.HighPerformance.Buffers
{
	[DebuggerTypeProxy(typeof(MemoryDebugView<>))]
	[DebuggerDisplay("{ToString(),raw}")]
	public sealed class MemoryOwner<T> : IMemoryOwner<T>, IDisposable
	{
		private readonly int start;

		private readonly int length;

		private readonly ArrayPool<T> pool;

		private T[]? array;

		public static MemoryOwner<T> Empty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new MemoryOwner<T>(0, ArrayPool<T>.Shared, AllocationMode.Default);
			}
		}

		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return length;
			}
		}

		public Memory<T> Memory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				T[]? obj = array;
				if (obj == null)
				{
					ThrowObjectDisposedException();
				}
				return new Memory<T>(obj, start, length);
			}
		}

		public Span<T> Span
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				T[]? obj = array;
				if (obj == null)
				{
					ThrowObjectDisposedException();
				}
				return new Span<T>(obj, start, length);
			}
		}

		private MemoryOwner(int length, ArrayPool<T> pool, AllocationMode mode)
		{
			start = 0;
			this.length = length;
			this.pool = pool;
			array = pool.Rent(length);
			if (mode == AllocationMode.Clear)
			{
				array.AsSpan(0, length).Clear();
			}
		}

		private MemoryOwner(int start, int length, ArrayPool<T> pool, T[] array)
		{
			this.start = start;
			this.length = length;
			this.pool = pool;
			this.array = array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MemoryOwner<T> Allocate(int size)
		{
			return new MemoryOwner<T>(size, ArrayPool<T>.Shared, AllocationMode.Default);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MemoryOwner<T> Allocate(int size, ArrayPool<T> pool)
		{
			return new MemoryOwner<T>(size, pool, AllocationMode.Default);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MemoryOwner<T> Allocate(int size, AllocationMode mode)
		{
			return new MemoryOwner<T>(size, ArrayPool<T>.Shared, mode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MemoryOwner<T> Allocate(int size, ArrayPool<T> pool, AllocationMode mode)
		{
			return new MemoryOwner<T>(size, pool, mode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref T DangerousGetReference()
		{
			T[]? obj = array;
			if (obj == null)
			{
				ThrowObjectDisposedException();
			}
			return ref obj.DangerousGetReferenceAt(start);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ArraySegment<T> DangerousGetArray()
		{
			T[]? obj = array;
			if (obj == null)
			{
				ThrowObjectDisposedException();
			}
			return new ArraySegment<T>(obj, start, length);
		}

		public MemoryOwner<T> Slice(int start, int length)
		{
			T[] array = this.array;
			if (array == null)
			{
				ThrowObjectDisposedException();
			}
			this.array = null;
			if ((uint)start > this.length)
			{
				ThrowInvalidOffsetException();
			}
			if ((uint)length > this.length - start)
			{
				ThrowInvalidLengthException();
			}
			GC.SuppressFinalize(this);
			return new MemoryOwner<T>(start, length, pool, array);
		}

		public void Dispose()
		{
			T[] array = this.array;
			if (array != null)
			{
				this.array = null;
				pool.Return(array);
			}
		}

		public override string ToString()
		{
			if (typeof(T) == typeof(char) && array is char[] value)
			{
				return new string(value, start, length);
			}
			return $"CommunityToolkit.HighPerformance.Buffers.MemoryOwner<{typeof(T)}>[{length}]";
		}

		private static void ThrowObjectDisposedException()
		{
			throw new ObjectDisposedException("MemoryOwner", "The current buffer has already been disposed");
		}

		private static void ThrowInvalidOffsetException()
		{
			throw new ArgumentOutOfRangeException("start", "The input start parameter was not valid");
		}

		private static void ThrowInvalidLengthException()
		{
			throw new ArgumentOutOfRangeException("length", "The input length parameter was not valid");
		}
	}
}
