using System;

namespace MathNet.Numerics.RootFinding
{
	public static class Bisection
	{
		public static double FindRootExpand(Func<double, double> f, double guessLowerBound, double guessUpperBound, double accuracy = 1E-08, int maxIterations = 100, double expandFactor = 1.6, int maxExpandIteratons = 100)
		{
			ZeroCrossingBracketing.ExpandReduce(f, ref guessLowerBound, ref guessUpperBound, expandFactor, maxExpandIteratons, maxExpandIteratons * 10);
			return FindRoot(f, guessLowerBound, guessUpperBound, accuracy, maxIterations);
		}

		public static double FindRoot(Func<double, double> f, double lowerBound, double upperBound, double accuracy = 1E-14, int maxIterations = 100)
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
			if (upperBound < lowerBound)
			{
				double num = lowerBound;
				lowerBound = upperBound;
				upperBound = num;
			}
			double value = f(lowerBound);
			if (Math.Sign(value) == 0)
			{
				root = lowerBound;
				return true;
			}
			double value2 = f(upperBound);
			if (Math.Sign(value2) == 0)
			{
				root = upperBound;
				return true;
			}
			root = 0.5 * (lowerBound + upperBound);
			if (Math.Sign(value) == Math.Sign(value2))
			{
				return false;
			}
			for (int i = 0; i <= maxIterations; i++)
			{
				double num2 = f(root);
				if (upperBound - lowerBound <= 2.0 * accuracy && Math.Abs(num2) <= accuracy)
				{
					return true;
				}
				if (lowerBound == root || upperBound == root)
				{
					return false;
				}
				if (Math.Sign(num2) == Math.Sign(value))
				{
					lowerBound = root;
					value = num2;
				}
				else
				{
					if (Math.Sign(num2) != Math.Sign(value2))
					{
						return true;
					}
					upperBound = root;
					value2 = num2;
				}
				root = 0.5 * (lowerBound + upperBound);
			}
			return false;
		}
	}
}
