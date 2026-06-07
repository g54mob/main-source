using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
	internal static class Int32
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNumber(char c)
		{
			if ('0' <= c)
			{
				return c <= '9';
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Parse(ReadOnlySpan<char> s)
		{
			long num = 0L;
			int num2 = 1;
			if (s[0] == '-')
			{
				num2 = -1;
			}
			for (int i = ((num2 == -1) ? 1 : 0); i < s.Length && IsNumber(s[i]); i++)
			{
				num = num * 10 + ((byte)s[i] - 48);
			}
			checked
			{
				return (int)unchecked(num * num2);
			}
		}
	}
}
