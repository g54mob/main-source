using System;

namespace NSEipix
{
	public static class RandomExtensions
	{
		public static float Range(this Random random, float minInclusive, float maxExclusive)
		{
			return minInclusive + (float)random.NextDouble() * (maxExclusive - minInclusive);
		}
	}
}
