using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Burr : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		public double A { get; }

		public double C { get; }

		public double K { get; }

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

		public double Mean => 1.0 / SpecialFunctions.Gamma(K) * A * SpecialFunctions.Gamma(1.0 + 1.0 / C) * SpecialFunctions.Gamma(K - 1.0 / C);

		public double Variance => 1.0 / SpecialFunctions.Gamma(K) * Math.Pow(A, 2.0) * SpecialFunctions.Gamma(1.0 + 2.0 / C) * SpecialFunctions.Gamma(K - 2.0 / C) - Math.Pow(1.0 / SpecialFunctions.Gamma(K) * A * SpecialFunctions.Gamma(1.0 + 1.0 / C) * SpecialFunctions.Gamma(K - 1.0 / C), 2.0);

		public double StdDev => Math.Sqrt(Variance);

		public double Mode => A * Math.Pow((C - 1.0) / (C * K + 1.0), 1.0 / C);

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

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
				return (GetMoment(3.0) - 3.0 * mean * variance - mean * mean * mean) / (stdDev * stdDev * stdDev);
			}
		}

		public double Median => A * Math.Pow(Math.Pow(2.0, 1.0 / K) - 1.0, 1.0 / C);

		public Burr(double a, double c, double k, System.Random randomSource = null)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			A = a;
			C = c;
			K = k;
		}

		public override string ToString()
		{
			return $"Burr(a = {A}, c = {C}, k = {K})";
		}

		public static bool IsValidParameterSet(double a, double c, double k)
		{
			if (a.IsFinite() && c.IsFinite() && k.IsFinite() && a > 0.0 && c > 0.0)
			{
				return k > 0.0;
			}
			return false;
		}

		public double Sample()
		{
			return SampleUnchecked(_random, A, C, K);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, A, C, K);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, A, C, K);
		}

		public static double Sample(System.Random rnd, double a, double c, double k)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, a, c, k);
		}

		public static void Samples(System.Random rnd, double[] values, double a, double c, double k)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, a, c, k);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double a, double c, double k)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, a, c, k);
		}

		private static double SampleUnchecked(System.Random rnd, double a, double c, double k)
		{
			double num = 1.0 / k;
			double y = 1.0 / c;
			double num2 = rnd.NextDouble();
			return a * Math.Pow(Math.Pow(1.0 - num2, 0.0 - num) - 1.0, y);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double a, double c, double k)
		{
			if (values.Length != 0)
			{
				double num = 1.0 / k;
				double y = 1.0 / c;
				double[] array = rnd.NextDoubles(values.Length);
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = a * Math.Pow(Math.Pow(1.0 - array[i], 0.0 - num) - 1.0, y);
				}
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double a, double c, double k)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, a, c, k);
			}
		}

		public double GetMoment(double n)
		{
			if (n > K * C)
			{
				throw new ArgumentException("The chosen parameter set is invalid (probably some value is out of range).");
			}
			double num = n / C * SpecialFunctions.Gamma(n / C) * SpecialFunctions.Gamma(K - n / C);
			return Math.Pow(A, n) * num / SpecialFunctions.Gamma(K);
		}

		public double Density(double x)
		{
			return DensityImpl(A, C, K, x);
		}

		public double DensityLn(double x)
		{
			return DensityLnImpl(A, C, K, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CumulativeDistributionImpl(A, C, K, x);
		}

		public static double PDF(double a, double c, double k, double x)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DensityImpl(a, c, k, x);
		}

		public static double PDFLn(double a, double c, double k, double x)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DensityLnImpl(a, c, k, x);
		}

		public static double CDF(double a, double c, double k, double x)
		{
			if (!IsValidParameterSet(a, c, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return CumulativeDistributionImpl(a, c, k, x);
		}

		private static double DensityImpl(double a, double c, double k, double x)
		{
			double num = k * c / a * Math.Pow(x / a, c - 1.0);
			double num2 = Math.Pow(1.0 + Math.Pow(x / a, c), k + 1.0);
			return num / num2;
		}

		private static double DensityLnImpl(double a, double c, double k, double x)
		{
			return Math.Log(DensityImpl(a, c, k, x));
		}

		private static double CumulativeDistributionImpl(double a, double c, double k, double x)
		{
			double num = Math.Pow(1.0 + Math.Pow(x / a, c), k);
			return 1.0 - 1.0 / num;
		}
	}
}
