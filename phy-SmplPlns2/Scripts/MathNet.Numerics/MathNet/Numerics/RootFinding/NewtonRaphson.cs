using System;

namespace MathNet.Numerics.RootFinding
{
	public static class NewtonRaphson
	{
		public static double FindRoot(Func<double, double> f, Func<double, double> df, double lowerBound, double upperBound, double accuracy = 1E-08, int maxIterations = 100)
		{
			if (TryFindRoot(f, df, 0.5 * (lowerBound + upperBound), lowerBound, upperBound, accuracy, maxIterations, out var root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds. Consider to use RobustNewtonRaphson instead.");
		}

		public static double FindRootNearGuess(Func<double, double> f, Func<double, double> df, double initialGuess, double lowerBound = double.MinValue, double upperBound = double.MaxValue, double accuracy = 1E-08, int maxIterations = 100)
		{
			if (TryFindRoot(f, df, initialGuess, lowerBound, upperBound, accuracy, maxIterations, out var root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds. Consider to use RobustNewtonRaphson instead.");
		}

		public static bool TryFindRoot(Func<double, double> f, Func<double, double> df, double initialGuess, double lowerBound, double upperBound, double accuracy, int maxIterations, out double root)
		{
			if (accuracy <= 0.0)
			{
				throw new ArgumentOutOfRangeException("accuracy", "Must be greater than zero.");
			}
			root = initialGuess;
			for (int i = 0; i < maxIterations; i++)
			{
				if (!(root >= lowerBound))
				{
					break;
				}
				if (!(root <= upperBound))
				{
					break;
				}
				double num = f(root);
				if (num == 0.0)
				{
					return true;
				}
				double num2 = df(root);
				double num3 = num / num2;
				root -= num3;
				if (Math.Abs(num3) < accuracy && Math.Abs(num) < accuracy)
				{
					return true;
				}
			}
			return false;
		}
	}
}
