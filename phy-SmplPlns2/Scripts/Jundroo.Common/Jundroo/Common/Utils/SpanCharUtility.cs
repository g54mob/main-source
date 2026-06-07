using System;

namespace Jundroo.Common.Utils
{
	public static class SpanCharUtility
	{
		public static int GetLength(int value)
		{
			if (value >= 0)
			{
				if (value < 10)
				{
					return 1;
				}
				if (value < 100)
				{
					return 2;
				}
				if (value < 1000)
				{
					return 3;
				}
				if (value < 10000)
				{
					return 4;
				}
				if (value < 100000)
				{
					return 5;
				}
				if (value < 1000000)
				{
					return 6;
				}
				if (value < 10000000)
				{
					return 7;
				}
				if (value < 100000000)
				{
					return 8;
				}
				if (value < 1000000000)
				{
					return 9;
				}
				return 10;
			}
			if (value > -10)
			{
				return 2;
			}
			if (value > -100)
			{
				return 3;
			}
			if (value > -1000)
			{
				return 4;
			}
			if (value > -10000)
			{
				return 5;
			}
			if (value > -100000)
			{
				return 6;
			}
			if (value > -1000000)
			{
				return 7;
			}
			if (value > -10000000)
			{
				return 8;
			}
			if (value > -100000000)
			{
				return 9;
			}
			if (value > -1000000000)
			{
				return 10;
			}
			return 11;
		}

		public static void Write(Span<char> chars, int length, ref int position, int value)
		{
			if (value < 0)
			{
				value = -value;
				length--;
				chars[position++] = '-';
			}
			for (int num = length - 1; num >= 0; num--)
			{
				chars[position + num] = (char)(48 + value % 10);
				value /= 10;
			}
			position += length;
		}

		public static void Write(Span<char> chars, int length, int value)
		{
			int position = 0;
			Write(chars, length, ref position, value);
		}

		public static void Write(Span<char> chars, ref int position, string value)
		{
			int length = value.Length;
			for (int i = 0; i < length; i++)
			{
				chars[position++] = value[i];
			}
		}
	}
}
