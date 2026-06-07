using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
	public class LinearSpline : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _c0;

		private readonly double[] _c1;

		private readonly Lazy<double[]> _indefiniteIntegral;

		bool IInterpolation.SupportsDifferentiation => true;

		bool IInterpolation.SupportsIntegration => true;

		public LinearSpline(double[] x, double[] c0, double[] c1)
		{
			if ((x.Length != c0.Length + 1 && x.Length != c0.Length) || x.Length != c1.Length + 1)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 2)
			{
				throw new ArgumentException("The given array is too small. It must be at least 2 long.", "x");
			}
			_x = x;
			_c0 = c0;
			_c1 = c1;
			_indefiniteIntegral = new Lazy<double[]>(ComputeIndefiniteIntegral);
		}

		public static LinearSpline InterpolateSorted(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 2)
			{
				throw new ArgumentException("The given array is too small. It must be at least 2 long.", "x");
			}
			double[] array = new double[x.Length - 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
			}
			return new LinearSpline(x, y, array);
		}

		public static LinearSpline InterpolateInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateSorted(x, y);
		}

		public static LinearSpline Interpolate(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateInplace(x.ToArray(), y.ToArray());
		}

		public double Interpolate(double t)
		{
			int num = LeftSegmentIndex(t);
			return _c0[num] + (t - _x[num]) * _c1[num];
		}

		public double Differentiate(double t)
		{
			int num = LeftSegmentIndex(t);
			return _c1[num];
		}

		public double Differentiate2(double t)
		{
			return 0.0;
		}

		public double Integrate(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return _indefiniteIntegral.Value[num] + num2 * (_c0[num] + num2 * _c1[num] / 2.0);
		}

		public double Integrate(double a, double b)
		{
			return Integrate(b) - Integrate(a);
		}

		private double[] ComputeIndefiniteIntegral()
		{
			double[] array = new double[_c1.Length];
			for (int i = 0; i < array.Length - 1; i++)
			{
				double num = _x[i + 1] - _x[i];
				array[i + 1] = array[i] + num * (_c0[i] + num * _c1[i] / 2.0);
			}
			return array;
		}

		private int LeftSegmentIndex(double t)
		{
			int num = Array.BinarySearch(_x, t);
			if (num < 0)
			{
				num = ~num - 1;
			}
			return Math.Min(Math.Max(num, 0), _x.Length - 2);
		}
	}
}
