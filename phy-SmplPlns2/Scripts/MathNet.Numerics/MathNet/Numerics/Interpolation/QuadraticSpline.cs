using System;

namespace MathNet.Numerics.Interpolation
{
	public class QuadraticSpline : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _c0;

		private readonly double[] _c1;

		private readonly double[] _c2;

		private readonly Lazy<double[]> _indefiniteIntegral;

		bool IInterpolation.SupportsDifferentiation => true;

		bool IInterpolation.SupportsIntegration => true;

		public QuadraticSpline(double[] x, double[] c0, double[] c1, double[] c2)
		{
			if (x.Length != c0.Length + 1 || x.Length != c1.Length + 1 || x.Length != c2.Length + 1)
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
			_c2 = c2;
			_indefiniteIntegral = new Lazy<double[]>(ComputeIndefiniteIntegral);
		}

		public double Interpolate(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return _c0[num] + num2 * (_c1[num] + num2 * _c2[num]);
		}

		public double Differentiate(double t)
		{
			int num = LeftSegmentIndex(t);
			return _c1[num] + (t - _x[num]) * 2.0 * _c2[num];
		}

		public double Differentiate2(double t)
		{
			int num = LeftSegmentIndex(t);
			return 2.0 * _c2[num];
		}

		public double Integrate(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return _indefiniteIntegral.Value[num] + num2 * (_c0[num] + num2 * (_c1[num] / 2.0 + num2 * _c2[num] / 3.0));
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
				array[i + 1] = array[i] + num * (_c0[i] + num * (_c1[i] / 2.0 + num * _c2[i] / 3.0));
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
