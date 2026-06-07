using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class LogNormal : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _mu;

		private readonly double _sigma;

		public double Mu => _mu;

		public double Sigma => _sigma;

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

		public double Mean => Math.Exp(_mu + _sigma * _sigma / 2.0);

		public double Variance
		{
			get
			{
				double num = _sigma * _sigma;
				return (Math.Exp(num) - 1.0) * Math.Exp(_mu + _mu + num);
			}
		}

		public double StdDev
		{
			get
			{
				double num = _sigma * _sigma;
				return Math.Sqrt((Math.Exp(num) - 1.0) * Math.Exp(_mu + _mu + num));
			}
		}

		public double Entropy => 0.5 + Math.Log(_sigma) + _mu + 0.9189385332046728;

		public double Skewness
		{
			get
			{
				double num = Math.Exp(_sigma * _sigma);
				return (num + 2.0) * Math.Sqrt(num - 1.0);
			}
		}

		public double Mode => Math.Exp(_mu - _sigma * _sigma);

		public double Median => Math.Exp(_mu);

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public LogNormal(double mu, double sigma)
		{
			if (!IsValidParameterSet(mu, sigma))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_mu = mu;
			_sigma = sigma;
		}

		public LogNormal(double mu, double sigma, System.Random randomSource)
		{
			if (!IsValidParameterSet(mu, sigma))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_mu = mu;
			_sigma = sigma;
		}

		public static LogNormal WithMuSigma(double mu, double sigma, System.Random randomSource = null)
		{
			return new LogNormal(mu, sigma, randomSource);
		}

		public static LogNormal WithMeanVariance(double mean, double var, System.Random randomSource = null)
		{
			double num = Math.Log(var / (mean * mean) + 1.0);
			return new LogNormal(Math.Log(mean) - num / 2.0, Math.Sqrt(num), randomSource);
		}

		public static LogNormal Estimate(IEnumerable<double> samples, System.Random randomSource = null)
		{
			(double, double) tuple = samples.Select((double s) => Math.Log(s)).MeanStandardDeviation();
			return new LogNormal(tuple.Item1, tuple.Item2, randomSource);
		}

		public override string ToString()
		{
			return $"LogNormal(μ = {_mu}, σ = {_sigma})";
		}

		public static bool IsValidParameterSet(double mu, double sigma)
		{
			if (sigma >= 0.0)
			{
				return !double.IsNaN(mu);
			}
			return false;
		}

		public double Density(double x)
		{
			if (x < 0.0)
			{
				return 0.0;
			}
			double num = (Math.Log(x) - _mu) / _sigma;
			return Math.Exp(-0.5 * num * num) / (x * _sigma * 2.5066282746310007);
		}

		public double DensityLn(double x)
		{
			if (x < 0.0)
			{
				return double.NegativeInfinity;
			}
			double num = (Math.Log(x) - _mu) / _sigma;
			return -0.5 * num * num - Math.Log(x * _sigma) - 0.9189385332046728;
		}

		public double CumulativeDistribution(double x)
		{
			if (!(x < 0.0))
			{
				return 0.5 * SpecialFunctions.Erfc((_mu - Math.Log(x)) / (_sigma * 1.4142135623730951));
			}
			return 0.0;
		}

		public double InverseCumulativeDistribution(double p)
		{
			if (!(p <= 0.0))
			{
				if (!(p >= 1.0))
				{
					return Math.Exp(_mu - _sigma * 1.4142135623730951 * SpecialFunctions.ErfcInv(2.0 * p));
				}
				return double.PositiveInfinity;
			}
			return 0.0;
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _mu, _sigma);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _mu, _sigma);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _mu, _sigma);
		}

		private static double SampleUnchecked(System.Random rnd, double mu, double sigma)
		{
			return Math.Exp(Normal.SampleUnchecked(rnd, mu, sigma));
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double mu, double sigma)
		{
			return Normal.SamplesUnchecked(rnd, mu, sigma).Select(Math.Exp);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double mu, double sigma)
		{
			Normal.SamplesUnchecked(rnd, values, mu, sigma);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = Math.Exp(values[i]);
				}
			});
		}

		public static double PDF(double mu, double sigma, double x)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0)
			{
				return 0.0;
			}
			double num = (Math.Log(x) - mu) / sigma;
			return Math.Exp(-0.5 * num * num) / (x * sigma * 2.5066282746310007);
		}

		public static double PDFLn(double mu, double sigma, double x)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0)
			{
				return double.NegativeInfinity;
			}
			double num = (Math.Log(x) - mu) / sigma;
			return -0.5 * num * num - Math.Log(x * sigma) - 0.9189385332046728;
		}

		public static double CDF(double mu, double sigma, double x)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x < 0.0))
			{
				return 0.5 * (1.0 + SpecialFunctions.Erf((Math.Log(x) - mu) / (sigma * 1.4142135623730951)));
			}
			return 0.0;
		}

		public static double InvCDF(double mu, double sigma, double p)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(p <= 0.0))
			{
				if (!(p >= 1.0))
				{
					return Math.Exp(mu - sigma * 1.4142135623730951 * SpecialFunctions.ErfcInv(2.0 * p));
				}
				return double.PositiveInfinity;
			}
			return 0.0;
		}

		public static double Sample(System.Random rnd, double mu, double sigma)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, mu, sigma);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double mu, double sigma)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, mu, sigma);
		}

		public static void Samples(System.Random rnd, double[] values, double mu, double sigma)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, mu, sigma);
		}

		public static double Sample(double mu, double sigma)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, mu, sigma);
		}

		public static IEnumerable<double> Samples(double mu, double sigma)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, mu, sigma);
		}

		public static void Samples(double[] values, double mu, double sigma)
		{
			if (sigma < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, mu, sigma);
		}
	}
}
