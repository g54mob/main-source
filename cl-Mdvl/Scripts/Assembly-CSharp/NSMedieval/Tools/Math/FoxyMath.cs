using System;

namespace NSMedieval.Tools.Math
{
	public static class FoxyMath
	{
		public static int RoundUpToNextMultipleMod1(int v, int d)
		{
			return v + (4 - (v - 1) % d) % d;
		}

		public static int NextPowerOfTwo(int v)
		{
			bool num = v < 0;
			v = System.Math.Abs(v);
			v--;
			v |= v >> 1;
			v |= v >> 2;
			v |= v >> 4;
			v |= v >> 8;
			v |= v >> 16;
			v++;
			if (!num)
			{
				return v;
			}
			return -v;
		}
	}
}
