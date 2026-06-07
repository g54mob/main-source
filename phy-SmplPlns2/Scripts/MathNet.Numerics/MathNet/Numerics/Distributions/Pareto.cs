using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Pareto : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _scale;

		private readonly double _shape;

		public double Scale => _scale;

		public double Shape => _shape;

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
				if (_shape <= 1.0)
				{
					throw new NotSupportedException();
				}
				return _shape * _scale / (_shape - 1.0);
			}
		}

		public double Variance
		{
			get
			{
				if (_shape <= 2.0)
				{
					return double.PositiveInfinity;
				}
				return _scale * _scale * _shape / ((_shape - 1.0) * (_shape - 1.0) * (_shape - 2.0));
			}
		}

		public double StdDev => _scale * Math.Sqrt(_shape) / (Math.Abs(_shape - 1.0) * Math.Sqrt(_shape - 2.0));

		public double Entropy => Math.Log(_shape / _scale) - 1.0 / _shape - 1.0;

		public double Skewness => 2.0 * (_shape + 1.0) / (_shape - 3.0) * Math.Sqrt((_shape - 2.0) / _shape);

		public double Mode => _scale;

		public double Median => _scale * Math.Pow(2.0, 1.0 / _shape);

		public double Minimum => _scale;

		public double Maximum => double.PositiveInfinity;

		public Pareto(double scale, double shape)
		{
			if (!IsValidParameterSet(scale, shape))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_scale = scale;
			_shape = shape;
		}

		public Pareto(double scale, double shape, System.Random randomSource)
		{
			if (!IsValidParameterSet(scale, shape))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_scale = scale;
			_shape = shape;
		}

		public override string ToString()
		{
			return $"Pareto(xm = {_scale}, α = {_shape})";
		}

		public static bool IsValidParameterSet(double scale, double shape)
		{
			if (scale > 0.0)
			{
				return shape > 0.0;
			}
			return false;
		}

		public double Density(double x)
		{
			return _shape * Math.Pow(_scale, _shape) / Math.Pow(x, _shape + 1.0);
		}

		public double DensityLn(double x)
		{
			return Math.Log(_shape) + _shape * Math.Log(_scale) - (_shape + 1.0) * Math.Log(x);
		}

		public double CumulativeDistribution(double x)
		{
			return 1.0 - Math.Pow(_scale / x, _shape);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return _scale * Math.Pow(1.0 - p, -1.0 / _shape);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _scale, _shape);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _scale, _shape);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _scale, _shape);
		}

		private static double SampleUnchecked(System.Random rnd, double scale, double shape)
		{
			return scale * Math.Pow(rnd.NextDouble(), -1.0 / shape);
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double scale, double shape)
		{
			double power = -1.0 / shape;
			return from x in rnd.NextDoubleSequence()
				select scale * Math.Pow(x, power);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double scale, double shape)
		{
			double power = -1.0 / shape;
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = scale * Math.Pow(values[i], power);
				}
			});
		}

		public static double PDF(double scale, double shape, double x)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return shape * Math.Pow(scale, shape) / Math.Pow(x, shape + 1.0);
		}

		public static double PDFLn(double scale, double shape, double x)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Log(shape) + shape * Math.Log(scale) - (shape + 1.0) * Math.Log(x);
		}

		public static double CDF(double scale, double shape, double x)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 1.0 - Math.Pow(scale / x, shape);
		}

		public static double InvCDF(double scale, double shape, double p)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return scale * Math.Pow(1.0 - p, -1.0 / shape);
		}

		public static double Sample(System.Random rnd, double scale, double shape)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return scale * Math.Pow(rnd.NextDouble(), -1.0 / shape);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double scale, double shape)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, scale, shape);
		}

		public static void Samples(System.Random rnd, double[] values, double scale, double shape)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, scale, shape);
		}

		public static double Sample(double scale, double shape)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, scale, shape);
		}

		public static IEnumerable<double> Samples(double scale, double shape)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, scale, shape);
		}

		public static void Samples(double[] values, double scale, double shape)
		{
			if (scale <= 0.0 || shape <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, scale, shape);
		}
	}
}
