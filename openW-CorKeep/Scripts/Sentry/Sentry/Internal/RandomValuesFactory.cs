namespace Sentry.Internal
{
	internal abstract class RandomValuesFactory
	{
		public abstract int NextInt();

		public abstract int NextInt(int minValue, int maxValue);

		public abstract double NextDouble();

		public abstract void NextBytes(byte[] bytes);

		public bool NextBool(double rate)
		{
			if (!(rate >= 1.0))
			{
				if (rate <= 0.0)
				{
					return false;
				}
				return NextDouble() < rate;
			}
			return true;
		}
	}
}
