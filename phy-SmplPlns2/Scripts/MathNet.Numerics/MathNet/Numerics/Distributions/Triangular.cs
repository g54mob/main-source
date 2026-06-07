using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Triangular : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _lower;

		private readonly double _upper;

		private readonly double _mode;

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

		public double Mean => (_lower + _upper + _mode) / 3.0;

		public double Variance
		{
			get
			{
				double lower = _lower;
				double upper = _upper;
				double mode = _mode;
				return (lower * lower + upper * upper + mode * mode - lower * upper - lower * mode - upper * mode) / 18.0;
			}
		}

		public double StdDev => Math.Sqrt(Variance);

		public double Entropy => 0.5 + Math.Log((_upper - _lower) / 2.0);

		public double Skewness
		{
			get
			{
				double lower = _lower;
				double upper = _upper;
				double mode = _mode;
				double num = Math.Sqrt(2.0) * (lower + upper - 2.0 * mode) * (2.0 * lower - upper - mode) * (lower - 2.0 * upper + mode);
				double num2 = 5.0 * Math.Pow(lower * lower + upper * upper + mode * mode - lower * upper - lower * mode - upper * mode, 1.5);
				return num / num2;
			}
		}

		public double Mode => _mode;

		public double Median
		{
			get
			{
				double lower = _lower;
				double upper = _upper;
				double mode = _mode;
				if (!(mode >= (lower + upper) / 2.0))
				{
					return upper - Math.Sqrt((upper - lower) * (upper - mode) / 2.0);
				}
				return lower + Math.Sqrt((upper - lower) * (mode - lower) / 2.0);
			}
		}

		public double Minimum => _lower;

		public double Maximum => _upper;

		public Triangular(double lower, double upper, double mode)
		{
			if (!IsValidParameterSet(lower, upper, mode))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_lower = lower;
			_upper = upper;
			_mode = mode;
		}

		public Triangular(double lower, double upper, double mode, System.Random randomSource)
		{
			if (!IsValidParameterSet(lower, upper, mode))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_lower = lower;
			_upper = upper;
			_mode = mode;
		}

		public override string ToString()
		{
			return $"Triangular(Lower = {_lower}, Upper = {_upper}, Mode = {_mode})";
		}

		public static bool IsValidParameterSet(double lower, double upper, double mode)
		{
			if (upper >= mode && mode >= lower && !double.IsInfinity(upper) && !double.IsInfinity(lower))
			{
				return !double.IsInfinity(mode);
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_lower, _upper, _mode, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_lower, _upper, _mode, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_lower, _upper, _mode, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_lower, _upper, _mode, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _lower, _upper, _mode);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _lower, _upper, _mode);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _lower, _upper, _mode);
		}

		private static double SampleUnchecked(System.Random rnd, double lower, double upper, double mode)
		{
			double num = rnd.NextDouble();
			if (!(num < (mode - lower) / (upper - lower)))
			{
				return upper - Math.Sqrt((1.0 - num) * (upper - lower) * (upper - mode));
			}
			return lower + Math.Sqrt(num * (upper - lower) * (mode - lower));
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double lower, double upper, double mode)
		{
			double num = mode - lower;
			double num2 = upper - lower;
			double num3 = upper - mode;
			double u = num / num2;
			double v = num2 * num;
			double w = num2 * num3;
			return from x in rnd.NextDoubleSequence()
				select (!(x < u)) ? (upper - Math.Sqrt((1.0 - x) * w)) : (lower + Math.Sqrt(x * v));
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double lower, double upper, double mode)
		{
			double num = mode - lower;
			double num2 = upper - lower;
			double num3 = upper - mode;
			double u = num / num2;
			double v = num2 * num;
			double w = num2 * num3;
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = ((values[i] < u) ? (lower + Math.Sqrt(values[i] * v)) : (upper - Math.Sqrt((1.0 - values[i]) * w)));
				}
			});
		}

		public static double PDF(double lower, double upper, double mode, double x)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (lower <= x && x <= mode)
			{
				return 2.0 * (x - lower) / ((upper - lower) * (mode - lower));
			}
			if (mode < x && x <= upper)
			{
				return 2.0 * (upper - x) / ((upper - lower) * (upper - mode));
			}
			return 0.0;
		}

		public static double PDFLn(double lower, double upper, double mode, double x)
		{
			return Math.Log(PDF(lower, upper, mode, x));
		}

		public static double CDF(double lower, double upper, double mode, double x)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < lower)
			{
				return 0.0;
			}
			if (lower <= x && x <= mode)
			{
				return (x - lower) * (x - lower) / ((upper - lower) * (mode - lower));
			}
			if (mode < x && x <= upper)
			{
				return 1.0 - (upper - x) * (upper - x) / ((upper - lower) * (upper - mode));
			}
			return 1.0;
		}

		public static double InvCDF(double lower, double upper, double mode, double p)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (p <= 0.0)
			{
				return lower;
			}
			if (p < (mode - lower) / (upper - lower))
			{
				return lower + Math.Sqrt(p * (mode - lower) * (upper - lower));
			}
			if (p < 1.0)
			{
				return upper - Math.Sqrt((1.0 - p) * (upper - mode) * (upper - lower));
			}
			return upper;
		}

		public static double Sample(System.Random rnd, double lower, double upper, double mode)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, lower, upper, mode);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double lower, double upper, double mode)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, lower, upper, mode);
		}

		public static void Samples(System.Random rnd, double[] values, double lower, double upper, double mode)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, lower, upper, mode);
		}

		public static double Sample(double lower, double upper, double mode)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, lower, upper, mode);
		}

		public static IEnumerable<double> Samples(double lower, double upper, double mode)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, lower, upper, mode);
		}

		public static void Samples(double[] values, double lower, double upper, double mode)
		{
			if (!(upper >= mode) || !(mode >= lower))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, lower, upper, mode);
		}
	}
}
