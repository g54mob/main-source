using System.Runtime.CompilerServices;

namespace RTLTMPro
{
	public class FastStringBuilder
	{
		private int length;

		private int[] array;

		private int capacity;

		public int Length
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public FastStringBuilder(int capacity)
		{
		}

		public FastStringBuilder(string text)
		{
		}

		public FastStringBuilder(string text, int capacity)
		{
		}

		public static implicit operator string(FastStringBuilder x)
		{
			return null;
		}

		public static implicit operator FastStringBuilder(string x)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Get(int index)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int index, int ch)
		{
		}

		public void SetValue(string text)
		{
		}

		public void SetValue(FastStringBuilder other)
		{
		}

		public void Append(int ch)
		{
		}

		public void Append(char ch)
		{
		}

		public void Insert(int pos, FastStringBuilder str, int offset, int count)
		{
		}

		public void Insert(int pos, FastStringBuilder str)
		{
		}

		public void Insert(int pos, int ch)
		{
		}

		public void RemoveAll(int character)
		{
		}

		public void Remove(int start, int length)
		{
		}

		public void Reverse(int startIndex, int length)
		{
		}

		public void Reverse()
		{
		}

		public void Substring(FastStringBuilder output, int start, int length)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToDebugString()
		{
			return null;
		}

		public void Replace(int oldChar, int newChar)
		{
		}

		public void Replace(FastStringBuilder oldStr, FastStringBuilder newStr)
		{
		}

		public void Clear()
		{
		}

		private void EnsureCapacity(int cap, bool keepValues)
		{
		}

		private static void Copy(int[] src, int[] dst)
		{
		}
	}
}
