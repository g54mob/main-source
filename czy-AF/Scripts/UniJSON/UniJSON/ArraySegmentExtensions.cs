using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class ArraySegmentExtensions
	{
		public static T[] ArrayOrCopy<T>(this ArraySegment<T> self)
		{
			if (self.Array == null || self.Count == 0)
			{
				return new T[0];
			}
			if (self.Offset == 0 && self.Count == self.Array.Length)
			{
				return self.Array;
			}
			T[] array = new T[self.Count];
			Array.Copy(self.Array, self.Offset, array, 0, self.Count);
			return array;
		}

		public static IEnumerable<T> ToEnumerable<T>(this ArraySegment<T> self)
		{
			return self.Array.Skip(self.Offset).Take(self.Count);
		}

		public static void Set<T>(this ArraySegment<T> self, int index, T value)
		{
			if (index < 0 || index >= self.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			self.Array[self.Offset + index] = value;
		}

		public static T Get<T>(this ArraySegment<T> self, int index)
		{
			if (index < 0 || index >= self.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return self.Array[self.Offset + index];
		}

		public static ArraySegment<T> Advance<T>(this ArraySegment<T> self, int n)
		{
			return new ArraySegment<T>(self.Array, self.Offset + n, self.Count - n);
		}

		public static ArraySegment<T> Take<T>(this ArraySegment<T> self, int n)
		{
			return new ArraySegment<T>(self.Array, self.Offset, n);
		}

		public static T[] TakeReversedArray<T>(this ArraySegment<T> self, int n)
		{
			T[] array = new T[n];
			int num = n - 1;
			int num2 = 0;
			while (num2 < n)
			{
				array[num2] = self.Get(num);
				num2++;
				num--;
			}
			return array;
		}

		public static byte[] Concat(this byte[] lhs, ArraySegment<byte> rhs)
		{
			return new ArraySegment<byte>(lhs).Concat(rhs);
		}

		public static byte[] Concat(this ArraySegment<byte> lhs, ArraySegment<byte> rhs)
		{
			byte[] array = new byte[lhs.Count + rhs.Count];
			Buffer.BlockCopy(lhs.Array, lhs.Offset, array, 0, lhs.Count);
			Buffer.BlockCopy(rhs.Array, rhs.Offset, array, lhs.Count, rhs.Count);
			return array;
		}
	}
}
