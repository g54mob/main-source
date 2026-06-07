using System;

namespace MathNet.Numerics.Integration
{
	public static class SimpsonRule
	{
		public static double IntegrateThreePoint(Func<double, double> f, double intervalBegin, double intervalEnd)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			double arg = (intervalEnd + intervalBegin) / 2.0;
			return (intervalEnd - intervalBegin) / 6.0 * (f(intervalBegin) + f(intervalEnd) + 4.0 * f(arg));
		}

		public static double IntegrateComposite(Func<double, double> f, double intervalBegin, double intervalEnd, int numberOfPartitions)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (numberOfPartitions <= 0)
			{
				throw new ArgumentOutOfRangeException("numberOfPartitions", "Value must be positive (and not zero).");
			}
			if (numberOfPartitions.IsOdd())
			{
				throw new ArgumentException("Value must be even.", "numberOfPartitions");
			}
			double num = (intervalEnd - intervalBegin) / (double)numberOfPartitions;
			double num2 = num / 3.0;
			double num3 = num;
			int num4 = 4;
			double num5 = f(intervalBegin) + f(intervalEnd);
			for (int i = 0; i < numberOfPartitions - 1; i++)
			{
				num5 += (double)num4 * f(intervalBegin + num3);
				num4 = 6 - num4;
				num3 += num;
			}
			return num2 * num5;
		}
	}
}
