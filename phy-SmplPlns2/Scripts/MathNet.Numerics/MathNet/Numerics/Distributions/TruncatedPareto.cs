using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class TruncatedPareto : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

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

		public double Scale { get; }

		public double Shape { get; }

		public double Truncation { get; }

		public double Mean => GetMoment(1);

		public double Variance => GetMoment(2) - Math.Pow(GetMoment(1), 2.0);

		public double StdDev => Math.Sqrt(Variance);

		public double Mode
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Minimum => Scale;

		public double Maximum => Truncation;

		public double Entropy
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Skewness
		{
			get
			{
				double mean = Mean;
				double variance = Variance;
				double stdDev = StdDev;
				return (GetMoment(3) - 3.0 * mean * variance - mean * mean * mean) / (stdDev * stdDev * stdDev);
			}
		}

		public double Median => Scale * Math.Pow(1.0 - 0.5 * (1.0 - Math.Pow(Scale / Truncation, Shape)), 0.0 - 1.0 / Shape);

		public TruncatedPareto(double scale, double shape, double truncation, System.Random randomSource = null)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			Scale = scale;
			Shape = shape;
			Truncation = truncation;
		}

		public override string ToString()
		{
			return $"Truncated Pareto(Scale = {Scale}, Shape = {Shape}, Truncation = {Truncation})";
		}

		public static bool IsValidParameterSet(double scale, double shape, double truncation)
		{
			if (scale.IsFinite() && shape.IsFinite() && truncation.IsFinite() && scale > 0.0 && shape > 0.0)
			{
				return truncation > scale;
			}
			return false;
		}

		public double GetMoment(int n)
		{
			if (Shape.AlmostEqual(n))
			{
				return Shape * Math.Pow(Scale, n) / (1.0 - Math.Pow(Scale / Truncation, Shape)) * Math.Log(Truncation / Scale);
			}
			return Shape * Math.Pow(Scale, n) / (Shape - (double)n) * ((1.0 - Math.Pow(Scale / Truncation, Shape - (double)n)) / (1.0 - Math.Pow(Scale / Truncation, Shape)));
		}

		public double Sample()
		{
			return SampleUnchecked(_random, Scale, Shape, Truncation);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, Scale, Shape, Truncation);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, Scale, Shape, Truncation);
		}

		public static double Sample(System.Random rnd, double scale, double shape, double truncation)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, scale, shape, truncation);
		}

		public static void Samples(System.Random rnd, double[] values, double scale, double shape, double truncation)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, scale, shape, truncation);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double scale, double shape, double truncation)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, scale, shape, truncation);
		}

		internal static double SampleUnchecked(System.Random rnd, double scale, double shape, double truncation)
		{
			double p = rnd.NextDouble();
			return InvCDFUncheckedImpl(scale, shape, truncation, p);
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double scale, double shape, double truncation)
		{
			if (values.Length != 0)
			{
				double[] array = rnd.NextDoubles(values.Length);
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = InvCDFUncheckedImpl(scale, shape, truncation, array[i]);
				}
			}
		}

		internal static IEnumerable<double> SamplesUnchecked(System.Random rnd, double scale, double shape, double truncation)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, scale, shape, truncation);
			}
		}

		public double Density(double x)
		{
			return DensityImpl(Scale, Shape, Truncation, x);
		}

		public double DensityLn(double x)
		{
			return DensityLnImpl(Scale, Shape, Truncation, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CumulativeDistributionImpl(Scale, Shape, Truncation, x);
		}

		public double InvCDF(double p)
		{
			return InvCDFUncheckedImpl(Scale, Shape, Truncation, p);
		}

		public static double InvCDF(double scale, double shape, double truncation, double p)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return InvCDFUncheckedImpl(scale, shape, truncation, p);
		}

		public static double PDF(double scale, double shape, double truncation, double x)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DensityImpl(scale, shape, truncation, x);
		}

		public static double PDFLn(double scale, double shape, double truncation, double x)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DensityLnImpl(scale, shape, truncation, x);
		}

		public static double CDF(double scale, double shape, double truncation, double x)
		{
			if (!IsValidParameterSet(scale, shape, truncation))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return CumulativeDistributionImpl(scale, shape, truncation, x);
		}

		private static double DensityImpl(double scale, double shape, double truncation, double x)
		{
			if (x < scale || x > truncation)
			{
				return 0.0;
			}
			return shape * Math.Pow(scale, shape) * Math.Pow(x, 0.0 - shape - 1.0) / (1.0 - Math.Pow(scale / truncation, shape));
		}

		private static double DensityLnImpl(double scale, double shape, double truncation, double x)
		{
			return Math.Log(DensityImpl(scale, shape, truncation, x));
		}

		private static double CumulativeDistributionImpl(double scale, double shape, double truncation, double x)
		{
			if (x <= scale)
			{
				return 0.0;
			}
			if (x >= truncation)
			{
				return 1.0;
			}
			return (1.0 - Math.Pow(scale, shape) * Math.Pow(x, 0.0 - shape)) / (1.0 - Math.Pow(scale / truncation, shape));
		}

		private static double InvCDFUncheckedImpl(double scale, double shape, double truncation, double p)
		{
			double num = p * Math.Pow(truncation, shape) - p * Math.Pow(scale, shape) - Math.Pow(truncation, shape);
			double num2 = Math.Pow(truncation, shape) * Math.Pow(scale, shape);
			return Math.Pow((0.0 - num) / num2, 0.0 - 1.0 / shape);
		}
	}
}
