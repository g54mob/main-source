using System;

namespace Extensions.SystemRandom
{
	public static class SystemRandomExtension
	{
		public static double NextDouble(this Random rand, double max)
		{
			return rand.NextDouble() * max;
		}

		public static double NextDouble(this Random rand, double min, double max)
		{
			return min + rand.NextDouble() * (max - min);
		}

		public static float NextFloat(this Random rand, float max)
		{
			return (float)rand.NextDouble() * max;
		}

		public static float NextFloat(this Random rand, float min, float max)
		{
			return min + (float)rand.NextDouble() * (max - min);
		}
	}
}
