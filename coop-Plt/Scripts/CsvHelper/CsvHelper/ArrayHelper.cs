using System.Runtime.CompilerServices;

namespace CsvHelper
{
	public static class ArrayHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Trim(char[] buffer, ref int start, ref int length, char[] trimChars)
		{
			for (int i = start; i < start + length; i++)
			{
				char c = buffer[i];
				if (!Contains(trimChars, in c))
				{
					break;
				}
				start++;
				length--;
			}
			int num = start + length - 1;
			while (num > start)
			{
				char c2 = buffer[num];
				if (Contains(trimChars, in c2))
				{
					length--;
					num--;
					continue;
				}
				break;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Contains(char[] array, in char c)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == c)
				{
					return true;
				}
			}
			return false;
		}
	}
}
