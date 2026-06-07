using System;

namespace BCnEncoder.Shared
{
	public static class MathHelper
	{
		private static double two54 = 18014398509481984.0;

		public unsafe static double FrExp(double x, out int eptr)
		{
			int num = *(1 + (int*)(&x));
			int num2 = 0x7FFFFFFF & num;
			int num3 = *(int*)(&x);
			eptr = 0;
			if (num2 >= 2146435072 || (num2 | num3) == 0)
			{
				return x;
			}
			if (num2 < 1048576)
			{
				x *= two54;
				num = *(1 + (int*)(&x));
				num2 = num & 0x7FFFFFFF;
				eptr = -54;
			}
			eptr += (num2 >> 20) - 1022;
			num = (num & -2146435073) | 0x3FE00000;
			*(1 + (int*)(&x)) = num;
			return x;
		}

		public static float LdExp(float arg, int exp)
		{
			return arg * MathF.Pow(2f, exp);
		}
	}
}
