using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Interpolation
{
	public class LogLinear : IInterpolation
	{
		private readonly LinearSpline _spline;

		bool IInterpolation.SupportsDifferentiation => true;

		bool IInterpolation.SupportsIntegration => false;

		public LogLinear(double[] x, double[] logy)
		{
			_spline = LinearSpline.InterpolateSorted(x, logy);
		}

		public static LogLinear InterpolateSorted(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double[] logy = new double[y.Length];
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					logy[i] = Math.Log(y[i]);
				}
			});
			return new LogLinear(x, logy);
		}

		public static LogLinear InterpolateInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					y[i] = Math.Log(y[i]);
				}
			});
			return new LogLinear(x, y);
		}

		public static LogLinear Interpolate(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateInplace(x.ToArray(), y.ToArray());
		}

		public double Interpolate(double t)
		{
			return Math.Exp(_spline.Interpolate(t));
		}

		public double Differentiate(double t)
		{
			return Interpolate(t) * _spline.Differentiate(t);
		}

		public double Differentiate2(double t)
		{
			double num = _spline.Differentiate(t);
			double num2 = _spline.Differentiate2(t);
			return Differentiate(t) * num + Interpolate(t) * num2;
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
