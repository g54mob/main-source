namespace DV
{
	public static class NumberUtils
	{
		public static bool IsPowerOfTwo(int value)
		{
			if (value > 0)
			{
				return (value & (value - 1)) == 0;
			}
			return false;
		}
	}
}
