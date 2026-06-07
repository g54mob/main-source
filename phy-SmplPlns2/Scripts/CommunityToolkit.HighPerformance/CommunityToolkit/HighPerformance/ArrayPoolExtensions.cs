using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;

namespace CommunityToolkit.HighPerformance
{
	public static class ArrayPoolExtensions
	{
		public static void Resize<T>(this ArrayPool<T> pool, [NotNull] ref T[]? array, int newSize, bool clearArray = false)
		{
			if (array == null)
			{
				array = pool.Rent(newSize);
			}
			else if (array.Length != newSize)
			{
				T[] array2 = pool.Rent(newSize);
				int length = Math.Min(array.Length, newSize);
				Array.Copy(array, 0, array2, 0, length);
				pool.Return(array, clearArray);
				array = array2;
			}
		}

		public static void EnsureCapacity<T>(this ArrayPool<T> pool, [NotNull] ref T[]? array, int capacity, bool clearArray = false)
		{
			if (capacity < 0)
			{
				ThrowArgumentOutOfRangeExceptionForNegativeArrayCapacity();
			}
			if (array == null)
			{
				array = pool.Rent(capacity);
			}
			else if (array.Length < capacity)
			{
				T[] array2 = pool.Rent(capacity);
				pool.Return(array, clearArray);
				array = array2;
			}
		}

		private static void ThrowArgumentOutOfRangeExceptionForNegativeArrayCapacity()
		{
			throw new ArgumentOutOfRangeException("capacity", "The array capacity must be a positive number.");
		}
	}
}
