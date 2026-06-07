using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class SkewedGeneralizedError : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _skewness;

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

		public double Location { get; }

		public double Scale { get; }

		public double Skew { get; }

		public double P { get; }

		public double Mode
		{
			get
			{
				if (Skew != 0.0)
				{
					return Mean - AdjustAddend(AdjustScale(Scale, Skew, P), Skew, P);
				}
				return Mean;
			}
		}

		public double Minimum => double.NegativeInfinity;

		public double Maximum => double.PositiveInfinity;

		public double Mean => Location;

		public double Variance => Scale * Scale;

		public double StdDev => Scale;

		public double Entropy
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public double Skewness => _skewness;

		public double Median
		{
			get
			{
				if (Skew != 0.0)
				{
					return InverseCumulativeDistribution(0.5);
				}
				return Mean;
			}
		}

		public SkewedGeneralizedError()
		{
			_random = SystemRandomSource.Default;
			Location = 0.0;
			Scale = 1.0;
			Skew = 0.0;
			P = 2.0;
		}

		public SkewedGeneralizedError(double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			Location = location;
			Scale = scale;
			Skew = skew;
			P = p;
			_skewness = CalculateSkewness();
		}

		public override string ToString()
		{
			return $"SkewedGeneralizedError(μ = {Location}, σ = {Scale}, λ = {Skew}, p = {P}";
		}

		public static bool IsValidParameterSet(double location, double scale, double skew, double p)
		{
			if (scale > 0.0 && skew > -1.0 && skew < 1.0 && p > 0.0)
			{
				return !double.IsNaN(location);
			}
			return false;
		}

		private double CalculateSkewness()
		{
			if (Skew == 0.0)
			{
				return 0.0;
			}
			double num = Math.Pow(Math.PI, 1.5);
			double num2 = SpecialFunctions.Gamma(1.0 / P);
			double num3 = SpecialFunctions.Gamma(0.5 + 1.0 / P);
			double num4 = SpecialFunctions.Gamma(3.0 / P);
			double num5 = SpecialFunctions.Gamma(4.0 / P);
			double num6 = Skew * Scale * Scale * Scale / (num * num2);
			double num7 = Math.Pow(2.0, (6.0 + P) / P) * Skew * Skew * Math.Pow(num3, 3.0) * num2;
			double num8 = 3.0 * Math.Pow(4.0, 1.0 / P) * Math.PI * (1.0 + 3.0 * Skew * Skew) * num3 * num4;
			double num9 = 4.0 * num * (1.0 + Skew * Skew) * num5;
			return num6 * (num7 - num8 + num9);
		}

		private static double AdjustScale(double scale, double skew, double p)
		{
			double num = SpecialFunctions.Gamma(3.0 / p);
			double x = SpecialFunctions.Gamma(0.5 + 1.0 / p);
			double num2 = SpecialFunctions.Gamma(1.0 / p);
			double num3 = SpecialFunctions.Gamma(1.0 / p);
			double num4 = Math.PI * (1.0 + 3.0 * skew * skew) * num;
			double num5 = Math.Pow(16.0, 1.0 / p) * skew * skew * Math.Pow(x, 2.0) * num2;
			double num6 = Math.PI * num3;
			return scale / Math.Sqrt((num4 - num5) / num6);
		}

		private static double AdjustX(double x, double scale, double skew, double p)
		{
			return x + AdjustAddend(scale, skew, p);
		}

		private static double AdjustAddend(double scale, double skew, double p)
		{
			return Math.Pow(2.0, 2.0 / p) * scale * skew * SpecialFunctions.Gamma(0.5 + 1.0 / p) / 1.772453850905516;
		}

		public static double PDF(double location, double scale, double skew, double p, double x)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			scale = AdjustScale(scale, skew, p);
			x = AdjustX(x, scale, skew, p);
			double num = Math.Abs(x - location);
			double num2 = scale * (1.0 + skew * (double)Math.Sign(x - location));
			double num3 = 2.0 * scale * SpecialFunctions.Gamma(1.0 / p);
			return p / (Math.Exp(Math.Pow(num / num2, p)) * num3);
		}

		public static double PDFLn(double location, double scale, double skew, double p, double x)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			scale = AdjustScale(scale, skew, p);
			x = AdjustX(x, scale, skew, p);
			return Math.Log(p) - Math.Log(2.0) - Math.Log(scale) - SpecialFunctions.GammaLn(1.0 / p) - Math.Pow(Math.Abs(x - location) / (scale * (1.0 + skew * (double)Math.Sign(x - location))), p);
		}

		public static double CDF(double location, double scale, double skew, double p, double x)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			scale = AdjustScale(scale, skew, p);
			x = AdjustX(x, scale, skew, p) - location;
			bool num = x < 0.0;
			if (num)
			{
				skew = 0.0 - skew;
				x = 0.0 - x;
			}
			double num2 = (1.0 - skew) / 2.0 + (1.0 + skew) / 2.0 * Gamma.CDF(1.0 / p, 1.0, Math.Pow(x / (scale * (1.0 + skew)), p));
			if (!num)
			{
				return num2;
			}
			return 1.0 - num2;
		}

		public static double InvCDF(double location, double scale, double skew, double p, double pr)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			scale = AdjustScale(scale, skew, p);
			bool num = pr < (1.0 - skew) / 2.0;
			double num2 = skew;
			if (num)
			{
				pr = 1.0 - pr;
				num2 = 0.0 - num2;
			}
			double num3 = scale * (1.0 + num2) * Math.Pow(Gamma.InvCDF(1.0 / p, 1.0, 2.0 * pr / (1.0 + num2) + (num2 - 1.0) / (num2 + 1.0)), 1.0 / p);
			if (num)
			{
				num3 = 0.0 - num3;
			}
			num3 += location;
			return num3 - AdjustAddend(scale, skew, p);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(Location, Scale, Skew, P, p);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(Location, Scale, Skew, P, x);
		}

		public double Density(double x)
		{
			return PDF(Location, Scale, Skew, P, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(Location, Scale, Skew, P, x);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, Location, Scale, Skew, P);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, Location, Scale, Skew, P);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, Location, Scale, Skew, P);
		}

		private static double SampleUnchecked(System.Random rnd, double location, double scale, double skew, double p)
		{
			double pr = ContinuousUniform.Sample(rnd, 0.0, 1.0);
			return InvCDF(location, scale, skew, p, pr);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double location, double scale, double skew, double p)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, location, scale, skew, p);
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double location, double scale, double skew, double p)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, location, scale, skew, p);
			}
		}

		public static double Sample(System.Random rnd, double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, location, scale, skew, p);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, location, scale, skew, p);
		}

		public static void Samples(System.Random rnd, double[] values, double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, location, scale, skew, p);
		}

		public static double Sample(double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, location, scale, skew, p);
		}

		public static IEnumerable<double> Samples(double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, location, scale, skew, p);
		}

		public static void Samples(double[] values, double location, double scale, double skew, double p)
		{
			if (!IsValidParameterSet(location, scale, skew, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, location, scale, skew, p);
		}
	}
}
