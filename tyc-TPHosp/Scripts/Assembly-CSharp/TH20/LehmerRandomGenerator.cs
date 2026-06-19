namespace TH20
{
	public class LehmerRandomGenerator
	{
		private long _state = 1L;

		public LehmerRandomGenerator(long seed)
		{
			SetSeed(seed);
		}

		public void SetSeed(long seed)
		{
			_state = seed;
		}

		private double Rand()
		{
			long num = 48271 * (_state % 44488) - 3399 * (_state / 44488);
			if (num > 0)
			{
				_state = num;
			}
			else
			{
				_state = num + int.MaxValue;
			}
			return (double)_state / 2147483647.0;
		}

		public double Next()
		{
			return Rand() * 3.4028234663852886E+38;
		}

		public double Next(double min, double max)
		{
			double num = Rand();
			double num2 = max - min;
			return num * num2 + min;
		}

		public int NextInt()
		{
			return (int)(Rand() * 3.4028234663852886E+38);
		}

		public int NextRangeInt(int min, int max)
		{
			double num = Rand();
			int num2 = max - min;
			return (int)(num * (double)num2) + min;
		}
	}
}
