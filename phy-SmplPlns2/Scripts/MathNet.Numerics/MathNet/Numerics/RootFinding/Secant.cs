using System;

namespace MathNet.Numerics.RootFinding
{
	public static class Secant
	{
		public static double FindRoot(Func<double, double> f, double guess, double secondGuess, double lowerBound = double.MinValue, double upperBound = double.MaxValue, double accuracy = 1E-08, int maxIterations = 100)
		{
			if (TryFindRoot(f, guess, secondGuess, lowerBound, upperBound, accuracy, maxIterations, out var root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds.");
		}

		public static bool TryFindRoot(Func<double, double> f, double guess, double secondGuess, double lowerBound, double upperBound, double accuracy, int maxIterations, out double root)
		{
			if (accuracy <= 0.0)
			{
				throw new ArgumentOutOfRangeException("accuracy", "Must be greater than zero.");
			}
			root = secondGuess;
			if (guess <= lowerBound || guess >= upperBound || secondGuess <= lowerBound || secondGuess >= upperBound)
			{
				return false;
			}
			double num = f(guess);
			double num2 = f(root);
			for (int i = 0; i <= maxIterations; i++)
			{
				if (!(root >= lowerBound))
				{
					break;
				}
				if (!(root <= upperBound))
				{
					break;
				}
				double num3 = num2 * (root - guess) / (num2 - num);
				guess = root;
				num = num2;
				root -= num3;
				num2 = f(root);
				if (Math.Abs(num3) < accuracy && Math.Abs(num2) < accuracy)
				{
					return true;
				}
			}
			return false;
		}
	}
}
