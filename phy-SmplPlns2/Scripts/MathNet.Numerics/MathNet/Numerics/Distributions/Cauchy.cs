using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Cauchy : IContinuousDistribution, IUnivariateDistribution, IDistribution
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

		public double Mean
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Variance
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double StdDev
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Entropy => Math.Log(Math.PI * 4.0 * _scale);

		public double Skewness
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Mode => _location;

		public double Median => _location;

		public double Minimum => double.NegativeInfinity;

		public double Maximum => double.PositiveInfinity;

		public Cauchy()
			: this(0.0, 1.0)
		{
		}

		public Cauchy(double location, double scale)
		{
			if (!IsValidParameterSet(location, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_location = location;
			_scale = scale;
		}

		public Cauchy(double location, double scale, System.Random randomSource)
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
			return $"Cauchy(x0 = {_location}, γ = {_scale})";
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
			double num = (x - _location) / _scale;
			return 1.0 / (Math.PI * _scale * (1.0 + num * num));
		}

		public double DensityLn(double x)
		{
			double num = (x - _location) / _scale;
			return 0.0 - Math.Log(Math.PI * _scale * (1.0 + num * num));
		}

		public double CumulativeDistribution(double x)
		{
			return 1.0 / Math.PI * Math.Atan((x - _location) / _scale) + 0.5;
		}

		public double InverseCumulativeDistribution(double p)
		{
			if (!(p <= 0.0))
			{
				if (!(p >= 1.0))
				{
					return _location + _scale * Math.Tan((p - 0.5) * Math.PI);
				}
				return double.PositiveInfinity;
			}
			return double.NegativeInfinity;
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
			return location + scale * Math.Tan(Math.PI * (rnd.NextDouble() - 0.5));
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double location, double scale)
		{
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = location + scale * Math.Tan(Math.PI * (values[i] - 0.5));
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double location, double scale)
		{
			while (true)
			{
				yield return location + scale * Math.Tan(Math.PI * (rnd.NextDouble() - 0.5));
			}
		}

		public static double PDF(double location, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - location) / scale;
			return 1.0 / (Math.PI * scale * (1.0 + num * num));
		}

		public static double PDFLn(double location, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = (x - location) / scale;
			return 0.0 - Math.Log(Math.PI * scale * (1.0 + num * num));
		}

		public static double CDF(double location, double scale, double x)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Atan((x - location) / scale) / Math.PI + 0.5;
		}

		public static double InvCDF(double location, double scale, double p)
		{
			if (scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(p <= 0.0))
			{
				if (!(p >= 1.0))
				{
					return location + scale * Math.Tan((p - 0.5) * Math.PI);
				}
				return double.PositiveInfinity;
			}
			return double.NegativeInfinity;
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
