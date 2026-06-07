using System;

namespace MathNet.Numerics.RootFinding
{
	public static class Brent
	{
		public static double FindRootExpand(Func<double, double> f, double guessLowerBound, double guessUpperBound, double accuracy = 1E-08, int maxIterations = 100, double expandFactor = 1.6, int maxExpandIteratons = 100)
		{
			ZeroCrossingBracketing.ExpandReduce(f, ref guessLowerBound, ref guessUpperBound, expandFactor, maxExpandIteratons, maxExpandIteratons * 10);
			return FindRoot(f, guessLowerBound, guessUpperBound, accuracy, maxIterations);
		}

		public static double FindRoot(Func<double, double> f, double lowerBound, double upperBound, double accuracy = 1E-08, int maxIterations = 100)
		{
			if (TryFindRoot(f, lowerBound, upperBound, accuracy, maxIterations, out var root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds.");
		}

		public static bool TryFindRoot(Func<double, double> f, double lowerBound, double upperBound, double accuracy, int maxIterations, out double root)
		{
			if (accuracy <= 0.0)
			{
				throw new ArgumentOutOfRangeException("accuracy", "Must be greater than zero.");
			}
			double num = f(lowerBound);
			double num2 = f(upperBound);
			double num3 = num2;
			double num4 = 0.0;
			double num5 = 0.0;
			root = upperBound;
			double num6 = double.NaN;
			if (Math.Sign(num) == Math.Sign(num2))
			{
				return false;
			}
			for (int i = 0; i <= maxIterations; i++)
			{
				if (Math.Sign(num3) == Math.Sign(num2))
				{
					upperBound = lowerBound;
					num2 = num;
					num5 = (num4 = root - lowerBound);
				}
				if (Math.Abs(num2) < Math.Abs(num3))
				{
					lowerBound = root;
					root = upperBound;
					upperBound = lowerBound;
					num = num3;
					num3 = num2;
					num2 = num;
				}
				double num7 = Precision.PositiveDoublePrecision * Math.Abs(root) + 0.5 * accuracy;
				double num8 = num6;
				num6 = (upperBound - root) / 2.0;
				if (Math.Abs(num6) <= num7 || num3.AlmostEqualNormRelative(0.0, num3, accuracy))
				{
					return true;
				}
				if (num6 == num8)
				{
					return false;
				}
				if (Math.Abs(num5) >= num7 && Math.Abs(num) > Math.Abs(num3))
				{
					double num9 = num3 / num;
					double num11;
					double num10;
					if (lowerBound.AlmostEqualRelative(upperBound))
					{
						num10 = 2.0 * num6 * num9;
						num11 = 1.0 - num9;
					}
					else
					{
						num11 = num / num2;
						double num12 = num3 / num2;
						num10 = num9 * (2.0 * num6 * num11 * (num11 - num12) - (root - lowerBound) * (num12 - 1.0));
						num11 = (num11 - 1.0) * (num12 - 1.0) * (num9 - 1.0);
					}
					if (num10 > 0.0)
					{
						num11 = 0.0 - num11;
					}
					num10 = Math.Abs(num10);
					if (2.0 * num10 < Math.Min(3.0 * num6 * num11 - Math.Abs(num7 * num11), Math.Abs(num5 * num11)))
					{
						num5 = num4;
						num4 = num10 / num11;
					}
					else
					{
						num4 = num6;
						num5 = num4;
					}
				}
				else
				{
					num4 = num6;
					num5 = num4;
				}
				lowerBound = root;
				num = num3;
				if (Math.Abs(num4) > num7)
				{
					root += num4;
				}
				else
				{
					root += Sign(num7, num6);
				}
				num3 = f(root);
			}
			return false;
		}

		private static double Sign(double a, double b)
		{
			if (!(b >= 0.0))
			{
				if (!(a >= 0.0))
				{
					return a;
				}
				return 0.0 - a;
			}
			if (!(a >= 0.0))
			{
				return 0.0 - a;
			}
			return a;
		}
	}
}
