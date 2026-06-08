namespace Kitchen
{
	public static class MathsHelpers
	{
		public static int Wrap(int current, int min, int max)
		{
			if (current >= min)
			{
				if (current <= max)
				{
					return current;
				}
				return min;
			}
			return max;
		}
	}
}
