using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
	public class StepInterpolation : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _y;

		private readonly Lazy<double[]> _indefiniteIntegral;

		bool IInterpolation.SupportsDifferentiation => true;

		bool IInterpolation.SupportsIntegration => true;

		public StepInterpolation(double[] x, double[] sy)
		{
			if (x.Length != sy.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 1)
			{
				throw new ArgumentException("The given array is too small. It must be at least 1 long.", "x");
			}
			_x = x;
			_y = sy;
			_indefiniteIntegral = new Lazy<double[]>(ComputeIndefiniteIntegral);
		}

		public static StepInterpolation InterpolateSorted(double[] x, double[] y)
		{
			return new StepInterpolation(x, y);
		}

		public static StepInterpolation InterpolateInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateSorted(x, y);
		}

		public static StepInterpolation Interpolate(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateInplace(x.ToArray(), y.ToArray());
		}

		public double Interpolate(double t)
		{
			if (t < _x[0])
			{
				return 0.0;
			}
			int num = LeftBracketIndex(t);
			return _y[num];
		}

		public double Differentiate(double t)
		{
			if (Array.BinarySearch(_x, t) >= 0)
			{
				return double.NaN;
			}
			return 0.0;
		}

		public double Differentiate2(double t)
		{
			return Differentiate(t);
		}

		public double Integrate(double t)
		{
			if (t <= _x[0])
			{
				return 0.0;
			}
			int num = LeftBracketIndex(t);
			double num2 = t - _x[num];
			return _indefiniteIntegral.Value[num] + num2 * _y[num];
		}

		public double Integrate(double a, double b)
		{
			return Integrate(b) - Integrate(a);
		}

		private double[] ComputeIndefiniteIntegral()
		{
			double[] array = new double[_x.Length];
			for (int i = 0; i < array.Length - 1; i++)
			{
				array[i + 1] = array[i] + (_x[i + 1] - _x[i]) * _y[i];
			}
			return array;
		}

		private int LeftBracketIndex(double t)
		{
			int num = Array.BinarySearch(_x, t);
			if (num < 0)
			{
				return ~num - 1;
			}
			return num;
		}
	}
}
