using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Rayleigh : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _scale;

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

		public double Mean => _scale * Math.Sqrt(Math.PI / 2.0);

		public double Variance => 0.42920367320510344 * _scale * _scale;

		public double StdDev => Math.Sqrt(0.42920367320510344) * _scale;

		public double Entropy => 1.0 + Math.Log(_scale / 1.4142135623730951) + 0.28860783245076643;

		public double Skewness => 2.0 * Math.Sqrt(Math.PI) * 0.14159265358979312 / Math.Pow(0.8584073464102069, 1.5);

		public double Mode => _scale;

		public double Median => _scale * Math.Sqrt(Math.Log(4.0));

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public Rayleigh(double scale)
		{
			if (!IsValidParameterSet(scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_scale = scale;
		}

		public Rayleigh(double scale, System.Random randomSource)
		{
			if (!IsValidParameterSet(scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_scale = scale;
		}

		public override string ToString()
		{
			return $"Rayleigh(σ = {_scale})";
		}

		public static bool IsValidParameterSet(double scale)
		{
			return scale > 0.0;
		}

		public double Density(double x)
		{
			return x / (_scale * _scale) * Math.Exp((0.0 - x) * x / (2.0 * _scale * _scale));
		}

		public double DensityLn(double x)
		{
			return Math.Log(x / (_scale * _scale)) - x * x / (2.0 * _scale * _scale);
		}

		public double CumulativeDistribution(double x)
		{
			return 1.0 - Math.Exp((0.0 - x) * x / (2.0 * _scale * _scale));
		}

		public double InverseCumulativeDistribution(double p)
		{
			return _scale * Math.Sqrt(-2.0 * Math.Log(1.0 - p));
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _scale);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _scale);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _scale);
		}

		private static double SampleUnchecked(System.Random rnd, double scale)
		{
			return scale * Math.Sqrt(-2.0 * Math.Log(rnd.NextDouble()));
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double scale)
		{
			return from x in rnd.NextDoubleSequence()
				select scale * Math.Sqrt(-2.0 * Math.Log(x));
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double scale)
		{
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = scale * Math.Sqrt(-2.0 * Math.Log(values[i]));
				}
			});
		}

		public static double PDF(double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return x / (scale * scale) * Math.Exp((0.0 - x) * x / (2.0 * scale * scale));
		}

		public static double PDFLn(double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Log(x / (scale * scale)) - x * x / (2.0 * scale * scale);
		}

		public static double CDF(double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 1.0 - Math.Exp((0.0 - x) * x / (2.0 * scale * scale));
		}

		public static double InvCDF(double scale, double p)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return scale * Math.Sqrt(-2.0 * Math.Log(1.0 - p));
		}

		public static double Sample(System.Random rnd, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, scale);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, scale);
		}

		public static void Samples(System.Random rnd, double[] values, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, scale);
		}

		public static double Sample(double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, scale);
		}

		public static IEnumerable<double> Samples(double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, scale);
		}

		public static void Samples(double[] values, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, scale);
		}
	}
}
