using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
	public class BulirschStoerRationalInterpolation : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _y;

		bool IInterpolation.SupportsDifferentiation => false;

		bool IInterpolation.SupportsIntegration => false;

		public BulirschStoerRationalInterpolation(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 1)
			{
				throw new ArgumentException("The given array is too small. It must be at least 1 long.", "x");
			}
			_x = x;
			_y = y;
		}

		public static BulirschStoerRationalInterpolation InterpolateSorted(double[] x, double[] y)
		{
			return new BulirschStoerRationalInterpolation(x, y);
		}

		public static BulirschStoerRationalInterpolation InterpolateInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateSorted(x, y);
		}

		public static BulirschStoerRationalInterpolation Interpolate(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateInplace(x.ToArray(), y.ToArray());
		}

		public double Interpolate(double t)
		{
			int num = _x.Length;
			double[] array = new double[num];
			double[] array2 = new double[num];
			int num2 = 0;
			double num3 = Math.Abs(t - _x[0]);
			for (int i = 0; i < num; i++)
			{
				double num4 = Math.Abs(t - _x[i]);
				if (num4.AlmostEqual(0.0))
				{
					return _y[i];
				}
				if (num4 < num3)
				{
					num2 = i;
					num3 = num4;
				}
				array[i] = _y[i];
				array2[i] = _y[i] + 1E-25;
			}
			double num5 = _y[num2];
			for (int j = 1; j < num; j++)
			{
				for (int k = 0; k < num - j; k++)
				{
					double num6 = _x[k + j] - t;
					double num7 = (_x[k] - t) * array2[k] / num6;
					double num8 = num7 - array[k + 1];
					if (num8.AlmostEqual(0.0))
					{
						return double.NaN;
					}
					num8 = (array[k + 1] - array2[k]) / num8;
					array2[k] = array[k + 1] * num8;
					array[k] = num7 * num8;
				}
				num5 += ((2 * num2 < num - j) ? array[num2] : array2[--num2]);
			}
			return num5;
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
