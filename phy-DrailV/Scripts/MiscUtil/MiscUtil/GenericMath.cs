namespace MiscUtil
{
	public static class GenericMath
	{
		public static T Abs<T>(T input)
		{
			if (!Operator<T>.GreaterThanOrEqual(input, default(T)))
			{
				return Operator<T>.Negate(input);
			}
			return input;
		}

		public static bool WithinDelta<T>(T input1, T input2, T delta)
		{
			return Operator<T>.LessThanOrEqual(Abs(Operator<T>.Subtract(input1, input2)), delta);
		}
	}
}
