using System;
using System.Numerics;
using MathNet.Numerics.RootFinding;

namespace MathNet.Numerics
{
	public static class FindRoots
	{
		public static double OfFunction(Func<double, double> f, double lowerBound, double upperBound, double accuracy = 1E-08, int maxIterations = 100)
		{
			if (!ZeroCrossingBracketing.ExpandReduce(f, ref lowerBound, ref upperBound, 1.6, maxIterations, maxIterations * 10))
			{
				throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds.");
			}
			if (Brent.TryFindRoot(f, lowerBound, upperBound, accuracy, maxIterations, out var root))
			{
				return root;
			}
			if (Bisection.TryFindRoot(f, lowerBound, upperBound, accuracy, maxIterations, out root))
			{
				return root;
			}
			throw new NonConvergenceException("The algorithm has failed, exceeded the number of iterations allowed or there is no root within the provided bounds.");
		}

		public static double OfFunctionDerivative(Func<double, double> f, Func<double, double> df, double lowerBound, double upperBound, double accuracy = 1E-08, int maxIterations = 100)
		{
			if (RobustNewtonRaphson.TryFindRoot(f, df, lowerBound, upperBound, accuracy, maxIterations, 20, out var root))
			{
				return root;
			}
			return OfFunction(f, lowerBound, upperBound, accuracy, maxIterations);
		}

		public static (Complex, Complex) Quadratic(double c, double b, double a)
		{
			if (b == 0.0)
			{
				Complex complex = new Complex((0.0 - c) / a, 0.0).SquareRoot();
				return (complex, -complex);
			}
			Complex complex2 = ((b > 0.0) ? (-0.5 * (b + new Complex(b * b - 4.0 * a * c, 0.0).SquareRoot())) : (-0.5 * (b - new Complex(b * b - 4.0 * a * c, 0.0).SquareRoot())));
			return (complex2 / a, c / complex2);
		}

		public static (Complex, Complex, Complex) Cubic(double d, double c, double b, double a)
		{
			return MathNet.Numerics.RootFinding.Cubic.Roots(d, c, b, a);
		}

		public static Complex[] Polynomial(double[] coefficients)
		{
			return new Polynomial(coefficients).Roots();
		}

		public static Complex[] Polynomial(Polynomial polynomial)
		{
			return polynomial.Roots();
		}

		public static double[] ChebychevPolynomialFirstKind(int degree, double intervalBegin = -1.0, double intervalEnd = 1.0)
		{
			if (degree < 1)
			{
				return Array.Empty<double>();
			}
			double num = 0.5 * (intervalBegin + intervalEnd);
			double num2 = 0.5 * (intervalEnd - intervalBegin);
			double num3 = Math.PI / (double)(2 * degree);
			double[] array = new double[degree];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = num + num2 * Math.Cos((double)(2 * i + 1) * num3);
			}
			return array;
		}

		public static double[] ChebychevPolynomialSecondKind(int degree, double intervalBegin = -1.0, double intervalEnd = 1.0)
		{
			if (degree < 1)
			{
				return Array.Empty<double>();
			}
			double num = 0.5 * (intervalBegin + intervalEnd);
			double num2 = 0.5 * (intervalEnd - intervalBegin);
			double num3 = Math.PI / (double)(degree + 1);
			double[] array = new double[degree];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = num + num2 * Math.Cos((double)(i + 1) * num3);
			}
			return array;
		}
	}
}
