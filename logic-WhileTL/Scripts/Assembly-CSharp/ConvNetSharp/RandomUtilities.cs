using System;

namespace ConvNetSharp
{
	public static class RandomUtilities
	{
		private static readonly Random Random = new Random(Seed);

		private static double val;

		private static bool returnVal;

		public static int Seed => (int)DateTime.Now.Ticks;

		public static double GaussianRandom()
		{
			if (returnVal)
			{
				returnVal = false;
				return val;
			}
			double num = 2.0 * Random.NextDouble() - 1.0;
			double num2 = 2.0 * Random.NextDouble() - 1.0;
			double num3 = num * num + num2 * num2;
			if (num3 == 0.0 || num3 > 1.0)
			{
				return GaussianRandom();
			}
			double num4 = Math.Sqrt(-2.0 * Math.Log(num3) / num3);
			val = num2 * num4;
			returnVal = true;
			return num * num4;
		}

		public static double Randn(double mu, double std)
		{
			return mu + GaussianRandom() * std;
		}
	}
}
