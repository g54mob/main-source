using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class BetaScaled : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _shapeA;

		private readonly double _shapeB;

		private readonly double _location;

		private readonly double _scale;

		public double A => _shapeA;

		public double B => _shapeB;

		public double Location => _location;

		public double Scale => _scale;

		public System.Random RandomSource
		{
			get
			{
				return _random;
			}
			set
			{
				_random = value ?? SystemRandomSource.Default;
			}
		}

		public double Mean
		{
			get
			{
				if (double.IsPositiveInfinity(_shapeA) && double.IsPositiveInfinity(_shapeB))
				{
					return _location + 0.5 * _scale;
				}
				if (double.IsPositiveInfinity(_shapeA))
				{
					return _location + _scale;
				}
				if (double.IsPositiveInfinity(_shapeB))
				{
					return _location;
				}
				return (_shapeB * _location + _shapeA * (_location + _scale)) / (_shapeA + _shapeB);
			}
		}

		public double Variance
		{
			get
			{
				double num = _shapeA + _shapeB;
				return _shapeA * _shapeB * _scale * _scale / (num * num * (1.0 + num));
			}
		}

		public double StdDev => Math.Sqrt(Variance);

		public double Entropy
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Skewness
		{
			get
			{
				if (double.IsPositiveInfinity(_shapeA) && double.IsPositiveInfinity(_shapeB))
				{
					return 0.0;
				}
				if (double.IsPositiveInfinity(_shapeA))
				{
					return -2.0 * _scale / Math.Sqrt(_shapeB * _scale * _scale);
				}
				if (double.IsPositiveInfinity(_shapeB))
				{
					return 2.0 * _scale / Math.Sqrt(_shapeA * _scale * _scale);
				}
				double num = _shapeA + _shapeB;
				double d = _shapeA * _shapeB * _scale * _scale / (num * num * (1.0 + num));
				return 2.0 * (_shapeB - _shapeA) * _scale / (num * (2.0 + num) * Math.Sqrt(d));
			}
		}

		public double Mode
		{
			get
			{
				if (double.IsPositiveInfinity(_shapeA) && double.IsPositiveInfinity(_shapeB))
				{
					return _location + 0.5 * _scale;
				}
				if (double.IsPositiveInfinity(_shapeA))
				{
					return _location + _scale;
				}
				if (double.IsPositiveInfinity(_shapeB))
				{
					return _location;
				}
				if (_shapeA == 1.0 && _shapeB == 1.0)
				{
					return _location + 0.5 * _scale;
				}
				return (_shapeA - 1.0) / (_shapeA + _shapeB - 2.0) * _scale + _location;
			}
		}

		public double Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Minimum => _location;

		public double Maximum => _location + _scale;

		public BetaScaled(double a, double b, double location, double scale)
		{
			if (!IsValidParameterSet(a, b, location, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_shapeA = a;
			_shapeB = b;
			_location = location;
			_scale = scale;
		}

		public BetaScaled(double a, double b, double location, double scale, System.Random randomSource)
		{
			if (!IsValidParameterSet(a, b, location, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_shapeA = a;
			_shapeB = b;
			_location = location;
			_scale = scale;
		}

		public static BetaScaled PERT(double min, double max, double likely, System.Random randomSource = null)
		{
			if (min > max || likely > max || likely < min)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (min + max + 4.0 * likely) / 6.0;
			double num2 = ((num != likely) ? ((num - min) * (2.0 * likely - min - max) / ((likely - num) * (max - min))) : 3.0);
			double b = num2 * (max - num) / (num - min);
			return new BetaScaled(num2, b, min, max - min, randomSource);
		}

		public override string ToString()
		{
			return $"BetaScaled(α = {_shapeA}, β = {_shapeB}, μ = {_location}, σ = {_scale})";
		}

		public static bool IsValidParameterSet(double a, double b, double location, double scale)
		{
			if (a > 0.0 && b > 0.0 && scale > 0.0)
			{
				return !double.IsNaN(location);
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_shapeA, _shapeB, _location, _scale, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_shapeA, _shapeB, _location, _scale, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_shapeA, _shapeB, _location, _scale, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_shapeA, _shapeB, _location, _scale, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _shapeA, _shapeB, _location, _scale);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _shapeA, _shapeB, _location, _scale);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _shapeA, _shapeB, _location, _scale);
		}

		private static double SampleUnchecked(System.Random rnd, double a, double b, double location, double scale)
		{
			return Beta.SampleUnchecked(rnd, a, b) * scale + location;
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double a, double b, double location, double scale)
		{
			Beta.SamplesUnchecked(rnd, values, a, b);
			CommonParallel.For(0, values.Length, 4096, delegate(int aa, int bb)
			{
				for (int i = aa; i < bb; i++)
				{
					values[i] = values[i] * scale + location;
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double a, double b, double location, double scale)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, a, b, location, scale);
			}
		}

		public static double PDF(double a, double b, double location, double scale, double x)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Beta.PDF(a, b, (x - location) / scale) / Math.Abs(scale);
		}

		public static double PDFLn(double a, double b, double location, double scale, double x)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Beta.PDFLn(a, b, (x - location) / scale) - Math.Log(Math.Abs(scale));
		}

		public static double CDF(double a, double b, double location, double scale, double x)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Beta.CDF(a, b, (x - location) / scale);
		}

		public static double InvCDF(double a, double b, double location, double scale, double p)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Beta.InvCDF(a, b, p) * scale + location;
		}

		public static double Sample(System.Random rnd, double a, double b, double location, double scale)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, a, b, location, scale);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double a, double b, double location, double scale)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, a, b, location, scale);
		}

		public static void Samples(System.Random rnd, double[] values, double a, double b, double location, double scale)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, a, b, location, scale);
		}

		public static double Sample(double a, double b, double location, double scale)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, a, b, location, scale);
		}

		public static IEnumerable<double> Samples(double a, double b, double location, double scale)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, a, b, location, scale);
		}

		public static void Samples(double[] values, double a, double b, double location, double scale)
		{
			if (!(a > 0.0) || !(b > 0.0) || !(scale > 0.0) || double.IsNaN(location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, a, b, location, scale);
		}
	}
}
