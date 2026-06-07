using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
	public class Barycentric : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _y;

		private readonly double[] _w;

		bool IInterpolation.SupportsDifferentiation => false;

		bool IInterpolation.SupportsIntegration => false;

		public Barycentric(double[] x, double[] y, double[] w)
		{
			if (x.Length != y.Length || x.Length != w.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 1)
			{
				throw new ArgumentException("The given array is too small. It must be at least 1 long.", "x");
			}
			_x = x;
			_y = y;
			_w = w;
		}

		public static Barycentric InterpolatePolynomialEquidistantSorted(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 1)
			{
				throw new ArgumentException("The given array is too small. It must be at least 1 long.", "x");
			}
			double[] array = new double[x.Length];
			array[0] = 1.0;
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = (0.0 - array[i - 1] * (double)(array.Length - i)) / (double)i;
			}
			return new Barycentric(x, y, array);
		}

		public static Barycentric InterpolatePolynomialEquidistantInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolatePolynomialEquidistantSorted(x, y);
		}

		public static Barycentric InterpolatePolynomialEquidistant(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolatePolynomialEquidistantInplace(x.ToArray(), y.ToArray());
		}

		public static Barycentric InterpolatePolynomialEquidistant(double leftBound, double rightBound, IEnumerable<double> y)
		{
			double[] array = (y as double[]) ?? y.ToArray();
			return InterpolatePolynomialEquidistantSorted(Generate.LinearSpaced(array.Length, leftBound, rightBound), array);
		}

		public static Barycentric InterpolateRationalFloaterHormannSorted(double[] x, double[] y, int order)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 1)
			{
				throw new ArgumentException("The given array is too small. It must be at least 1 long.", "x");
			}
			if (0 > order || x.Length <= order)
			{
				throw new ArgumentOutOfRangeException("order");
			}
			double[] array = new double[x.Length];
			double num = (((order & 1) == 1) ? (-1.0) : 1.0);
			for (int i = 0; i < x.Length; i++)
			{
				double num2 = 0.0;
				for (int j = Math.Max(i - order, 0); j <= Math.Min(i, array.Length - 1 - order); j++)
				{
					double num3 = 1.0;
					for (int k = j; k <= j + order; k++)
					{
						if (k != i)
						{
							num3 /= Math.Abs(x[i] - x[k]);
						}
					}
					num2 += num3;
				}
				array[i] = num * num2;
				num = 0.0 - num;
			}
			return new Barycentric(x, y, array);
		}

		public static Barycentric InterpolateRationalFloaterHormannInplace(double[] x, double[] y, int order)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateRationalFloaterHormannSorted(x, y, order);
		}

		public static Barycentric InterpolateRationalFloaterHormann(IEnumerable<double> x, IEnumerable<double> y, int order)
		{
			return InterpolateRationalFloaterHormannInplace(x.ToArray(), y.ToArray(), order);
		}

		public static Barycentric InterpolateRationalFloaterHormannSorted(double[] x, double[] y)
		{
			return InterpolateRationalFloaterHormannSorted(x, y, Math.Min(3, x.Length - 1));
		}

		public static Barycentric InterpolateRationalFloaterHormannInplace(double[] x, double[] y)
		{
			return InterpolateRationalFloaterHormannInplace(x, y, Math.Min(3, x.Length - 1));
		}

		public static Barycentric InterpolateRationalFloaterHormann(IEnumerable<double> x, IEnumerable<double> y)
		{
			double[] array = x.ToArray();
			int order = Math.Min(3, array.Length - 1);
			return InterpolateRationalFloaterHormannInplace(array, y.ToArray(), order);
		}

		public double Interpolate(double t)
		{
			if (_x.Length == 1)
			{
				return _y[0];
			}
			int num = 0;
			double num2 = t - _x[0];
			for (int i = 1; i < _x.Length; i++)
			{
				if (Math.Abs(t - _x[i]) < Math.Abs(num2))
				{
					num2 = t - _x[i];
					num = i;
				}
			}
			if (num2 == 0.0)
			{
				return _y[num];
			}
			if (Math.Abs(num2) > 1E-150)
			{
				num = -1;
				num2 = 1.0;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			for (int j = 0; j < _x.Length; j++)
			{
				if (j != num)
				{
					double num5 = num2 * _w[j] / (t - _x[j]);
					num3 += num5 * _y[j];
					num4 += num5;
				}
				else
				{
					double num6 = _w[j];
					num3 += num6 * _y[j];
					num4 += num6;
				}
			}
			return num3 / num4;
		}

		double IInterpolation.Differentiate(double t)
		{
			throw new NotSupportedException();
		}

		double IInterpolation.Differentiate2(double t)
		{
			throw new NotSupportedException();
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
