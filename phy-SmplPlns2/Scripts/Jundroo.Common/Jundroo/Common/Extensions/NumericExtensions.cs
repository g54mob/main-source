namespace Jundroo.Common.Extensions
{
	public static class NumericExtensions
	{
		public static short ClampToInt16(this int value, short min = short.MinValue, short max = short.MaxValue)
		{
			if (value > max)
			{
				return max;
			}
			if (value < min)
			{
				return min;
			}
			return (short)value;
		}

		public static short ClampToInt16(this float value, short min = short.MinValue, short max = short.MaxValue)
		{
			if (value > (float)max)
			{
				return max;
			}
			if (value < (float)min)
			{
				return min;
			}
			return (short)value;
		}
	}
}
