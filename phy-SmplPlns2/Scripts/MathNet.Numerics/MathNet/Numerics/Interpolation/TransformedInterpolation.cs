using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Interpolation
{
	public class TransformedInterpolation : IInterpolation
	{
		private readonly IInterpolation _interpolation;

		private readonly Func<double, double> _transform;

		bool IInterpolation.SupportsDifferentiation => false;

		bool IInterpolation.SupportsIntegration => false;

		public TransformedInterpolation(IInterpolation interpolation, Func<double, double> transform)
		{
			_interpolation = interpolation;
			_transform = transform;
		}

		public static TransformedInterpolation InterpolateSorted(Func<double, double> transform, Func<double, double> transformInverse, double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double[] yhat = new double[y.Length];
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					yhat[i] = transformInverse(y[i]);
				}
			});
			return new TransformedInterpolation(LinearSpline.InterpolateSorted(x, yhat), transform);
		}

		public static TransformedInterpolation InterpolateInplace(Func<double, double> transform, Func<double, double> transformInverse, double[] x, double[] y)
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
					y[i] = transformInverse(y[i]);
				}
			});
			return new TransformedInterpolation(LinearSpline.InterpolateSorted(x, y), transform);
		}

		public static TransformedInterpolation Interpolate(Func<double, double> transform, Func<double, double> transformInverse, IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateInplace(transform, transformInverse, x.ToArray(), y.ToArray());
		}

		public double Interpolate(double t)
		{
			return _transform(_interpolation.Interpolate(t));
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
