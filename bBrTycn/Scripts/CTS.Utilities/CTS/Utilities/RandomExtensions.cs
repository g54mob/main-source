using System;

namespace CTS.Utilities
{
	public static class RandomExtensions
	{
		public static void Shuffle<T>(this Random rnd, T[] array)
		{
			int num = array.Length;
			while (num > 1)
			{
				int num2 = rnd.Next(num--);
				T val = array[num2];
				array[num2] = array[num];
				array[num] = val;
			}
		}
	}
}
