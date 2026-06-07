using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
	public class NevillePolynomialInterpolation : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _y;

		bool IInterpolation.SupportsDifferentiation => true;

		bool IInterpolation.SupportsIntegration => false;

		public NevillePolynomialInterpolation(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 1)
			{
				throw new ArgumentException("The given array is too small. It must be at least 1 long.", "x");
			}
			for (int i = 1; i < x.Length; i++)
			{
				if (x[i] == x[i - 1])
				{
					throw new ArgumentException("All sample points should be unique.", "x");
				}
			}
			_x = x;
			_y = y;
		}

		public static NevillePolynomialInterpolation InterpolateSorted(double[] x, double[] y)
		{
			return new NevillePolynomialInterpolation(x, y);
		}

		public static NevillePolynomialInterpolation InterpolateInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateSorted(x, y);
		}

		public static NevillePolynomialInterpolation Interpolate(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateInplace(x.ToArray(), y.ToArray());
		}

		public double Interpolate(double t)
		{
			double[] array = new double[_y.Length];
			_y.CopyTo(array, 0);
			for (int i = 1; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - i; j++)
				{
					double num = t - _x[j + i];
					double num2 = _x[j] - t;
					double num3 = _x[j] - _x[j + i];
					array[j] = (num * array[j] + num2 * array[j + 1]) / num3;
				}
			}
			return array[0];
		}

		public double Differentiate(double t)
		{
			double[] array = new double[_y.Length];
			double[] array2 = new double[_y.Length];
			_y.CopyTo(array, 0);
			for (int i = 1; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - i; j++)
				{
					double num = t - _x[j + i];
					double num2 = _x[j] - t;
					double num3 = _x[j] - _x[j + i];
					array2[j] = (num * array2[j] + array[j] + num2 * array2[j + 1] - array[j + 1]) / num3;
					array[j] = (num * array[j] + num2 * array[j + 1]) / num3;
				}
			}
			return array2[0];
		}

		public double Differentiate2(double t)
		{
			double[] array = new double[_y.Length];
			double[] array2 = new double[_y.Length];
			double[] array3 = new double[_y.Length];
			_y.CopyTo(array, 0);
			for (int i = 1; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - i; j++)
				{
					double num = t - _x[j + i];
					double num2 = _x[j] - t;
					double num3 = _x[j] - _x[j + i];
					array3[j] = (num * array3[j] + num2 * array3[j + 1] + 2.0 * array2[j] - 2.0 * array2[j + 1]) / num3;
					array2[j] = (num * array2[j] + array[j] + num2 * array2[j + 1] - array[j + 1]) / num3;
					array[j] = (num * array[j] + num2 * array[j + 1]) / num3;
				}
			}
			return array3[0];
		}

		double IInterpolation.Integrate(double t)
		{
			throw new NotSupportedException();
		}

		double IInterpolation.Integrate(double a, double b)
		{
			throw new NotSupportedException();
		}
	}
}
