namespace NSMedieval.Extensions
{
	public static class IntegerExtensions
	{
		public static bool Even(this int x)
		{
			return x % 2 == 0;
		}

		public static bool Odd(this int x)
		{
			return x % 2 != 0;
		}

		public static bool WithinRange(this int input, int min, int max)
		{
			if (input >= min)
			{
				return input <= max;
			}
			return false;
		}
	}
}
