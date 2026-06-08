using System;
using System.Runtime.CompilerServices;

namespace RTLTMPro
{
	public class FastStringBuilder
	{
		private int length;

		private char[] array;

		private int capacity;

		public int Length
		{
			get
			{
				return length;
			}
			set
			{
				if (value <= length)
				{
					length = value;
				}
			}
		}

		public FastStringBuilder(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			this.capacity = capacity;
			array = new char[capacity];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public char Get(int index)
		{
			return array[index];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int index, char ch)
		{
			array[index] = ch;
		}

		public void SetValue(string text)
		{
			length = text.Length;
			EnsureCapacity(length, keepValues: false);
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = text[i];
			}
		}

		public void SetValue(FastStringBuilder other)
		{
			EnsureCapacity(other.length, keepValues: false);
			Copy(other.array, array);
			length = other.length;
		}

		public void Append(char ch)
		{
			length++;
			if (capacity < length)
			{
				EnsureCapacity(length, keepValues: true);
			}
			array[length - 1] = ch;
		}

		public void Insert(int pos, char ch)
		{
			length++;
			EnsureCapacity(length, keepValues: true);
			for (int num = length - 2; num >= pos; num--)
			{
				array[num + 1] = array[num];
			}
			array[pos] = ch;
		}

		public void Reverse(int startIndex, int length)
		{
			for (int i = 0; i < length / 2; i++)
			{
				int num = startIndex + i;
				int num2 = startIndex + length - i - 1;
				char c = array[num];
				char c2 = array[num2];
				array[num] = c2;
				array[num2] = c;
			}
		}

		public void Reverse()
		{
			Reverse(0, length);
		}

		public override string ToString()
		{
			return new string(array, 0, length);
		}

		public void Replace(char oldChar, char newChar)
		{
			for (int i = 0; i < length; i++)
			{
				if (array[i] == oldChar)
				{
					array[i] = newChar;
				}
			}
		}

		public void Clear()
		{
			length = 0;
		}

		private void EnsureCapacity(int cap, bool keepValues)
		{
			if (capacity < cap)
			{
				if (capacity == 0)
				{
					capacity = 1;
				}
				while (capacity < cap)
				{
					capacity *= 2;
				}
				if (keepValues)
				{
					char[] dst = new char[capacity];
					Copy(array, dst);
					array = dst;
				}
				else
				{
					array = new char[capacity];
				}
			}
		}

		private static void Copy(char[] src, char[] dst)
		{
			for (int i = 0; i < src.Length; i++)
			{
				dst[i] = src[i];
			}
		}
	}
}
