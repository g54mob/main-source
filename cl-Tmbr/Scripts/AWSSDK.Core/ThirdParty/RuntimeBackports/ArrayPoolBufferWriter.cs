using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ThirdParty.RuntimeBackports
{
	public sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IMemoryOwner<T>, IDisposable
	{
		private const int DefaultInitialBufferSize = 256;

		private readonly ArrayPool<T> pool;

		private T[]? array;

		private int index;

		Memory<T> IMemoryOwner<T>.Memory => MemoryMarshal.AsMemory(WrittenMemory);

		public ReadOnlyMemory<T> WrittenMemory
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				T[]? obj = array;
				if (obj == null)
				{
					ThrowObjectDisposedException();
				}
				return obj.AsMemory(0, index);
			}
		}

		public ReadOnlySpan<T> WrittenSpan
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				T[]? obj = array;
				if (obj == null)
				{
					ThrowObjectDisposedException();
				}
				return obj.AsSpan(0, index);
			}
		}

		public int WrittenCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return index;
			}
		}

		public int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				T[]? obj = array;
				if (obj == null)
				{
					ThrowObjectDisposedException();
				}
				return obj.Length;
			}
		}

		public int FreeCapacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				T[]? obj = array;
				if (obj == null)
				{
					ThrowObjectDisposedException();
				}
				return obj.Length - index;
			}
		}

		public ArrayPoolBufferWriter()
			: this(ArrayPool<T>.Shared, 256)
		{
		}

		public ArrayPoolBufferWriter(ArrayPool<T> pool)
			: this(pool, 256)
		{
		}

		public ArrayPoolBufferWriter(int initialCapacity)
			: this(ArrayPool<T>.Shared, initialCapacity)
		{
		}

		public ArrayPoolBufferWriter(ArrayPool<T> pool, int initialCapacity)
		{
			this.pool = pool;
			array = pool.Rent(initialCapacity);
			index = 0;
		}

		public void Clear()
		{
			T[]? obj = array;
			if (obj == null)
			{
				ThrowObjectDisposedException();
			}
			obj.AsSpan(0, index).Clear();
			index = 0;
		}

		public void Advance(int count)
		{
			T[] array = this.array;
			if (array == null)
			{
				ThrowObjectDisposedException();
			}
			if (count < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeCount();
			}
			if (index > array.Length - count)
			{
				ThrowArgumentExceptionForAdvancedTooFar();
			}
			index += count;
		}

		public Memory<T> GetMemory(int sizeHint = 0)
		{
			CheckBufferAndEnsureCapacity(sizeHint);
			return array.AsMemory(index);
		}

		public Span<T> GetSpan(int sizeHint = 0)
		{
			CheckBufferAndEnsureCapacity(sizeHint);
			return array.AsSpan(index);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ArraySegment<T> DangerousGetArray()
		{
			T[]? obj = array;
			if (obj == null)
			{
				ThrowObjectDisposedException();
			}
			return new ArraySegment<T>(obj, 0, index);
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
				return new string(value, 0, index);
			}
			return $"CommunityToolkit.HighPerformance.Buffers.ArrayPoolBufferWriter<{typeof(T)}>[{index}]";
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckBufferAndEnsureCapacity(int sizeHint)
		{
			T[] array = this.array;
			if (array == null)
			{
				ThrowObjectDisposedException();
			}
			if (sizeHint < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeSizeHint();
			}
			if (sizeHint == 0)
			{
				sizeHint = 1;
			}
			if (sizeHint > array.Length - index)
			{
				ResizeBuffer(sizeHint);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ResizeBuffer(int sizeHint)
		{
			uint num = (uint)(index + sizeHint);
			if (num > 1048576)
			{
				num = BitOperations.RoundUpToPowerOf2(num);
			}
			pool.Resize(ref array, (int)num);
		}

		private static void ThrowArgumentOutOfRangeExceptionForNegativeCount()
		{
			throw new ArgumentOutOfRangeException("count", "The count can't be a negative value.");
		}

		private static void ThrowArgumentOutOfRangeExceptionForNegativeSizeHint()
		{
			throw new ArgumentOutOfRangeException("sizeHint", "The size hint can't be a negative value.");
		}

		private static void ThrowArgumentExceptionForAdvancedTooFar()
		{
			throw new ArgumentException("The buffer writer has advanced too far.");
		}

		private static void ThrowObjectDisposedException()
		{
			throw new ObjectDisposedException("The current buffer has already been disposed.");
		}
	}
}
