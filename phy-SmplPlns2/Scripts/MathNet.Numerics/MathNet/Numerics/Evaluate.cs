using System;

namespace MathNet.Numerics
{
	internal static class Evaluate
	{
		internal static double ChebyshevA(double[] coefficients, double x)
		{
			int num = 0;
			double num2 = coefficients[num++];
			double num3 = 0.0;
			int num4 = coefficients.Length - 1;
			double num5;
			do
			{
				num5 = num3;
				num3 = num2;
				num2 = x * num3 - num5 + coefficients[num++];
			}
			while (--num4 > 0);
			return 0.5 * (num2 - num5);
		}

		internal static double ChebyshevSum(int n, double[] coefficients, double x)
		{
			if (Math.Abs(x) < 0.6)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = x + x;
				for (int num5 = n; num5 >= 0; num5--)
				{
					num3 = num2;
					num2 = num;
					num = num4 * num2 + coefficients[num5] - num3;
				}
				return (num - num3) / 2.0;
			}
			if (x > 0.0)
			{
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = x - 0.5 - 0.5;
				num9 += num9;
				for (int num10 = n; num10 >= 0; num10--)
				{
					num8 = num7;
					double num11 = num6;
					num7 = num9 * num11 + coefficients[num10] + num8;
					num6 = num7 + num11;
				}
				return (num7 + num8) / 2.0;
			}
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = x + 0.5 + 0.5;
			num15 += num15;
			for (int num16 = n; num16 >= 0; num16--)
			{
				num14 = num13;
				double num17 = num12;
				num13 = num15 * num17 + coefficients[num16] - num14;
				num12 = num13 - num17;
			}
			return (num13 - num14) / 2.0;
		}
	}
}
