using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Laplace : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _location;

		private readonly double _scale;

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

		public double Mean => _location;

		public double Variance => 2.0 * _scale * _scale;

		public double StdDev => 1.4142135623730951 * _scale;

		public double Entropy => Math.Log(Math.E * 2.0 * _scale);

		public double Skewness => 0.0;

		public double Mode => _location;

		public double Median => _location;

		public double Minimum => double.NegativeInfinity;

		public double Maximum => double.PositiveInfinity;

		public Laplace()
			: this(0.0, 1.0)
		{
		}

		public Laplace(double location, double scale)
		{
			if (!IsValidParameterSet(location, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_location = location;
			_scale = scale;
		}

		public Laplace(double location, double scale, System.Random randomSource)
		{
			if (!IsValidParameterSet(location, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_location = location;
			_scale = scale;
		}

		public override string ToString()
		{
			return $"Laplace(μ = {_location}, b = {_scale})";
		}

		public static bool IsValidParameterSet(double location, double scale)
		{
			if (scale > 0.0)
			{
				return !double.IsNaN(location);
			}
			return false;
		}

		public double Density(double x)
		{
			return Math.Exp((0.0 - Math.Abs(x - _location)) / _scale) / (2.0 * _scale);
		}

		public double DensityLn(double x)
		{
			return (0.0 - Math.Abs(x - _location)) / _scale - Math.Log(2.0 * _scale);
		}

		public double CumulativeDistribution(double x)
		{
			return 0.5 * (1.0 + (double)Math.Sign(x - _location) * (1.0 - Math.Exp((0.0 - Math.Abs(x - _location)) / _scale)));
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _location, _scale);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _location, _scale);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _location, _scale);
		}

		private static double SampleUnchecked(System.Random rnd, double location, double scale)
		{
			double value = rnd.NextDouble() - 0.5;
			return location - scale * (double)Math.Sign(value) * Math.Log(1.0 - 2.0 * Math.Abs(value));
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double location, double scale)
		{
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					double value = values[i] - 0.5;
					values[i] = location - scale * (double)Math.Sign(value) * Math.Log(1.0 - 2.0 * Math.Abs(value));
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double location, double scale)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, location, scale);
			}
		}

		public static double PDF(double location, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Exp((0.0 - Math.Abs(x - location)) / scale) / (2.0 * scale);
		}

		public static double PDFLn(double location, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return (0.0 - Math.Abs(x - location)) / scale - Math.Log(2.0 * scale);
		}

		public static double CDF(double location, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 0.5 * (1.0 + (double)Math.Sign(x - location) * (1.0 - Math.Exp((0.0 - Math.Abs(x - location)) / scale)));
		}

		public static double Sample(System.Random rnd, double location, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, location, scale);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double location, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, location, scale);
		}

		public static void Samples(System.Random rnd, double[] values, double location, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, location, scale);
		}

		public static double Sample(double location, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, location, scale);
		}

		public static IEnumerable<double> Samples(double location, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, location, scale);
		}

		public static void Samples(double[] values, double location, double scale)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, location, scale);
		}
	}
}
