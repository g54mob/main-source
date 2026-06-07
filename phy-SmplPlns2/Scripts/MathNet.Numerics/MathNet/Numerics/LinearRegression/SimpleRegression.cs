using System;
using System.Collections.Generic;

namespace MathNet.Numerics.LinearRegression
{
	public static class SimpleRegression
	{
		public static (double A, double B) Fit(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.Length} and {y.Length} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.Length <= 1)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {2} samples. Only {x.Length} samples have been provided.");
			}
			double num = 0.0;
			double num2 = 0.0;
			for (int i = 0; i < x.Length; i++)
			{
				num += x[i];
				num2 += y[i];
			}
			num /= (double)x.Length;
			num2 /= (double)y.Length;
			double num3 = 0.0;
			double num4 = 0.0;
			for (int j = 0; j < x.Length; j++)
			{
				double num5 = x[j] - num;
				num3 += num5 * (y[j] - num2);
				num4 += num5 * num5;
			}
			double num6 = num3 / num4;
			return (A: num2 - num6 * num, B: num6);
		}

		public static (double A, double B) Fit(IEnumerable<Tuple<double, double>> samples)
		{
			var (x, y) = samples.UnpackSinglePass();
			return Fit(x, y);
		}

		public static (double A, double B) Fit(IEnumerable<(double, double)> samples)
		{
			var (x, y) = samples.UnpackSinglePass();
			return Fit(x, y);
		}

		public static double FitThroughOrigin(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException($"All sample vectors must have the same length. However, vectors with disagreeing length {x.Length} and {y.Length} have been provided. A sample with index i is given by the value at index i of each provided vector.");
			}
			if (x.Length <= 1)
			{
				throw new ArgumentException($"A regression of the requested order requires at least {2} samples. Only {x.Length} samples have been provided.");
			}
			double num = 0.0;
			double num2 = 0.0;
			for (int i = 0; i < x.Length; i++)
			{
				num2 += x[i] * x[i];
				num += x[i] * y[i];
			}
			return num / num2;
		}

		public static double FitThroughOrigin(IEnumerable<Tuple<double, double>> samples)
		{
			double num = 0.0;
			double num2 = 0.0;
			foreach (Tuple<double, double> sample in samples)
			{
				num2 += sample.Item1 * sample.Item1;
				num += sample.Item1 * sample.Item2;
			}
			return num / num2;
		}
	}
}
