using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class SkewedGeneralizedT : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private IContinuousDistribution _d;

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

		public double Q { get; }

		public double Mode
		{
			get
			{
				IContinuousDistribution d = _d;
				if (d == null)
				{
					if (Skew != 0.0)
					{
						return Mean - AdjustAddend(AdjustScale(Scale, Skew, P, Q), Skew, P, Q);
					}
					return Mean;
				}
				return d.Mode;
			}
		}

		public double Minimum => _d?.Minimum ?? double.NegativeInfinity;

		public double Maximum => _d?.Maximum ?? double.PositiveInfinity;

		public double Mean => _d?.Mean ?? Location;

		public double Variance => _d?.Variance ?? (Scale * Scale);

		public double StdDev => _d?.StdDev ?? Scale;

		public double Entropy => (_d ?? throw new NotImplementedException()).Entropy;

		public double Skewness => _d?.Skewness ?? _skewness;

		public double Median
		{
			get
			{
				IContinuousDistribution d = _d;
				if (d == null)
				{
					if (Skew != 0.0)
					{
						return InverseCumulativeDistribution(0.5);
					}
					return Mean;
				}
				return d.Median;
			}
		}

		public SkewedGeneralizedT()
		{
			_random = SystemRandomSource.Default;
			Location = 0.0;
			Scale = 1.0;
			Skew = 0.0;
			P = 2.0;
			Q = double.PositiveInfinity;
			_d = new Normal(Location, Scale, _random);
		}

		public SkewedGeneralizedT(double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			Location = location;
			Scale = scale;
			Skew = skew;
			P = p;
			Q = q;
			_d = FindSpecializedDistribution(location, scale, skew, p, q);
			if (_d == null)
			{
				_skewness = CalculateSkewness();
			}
		}

		public static IContinuousDistribution FindSpecializedDistribution(double location, double scale, double skew, double p, double q)
		{
			if (p == double.PositiveInfinity)
			{
				scale *= Math.Sqrt(3.0);
				return new ContinuousUniform(location - scale, location + scale);
			}
			if (q == double.PositiveInfinity)
			{
				return new SkewedGeneralizedError(location, scale, skew, p);
			}
			return null;
		}

		public override string ToString()
		{
			return $"SkewedGeneralizedT(μ = {Location}, σ = {Scale}, λ = {Skew}, p = {P}, q = {Q})";
		}

		public static bool IsValidParameterSet(double location, double scale, double skew, double p, double q)
		{
			if (scale > 0.0 && skew > -1.0 && skew < 1.0 && p > 0.0 && q > 0.0 && p * q > 2.0)
			{
				return !double.IsNaN(location);
			}
			return false;
		}

		private double CalculateSkewness()
		{
			if (P * Q <= 3.0 || Skew == 0.0)
			{
				return 0.0;
			}
			double x = AdjustScale(Scale, Skew, P, Q);
			double num = SpecialFunctions.Beta(1.0 / P, Q);
			double num2 = SpecialFunctions.Beta(2.0 / P, Q - 1.0 / P);
			double num3 = SpecialFunctions.Beta(3.0 / P, Q - 2.0 / P);
			double num4 = SpecialFunctions.Beta(4.0 / P, Q - 3.0 / P);
			double num5 = 2.0 * Math.Pow(Q, 3.0 / P) * Skew * Math.Pow(x, 3.0) / Math.Pow(num, 3.0);
			double num6 = 8.0 * Skew * Skew * Math.Pow(num2, 3.0);
			double num7 = 3.0 * (1.0 + 3.0 * Skew * Skew) * num;
			double num8 = num2 * num3;
			double num9 = 2.0 * (1.0 + Skew * Skew) * Math.Pow(num, 2.0) * num4;
			return num5 * (num6 - num7 * num8 + num9);
		}

		private static double AdjustScale(double scale, double skew, double p, double q)
		{
			double num = SpecialFunctions.Beta(3.0 / p, q - 2.0 / p);
			double num2 = SpecialFunctions.Beta(1.0 / p, q);
			double num3 = SpecialFunctions.Beta(2.0 / p, q - 1.0 / p);
			double num4 = SpecialFunctions.Beta(1.0 / p, q);
			return scale / (Math.Pow(q, 1.0 / p) * Math.Sqrt((3.0 * skew * skew + 1.0) * num / num2 - 4.0 * skew * skew * (num3 / num4 * (num3 / num4))));
		}

		private static double AdjustX(double x, double scale, double skew, double p, double q)
		{
			return x + AdjustAddend(scale, skew, p, q);
		}

		private static double AdjustAddend(double scale, double skew, double p, double q)
		{
			double num = SpecialFunctions.Beta(2.0 / p, q - 1.0 / p);
			double num2 = SpecialFunctions.Beta(1.0 / p, q);
			return 2.0 * scale * skew * Math.Pow(q, 1.0 / p) * num / num2;
		}

		public static double PDF(double location, double scale, double skew, double p, double q, double x)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return PDFunc(location, scale, skew, p, q, ln: false)(x);
		}

		public static double PDFLn(double location, double scale, double skew, double p, double q, double x)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return PDFunc(location, scale, skew, p, q, ln: true)(x);
		}

		private static double PDFull(double location, double scale, double skew, double p, double q, double x)
		{
			scale = AdjustScale(scale, skew, p, q);
			x = AdjustX(x, scale, skew, p, q);
			double num = SpecialFunctions.Beta(1.0 / p, q);
			int num2 = Math.Sign(x - location);
			double num3 = Math.Pow(Math.Abs(x - location), p);
			double num4 = q * Math.Pow(scale, p) * Math.Pow(skew * (double)num2 + 1.0, p);
			double num5 = 2.0 * scale * Math.Pow(q, 1.0 / p) * num * Math.Pow(num3 / num4 + 1.0, 1.0 / p + q);
			return p / num5;
		}

		private static double PDFullLn(double location, double scale, double skew, double p, double q, double x)
		{
			scale = AdjustScale(scale, skew, p, q);
			x = AdjustX(x, scale, skew, p, q);
			double num = SpecialFunctions.BetaLn(1.0 / p, q);
			return Math.Log(p) - Math.Log(2.0) - Math.Log(scale) - Math.Log(q) / p - num - (1.0 / p + q) * Math.Log(1.0 + Math.Pow(Math.Abs(x - location), p) / (q * Math.Pow(scale, p) * Math.Pow(1.0 + skew * (double)Math.Sign(x - location), p)));
		}

		private static Func<double, double> PDFunc(double location, double scale, double skew, double p, double q, bool ln)
		{
			if (p == double.PositiveInfinity)
			{
				scale *= Math.Sqrt(3.0);
				return (double x) => (!ln) ? ContinuousUniform.PDF(-1.0 * (Math.Sqrt(3.0) * scale + location), Math.Sqrt(3.0) * scale + location, x) : ContinuousUniform.PDFLn(location - scale, location + scale, x);
			}
			if (q == double.PositiveInfinity)
			{
				return (double x) => (!ln) ? SkewedGeneralizedError.PDF(location, scale, skew, p, x) : SkewedGeneralizedError.PDFLn(location, scale, skew, p, x);
			}
			return (double x) => (!ln) ? PDFull(location, scale, skew, p, q, x) : PDFullLn(location, scale, skew, p, q, x);
		}

		public static double CDF(double location, double scale, double skew, double p, double q, double x)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			scale = AdjustScale(scale, skew, p, q);
			x = AdjustX(x, scale, skew, p, q) - location;
			bool num = x > 0.0;
			if (num)
			{
				skew = 0.0 - skew;
				x = 0.0 - x;
			}
			double num2 = (1.0 - skew) / 2.0 + (skew - 1.0) / 2.0 * Beta.CDF(1.0 / p, q, 1.0 / (1.0 + q * Math.Pow(scale * (1.0 - skew) / (0.0 - x), p)));
			if (!num)
			{
				return num2;
			}
			return 1.0 - num2;
		}

		public static double InvCDF(double location, double scale, double skew, double p, double q, double pr)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			IContinuousDistribution continuousDistribution = FindSpecializedDistribution(location, scale, skew, p, q);
			if (continuousDistribution != null)
			{
				if (continuousDistribution is SkewedGeneralizedError skewedGeneralizedError)
				{
					return skewedGeneralizedError.InverseCumulativeDistribution(pr);
				}
				if (continuousDistribution is ContinuousUniform continuousUniform)
				{
					return continuousUniform.InverseCumulativeDistribution(pr);
				}
			}
			scale = AdjustScale(scale, skew, p, q);
			bool num = pr > (1.0 - skew) / 2.0;
			double num2 = skew;
			if (num)
			{
				pr = 1.0 - pr;
				num2 = 0.0 - num2;
			}
			double num3 = scale * (num2 - 1.0) * Math.Pow(1.0 / (q * Beta.InvCDF(1.0 / p, q, 1.0 - 2.0 * pr / (1.0 - num2))) - 1.0 / q, -1.0 / p);
			if (num)
			{
				num3 = 0.0 - num3;
			}
			num3 += location;
			return num3 - AdjustAddend(scale, skew, p, q);
		}

		public double CumulativeDistribution(double x)
		{
			return _d?.CumulativeDistribution(x) ?? CDF(Location, Scale, Skew, P, Q, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			if (_d != null)
			{
				IContinuousDistribution d = _d;
				if (d is SkewedGeneralizedError skewedGeneralizedError)
				{
					return skewedGeneralizedError.InverseCumulativeDistribution(p);
				}
				if (d is ContinuousUniform continuousUniform)
				{
					return continuousUniform.InverseCumulativeDistribution(p);
				}
			}
			return InvCDF(Location, Scale, Skew, P, Q, p);
		}

		public double Density(double x)
		{
			return _d?.Density(x) ?? PDF(Location, Scale, Skew, P, Q, x);
		}

		public double DensityLn(double x)
		{
			return _d?.DensityLn(x) ?? PDFLn(Location, Scale, Skew, P, Q, x);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, Location, Scale, Skew, P, Q);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, Location, Scale, Skew, P, Q);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, Location, Scale, Skew, P, Q);
		}

		private static double SampleUnchecked(System.Random rnd, double location, double scale, double skew, double p, double q)
		{
			double pr = ContinuousUniform.Sample(rnd, 0.0, 1.0);
			return InvCDF(location, scale, skew, p, q, pr);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double location, double scale, double skew, double p, double q)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, location, scale, skew, p, q);
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double location, double scale, double skew, double p, double q)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, location, scale, skew, p, q);
			}
		}

		public static double Sample(System.Random rnd, double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, location, scale, skew, p, q);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, location, scale, skew, p, q);
		}

		public static void Samples(System.Random rnd, double[] values, double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, location, scale, skew, p, q);
		}

		public static double Sample(double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, location, scale, skew, p, q);
		}

		public static IEnumerable<double> Samples(double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, location, scale, skew, p, q);
		}

		public static void Samples(double[] values, double location, double scale, double skew, double p, double q)
		{
			if (!IsValidParameterSet(location, scale, skew, p, q))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, location, scale, skew, p, q);
		}
	}
}
