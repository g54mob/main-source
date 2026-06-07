using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Exponential : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _rate;

		public double Rate => _rate;

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

		public double Mean => 1.0 / _rate;

		public double Variance => 1.0 / (_rate * _rate);

		public double StdDev => 1.0 / _rate;

		public double Entropy => 1.0 - Math.Log(_rate);

		public double Skewness => 2.0;

		public double Mode => 0.0;

		public double Median => Math.Log(2.0) / _rate;

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public Exponential(double rate)
		{
			if (!IsValidParameterSet(rate))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_rate = rate;
		}

		public Exponential(double rate, System.Random randomSource)
		{
			if (!IsValidParameterSet(rate))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_rate = rate;
		}

		public override string ToString()
		{
			return $"Exponential(λ = {_rate})";
		}

		public static bool IsValidParameterSet(double rate)
		{
			return rate >= 0.0;
		}

		public double Density(double x)
		{
			if (!(x < 0.0))
			{
				return _rate * Math.Exp((0.0 - _rate) * x);
			}
			return 0.0;
		}

		public double DensityLn(double x)
		{
			return Math.Log(_rate) - _rate * x;
		}

		public double CumulativeDistribution(double x)
		{
			if (!(x < 0.0))
			{
				return 1.0 - Math.Exp((0.0 - _rate) * x);
			}
			return 0.0;
		}

		public double InverseCumulativeDistribution(double p)
		{
			if (!(p >= 1.0))
			{
				return (0.0 - Math.Log(1.0 - p)) / _rate;
			}
			return double.PositiveInfinity;
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _rate);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _rate);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _rate);
		}

		private static double SampleUnchecked(System.Random rnd, double rate)
		{
			double num;
			for (num = rnd.NextDouble(); num == 0.0; num = rnd.NextDouble())
			{
			}
			return (0.0 - Math.Log(num)) / rate;
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double rate)
		{
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					double num;
					for (num = values[i]; num == 0.0; num = rnd.NextDouble())
					{
					}
					values[i] = (0.0 - Math.Log(num)) / rate;
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double rate)
		{
			return from r in rnd.NextDoubleSequence()
				where r != 0.0
				select (0.0 - Math.Log(r)) / rate;
		}

		public static double PDF(double rate, double x)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x < 0.0))
			{
				return rate * Math.Exp((0.0 - rate) * x);
			}
			return 0.0;
		}

		public static double PDFLn(double rate, double x)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Log(rate) - rate * x;
		}

		public static double CDF(double rate, double x)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x < 0.0))
			{
				return 1.0 - Math.Exp((0.0 - rate) * x);
			}
			return 0.0;
		}

		public static double InvCDF(double rate, double p)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(p >= 1.0))
			{
				return (0.0 - Math.Log(1.0 - p)) / rate;
			}
			return double.PositiveInfinity;
		}

		public static double Sample(System.Random rnd, double rate)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, rate);
		}

		public static void Samples(System.Random rnd, double[] values, double rate)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, rate);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double rate)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, rate);
		}

		public static double Sample(double rate)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, rate);
		}

		public static void Samples(double[] values, double rate)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, rate);
		}

		public static IEnumerable<double> Samples(double rate)
		{
			if (rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, rate);
		}
	}
}
