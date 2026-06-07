using System;
using System.Runtime.CompilerServices;

namespace LitMotion
{
	internal static class ArrayHelper
	{
		private const int ArrayMaxSize = 2147483591;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void EnsureCapacity<T>(ref T[] array, int minimumCapacity)
		{
			if (array == null)
			{
				array = new T[minimumCapacity];
				return;
			}
			int num = array.Length;
			if (num < minimumCapacity)
			{
				while (num < minimumCapacity)
				{
					num *= 2;
				}
				Array.Resize(ref array, num);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void EnsureBufferCapacity(ref char[] buffer, int minimumCapacity)
		{
			if (buffer == null)
			{
				Error.ArgumentNull("buffer");
			}
			int num = buffer.Length;
			if (minimumCapacity <= num)
			{
				return;
			}
			int num2 = minimumCapacity;
			if (num2 < 256)
			{
				num2 = 256;
				FastResize(ref buffer, num2);
				return;
			}
			if (num == 2147483591)
			{
				throw new InvalidOperationException("char[] size reached maximum size of array(0x7FFFFFC7).");
			}
			int num3 = num * 2;
			if (num3 < 0)
			{
				num2 = 2147483591;
			}
			else if (num2 < num3)
			{
				num2 = num3;
			}
			FastResize(ref buffer, num2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void FastResize(ref char[] array, int newSize)
		{
			if (newSize < 0)
			{
				throw new ArgumentOutOfRangeException("newSize");
			}
			char[] array2 = array;
			if (array2 == null)
			{
				array = new char[newSize];
			}
			else if (array2.Length != newSize)
			{
				char[] array3 = new char[newSize];
				Buffer.BlockCopy(array2, 0, array3, 0, (array2.Length > newSize) ? newSize : array2.Length);
				array = array3;
			}
		}
	}
}
