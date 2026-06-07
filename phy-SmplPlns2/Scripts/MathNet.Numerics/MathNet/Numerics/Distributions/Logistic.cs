using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Logistic : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _mean;

		private readonly double _scale;

		public double Scale => _scale;

		public double Mean => _mean;

		public double StdDev => Math.Sqrt(Variance);

		public double Variance => Math.Pow(_scale, 2.0) * Math.Pow(Math.PI, 2.0) / 3.0;

		public double Precision => 1.0 / Variance;

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

		public double Entropy => Math.Log(_scale) + 2.0;

		public double Skewness => 0.0;

		public double Mode => _mean;

		public double Median => _mean;

		public double Minimum => double.NegativeInfinity;

		public double Maximum => double.PositiveInfinity;

		public Logistic()
			: this(0.0, 1.0)
		{
		}

		public Logistic(System.Random randomSource)
			: this(0.0, 1.0, randomSource)
		{
		}

		public Logistic(double mean, double scale)
		{
			if (!IsValidParameterSet(mean, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_mean = mean;
			_scale = scale;
		}

		public Logistic(double mean, double scale, System.Random randomSource)
		{
			if (!IsValidParameterSet(mean, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_mean = mean;
			_scale = scale;
		}

		public static Logistic WithMeanScale(double mean, double scale, System.Random randomSource = null)
		{
			return new Logistic(mean, scale, randomSource);
		}

		public static Logistic WithMeanStdDev(double mean, double stddev, System.Random randomSource = null)
		{
			double scale = Math.Sqrt(3.0) * stddev / Math.PI;
			return new Logistic(mean, scale, randomSource);
		}

		public static Logistic WithMeanVariance(double mean, double var, System.Random randomSource = null)
		{
			return WithMeanStdDev(mean, Math.Sqrt(var), randomSource);
		}

		public static Logistic WithMeanPrecision(double mean, double precision, System.Random randomSource = null)
		{
			return WithMeanVariance(mean, 1.0 / precision, randomSource);
		}

		public override string ToString()
		{
			return $"Logistic(μ = {_mean}, s = {_scale})";
		}

		public static bool IsValidParameterSet(double mean, double scale)
		{
			if (scale > 0.0)
			{
				return !double.IsNaN(mean);
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_mean, _scale, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_mean, _scale, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_mean, _scale, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_mean, _scale, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _mean, _scale);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _mean, _scale);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _mean, _scale);
		}

		private static double SampleUnchecked(System.Random rnd, double mean, double scale)
		{
			return InvCDF(mean, scale, rnd.NextDouble());
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double mean, double scale)
		{
			while (true)
			{
				yield return InvCDF(mean, scale, rnd.NextDouble());
			}
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double mean, double scale)
		{
			if (values.Length != 0)
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = SampleUnchecked(rnd, mean, scale);
				}
			}
		}

		public static double PDF(double mean, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - mean) / scale;
			return Math.Exp(0.0 - num) / (scale * Math.Pow(1.0 + Math.Exp(0.0 - num), 2.0));
		}

		public static double PDFLn(double mean, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - mean) / scale;
			return 0.0 - num - Math.Log(scale) - 2.0 * Math.Log(1.0 + Math.Exp(0.0 - num));
		}

		public static double CDF(double mean, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - mean) / scale;
			return 1.0 / (1.0 + Math.Exp(0.0 - num));
		}

		public static double InvCDF(double mean, double scale, double p)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return mean + scale * Math.Log(p / (1.0 - p));
		}

		public static double Sample(System.Random rnd, double mean, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, mean, scale);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double mean, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, mean, scale);
		}

		public static void Samples(System.Random rnd, double[] values, double mean, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, mean, scale);
		}

		public static double Sample(double mean, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, mean, scale);
		}

		public static IEnumerable<double> Samples(double mean, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, mean, scale);
		}

		public static void Samples(double[] values, double mean, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, mean, scale);
		}
	}
}
