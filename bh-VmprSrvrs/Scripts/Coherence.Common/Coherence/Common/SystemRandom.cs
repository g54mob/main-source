using System;

namespace Coherence.Common
{
	public class SystemRandom : IRandom
	{
		private readonly Random random;

		public SystemRandom(Random random = null)
		{
		}

		public double NextDouble()
		{
			return 0.0;
		}

		public double NextNormalDistribution(double mean, double deviation)
		{
			return 0.0;
		}
	}
}
