using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class ContinuousUniform : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _lower;

		private readonly double _upper;

		public double LowerBound => _lower;

		public double UpperBound => _upper;

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

		public double Mean => (_lower + _upper) / 2.0;

		public double Variance => (_upper - _lower) * (_upper - _lower) / 12.0;

		public double StdDev => (_upper - _lower) / Math.Sqrt(12.0);

		public double Entropy => Math.Log(_upper - _lower);

		public double Skewness => 0.0;

		public double Mode => (_lower + _upper) / 2.0;

		public double Median => (_lower + _upper) / 2.0;

		public double Minimum => _lower;

		public double Maximum => _upper;

		public ContinuousUniform()
			: this(0.0, 1.0)
		{
		}

		public ContinuousUniform(double lower, double upper)
		{
			if (!IsValidParameterSet(lower, upper))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_lower = lower;
			_upper = upper;
		}

		public ContinuousUniform(double lower, double upper, System.Random randomSource)
		{
			if (!IsValidParameterSet(lower, upper))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_lower = lower;
			_upper = upper;
		}

		public override string ToString()
		{
			return $"ContinuousUniform(Lower = {_lower}, Upper = {_upper})";
		}

		public static bool IsValidParameterSet(double lower, double upper)
		{
			return lower <= upper;
		}

		public double Density(double x)
		{
			if (!(x < _lower) && !(x > _upper))
			{
				return 1.0 / (_upper - _lower);
			}
			return 0.0;
		}

		public double DensityLn(double x)
		{
			if (!(x < _lower) && !(x > _upper))
			{
				return 0.0 - Math.Log(_upper - _lower);
			}
			return double.NegativeInfinity;
		}

		public double CumulativeDistribution(double x)
		{
			if (!(x <= _lower))
			{
				if (!(x >= _upper))
				{
					return (x - _lower) / (_upper - _lower);
				}
				return 1.0;
			}
			return 0.0;
		}

		public double InverseCumulativeDistribution(double p)
		{
			if (!(p <= 0.0))
			{
				if (!(p >= 1.0))
				{
					return _lower * (1.0 - p) + _upper * p;
				}
				return _upper;
			}
			return _lower;
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _lower, _upper);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _lower, _upper);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _lower, _upper);
		}

		private static double SampleUnchecked(System.Random rnd, double lower, double upper)
		{
			return lower + rnd.NextDouble() * (upper - lower);
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double lower, double upper)
		{
			double difference = upper - lower;
			while (true)
			{
				yield return lower + rnd.NextDouble() * difference;
			}
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double lower, double upper)
		{
			rnd.NextDoubles(values);
			double difference = upper - lower;
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = lower + values[i] * difference;
				}
			});
		}

		public static double PDF(double lower, double upper, double x)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x < lower) && !(x > upper))
			{
				return 1.0 / (upper - lower);
			}
			return 0.0;
		}

		public static double PDFLn(double lower, double upper, double x)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x < lower) && !(x > upper))
			{
				return 0.0 - Math.Log(upper - lower);
			}
			return double.NegativeInfinity;
		}

		public static double CDF(double lower, double upper, double x)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x <= lower))
			{
				if (!(x >= upper))
				{
					return (x - lower) / (upper - lower);
				}
				return 1.0;
			}
			return 0.0;
		}

		public static double InvCDF(double lower, double upper, double p)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(p <= 0.0))
			{
				if (!(p >= 1.0))
				{
					return lower * (1.0 - p) + upper * p;
				}
				return upper;
			}
			return lower;
		}

		public static double Sample(System.Random rnd, double lower, double upper)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, lower, upper);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double lower, double upper)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, lower, upper);
		}

		public static void Samples(System.Random rnd, double[] values, double lower, double upper)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, lower, upper);
		}

		public static double Sample(double lower, double upper)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, lower, upper);
		}

		public static IEnumerable<double> Samples(double lower, double upper)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, lower, upper);
		}

		public static void Samples(double[] values, double lower, double upper)
		{
			if (upper < lower)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, lower, upper);
		}
	}
}
