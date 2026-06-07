using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics.Distributions
{
	public class Normal : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _mean;

		private readonly double _stdDev;

		public double Mean => _mean;

		public double StdDev => _stdDev;

		public double Variance => _stdDev * _stdDev;

		public double Precision => 1.0 / (_stdDev * _stdDev);

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

		public double Entropy => Math.Log(_stdDev) + 1.4189385332046727;

		public double Skewness => 0.0;

		public double Mode => _mean;

		public double Median => _mean;

		public double Minimum => double.NegativeInfinity;

		public double Maximum => double.PositiveInfinity;

		public Normal()
			: this(0.0, 1.0)
		{
		}

		public Normal(System.Random randomSource)
			: this(0.0, 1.0, randomSource)
		{
		}

		public Normal(double mean, double stddev)
		{
			if (!IsValidParameterSet(mean, stddev))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_mean = mean;
			_stdDev = stddev;
		}

		public Normal(double mean, double stddev, System.Random randomSource)
		{
			if (!IsValidParameterSet(mean, stddev))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_mean = mean;
			_stdDev = stddev;
		}

		public static Normal WithMeanStdDev(double mean, double stddev, System.Random randomSource = null)
		{
			return new Normal(mean, stddev, randomSource);
		}

		public static Normal WithMeanVariance(double mean, double var, System.Random randomSource = null)
		{
			return new Normal(mean, Math.Sqrt(var), randomSource);
		}

		public static Normal WithMeanPrecision(double mean, double precision, System.Random randomSource = null)
		{
			return new Normal(mean, 1.0 / Math.Sqrt(precision), randomSource);
		}

		public static Normal Estimate(IEnumerable<double> samples, System.Random randomSource = null)
		{
			(double, double) tuple = samples.MeanStandardDeviation();
			return new Normal(tuple.Item1, tuple.Item2, randomSource);
		}

		public override string ToString()
		{
			return $"Normal(μ = {_mean}, σ = {_stdDev})";
		}

		public static bool IsValidParameterSet(double mean, double stddev)
		{
			if (stddev >= 0.0)
			{
				return !double.IsNaN(mean);
			}
			return false;
		}

		public double Density(double x)
		{
			double num = (x - _mean) / _stdDev;
			return Math.Exp(-0.5 * num * num) / (2.5066282746310007 * _stdDev);
		}

		public double DensityLn(double x)
		{
			double num = (x - _mean) / _stdDev;
			return -0.5 * num * num - Math.Log(_stdDev) - 0.9189385332046728;
		}

		public double CumulativeDistribution(double x)
		{
			return 0.5 * SpecialFunctions.Erfc((_mean - x) / (_stdDev * 1.4142135623730951));
		}

		public double InverseCumulativeDistribution(double p)
		{
			return _mean - _stdDev * 1.4142135623730951 * SpecialFunctions.ErfcInv(2.0 * p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _mean, _stdDev);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _mean, _stdDev);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _mean, _stdDev);
		}

		internal static double SampleUnchecked(System.Random rnd, double mean, double stddev)
		{
			double x;
			double y;
			while (!PolarTransform(rnd.NextDouble(), rnd.NextDouble(), out x, out y))
			{
			}
			return mean + stddev * x;
		}

		internal static IEnumerable<double> SamplesUnchecked(System.Random rnd, double mean, double stddev)
		{
			while (true)
			{
				if (PolarTransform(rnd.NextDouble(), rnd.NextDouble(), out var x, out var y))
				{
					yield return mean + stddev * x;
					yield return mean + stddev * y;
				}
			}
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double mean, double stddev)
		{
			if (values.Length == 0)
			{
				return;
			}
			int num = (int)Math.Ceiling((double)(values.Length * 4) * (1.0 / Math.PI));
			if (num.IsOdd())
			{
				num++;
			}
			double[] array = rnd.NextDoubles(num);
			int num2 = 0;
			double x;
			double y;
			for (int i = 0; i < array.Length; i += 2)
			{
				if (num2 >= values.Length)
				{
					break;
				}
				if (PolarTransform(array[i], array[i + 1], out x, out y))
				{
					values[num2++] = mean + stddev * x;
					if (num2 == values.Length)
					{
						return;
					}
					values[num2++] = mean + stddev * y;
					if (num2 == values.Length)
					{
						return;
					}
				}
			}
			while (num2 < values.Length)
			{
				if (PolarTransform(rnd.NextDouble(), rnd.NextDouble(), out x, out y))
				{
					values[num2++] = mean + stddev * x;
					if (num2 == values.Length)
					{
						break;
					}
					values[num2++] = mean + stddev * y;
					if (num2 == values.Length)
					{
						break;
					}
				}
			}
		}

		private static bool PolarTransform(double a, double b, out double x, out double y)
		{
			double num = 2.0 * a - 1.0;
			double num2 = 2.0 * b - 1.0;
			double num3 = num * num + num2 * num2;
			if (num3 >= 1.0 || num3 == 0.0)
			{
				x = 0.0;
				y = 0.0;
				return false;
			}
			double num4 = Math.Sqrt(-2.0 * Math.Log(num3) / num3);
			x = num * num4;
			y = num2 * num4;
			return true;
		}

		public static double PDF(double mean, double stddev, double x)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - mean) / stddev;
			return Math.Exp(-0.5 * num * num) / (2.5066282746310007 * stddev);
		}

		public static double PDFLn(double mean, double stddev, double x)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - mean) / stddev;
			return -0.5 * num * num - Math.Log(stddev) - 0.9189385332046728;
		}

		public static double CDF(double mean, double stddev, double x)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 0.5 * SpecialFunctions.Erfc((mean - x) / (stddev * 1.4142135623730951));
		}

		public static double InvCDF(double mean, double stddev, double p)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return mean - stddev * 1.4142135623730951 * SpecialFunctions.ErfcInv(2.0 * p);
		}

		public static double Sample(System.Random rnd, double mean, double stddev)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, mean, stddev);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double mean, double stddev)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, mean, stddev);
		}

		public static void Samples(System.Random rnd, double[] values, double mean, double stddev)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, mean, stddev);
		}

		public static double Sample(double mean, double stddev)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, mean, stddev);
		}

		public static IEnumerable<double> Samples(double mean, double stddev)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, mean, stddev);
		}

		public static void Samples(double[] values, double mean, double stddev)
		{
			if (stddev < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, mean, stddev);
		}
	}
}
