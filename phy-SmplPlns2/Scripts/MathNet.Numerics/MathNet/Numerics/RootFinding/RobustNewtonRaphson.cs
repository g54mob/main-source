using System;

namespace MathNet.Numerics.RootFinding
{
	public static class RobustNewtonRaphson
	{
		public static double FindRoot(Func<double, double> f, Func<double, double> df, double lowerBound, double upperBound, double accuracy = 1E-08, int maxIterations = 100, int subdivision = 20)
		{
			if (TryFindRoot(f, df, lowerBound, upperBound, accuracy, maxIterations, subdivision, out var root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds.");
		}

		public static bool TryFindRoot(Func<double, double> f, Func<double, double> df, double lowerBound, double upperBound, double accuracy, int maxIterations, int subdivision, out double root)
		{
			if (accuracy <= 0.0)
			{
				throw new ArgumentOutOfRangeException("accuracy", "Must be greater than zero.");
			}
			if (double.IsInfinity(lowerBound))
			{
				throw new ArgumentOutOfRangeException("lowerBound", "Must be a finite number.");
			}
			if (double.IsInfinity(upperBound))
			{
				throw new ArgumentOutOfRangeException("upperBound", "Must be a finite number.");
			}
			root = lowerBound + 0.5 * (upperBound - lowerBound);
			double num = f(root);
			if (Math.Abs(num) < accuracy)
			{
				return true;
			}
			double num2 = f(lowerBound);
			double num3 = f(upperBound);
			if (Math.Abs(num2) < accuracy)
			{
				root = lowerBound;
				return true;
			}
			if (Math.Abs(num3) < accuracy)
			{
				root = upperBound;
				return true;
			}
			double num4 = Math.Abs(upperBound - lowerBound);
			for (int i = 0; i < maxIterations; i++)
			{
				double num5 = df(root);
				double num6 = num / num5;
				root -= num6;
				if (Math.Abs(num6) < accuracy && Math.Abs(num) < accuracy)
				{
					return true;
				}
				bool flag = root > upperBound;
				bool flag2 = root < lowerBound;
				if (flag || flag2 || Math.Abs(2.0 * num) > Math.Abs(num4 * num5))
				{
					if (Math.Sign(num2) == Math.Sign(num3) && TryScanForCrossingsWithRoots(f, df, lowerBound, upperBound, accuracy, maxIterations - i - 1, subdivision, out root))
					{
						return true;
					}
					root = 0.5 * (upperBound + lowerBound);
					num = f(root);
					if (num == 0.0)
					{
						return true;
					}
					num4 = 0.5 * Math.Abs(upperBound - lowerBound);
					if (Math.Sign(num) == Math.Sign(num2))
					{
						lowerBound = root;
						num2 = num;
						if (flag)
						{
							root = upperBound;
							num = num3;
						}
					}
					else
					{
						upperBound = root;
						num3 = num;
						if (flag2)
						{
							root = lowerBound;
							num = num2;
						}
					}
				}
				else
				{
					num = f(root);
					if (num == 0.0)
					{
						return true;
					}
					num4 = num6;
					if (Math.Sign(num) != Math.Sign(num2))
					{
						upperBound = root;
						num3 = num;
					}
					else if (Math.Sign(num) != Math.Sign(num3))
					{
						lowerBound = root;
						num2 = num;
					}
					else if (Math.Sign(num2) != Math.Sign(num3) && Math.Abs(num) < accuracy)
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool TryScanForCrossingsWithRoots(Func<double, double> f, Func<double, double> df, double lowerBound, double upperBound, double accuracy, int maxIterations, int subdivision, out double root)
		{
			foreach (var (lowerBound2, upperBound2) in ZeroCrossingBracketing.FindIntervalsWithin(f, lowerBound, upperBound, subdivision))
			{
				if (TryFindRoot(f, df, lowerBound2, upperBound2, accuracy, maxIterations, subdivision, out root))
				{
					return true;
				}
			}
			root = double.NaN;
			return false;
		}
	}
}
