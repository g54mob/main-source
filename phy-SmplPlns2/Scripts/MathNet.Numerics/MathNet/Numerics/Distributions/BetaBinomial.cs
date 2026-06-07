using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class BetaBinomial : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly int _n;

		private readonly double _a;

		private readonly double _b;

		public int N => _n;

		public double A => _a;

		public double B => _b;

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

		public double Mean => (double)_n * _a / (_a + _b);

		public double Variance => (double)_n * _a * _b * (_a + _b + (double)_n) / (Math.Pow(_a + _b, 2.0) * (_a + _b + 1.0));

		public double StdDev => Math.Sqrt((double)_n * _a * _b * (_a + _b + (double)_n) / (Math.Pow(_a + _b, 2.0) * (_a + _b + 1.0)));

		double IUnivariateDistribution.Entropy
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Skewness => (_a + _b + (double)(2 * _n)) * (_b - _a) / (_a + _b + 2.0) * Math.Sqrt((1.0 + _a + _b) / ((double)_n * _a * _b * ((double)_n + _a + _b)));

		int IDiscreteDistribution.Mode
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		double IUnivariateDistribution.Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public int Minimum => 0;

		public int Maximum => int.MaxValue;

		public BetaBinomial(int n, double a, double b)
		{
			if (!IsValidParameterSet(n, a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_n = n;
			_a = a;
			_b = b;
		}

		public BetaBinomial(int n, double a, double b, System.Random randomSource)
		{
			if (!IsValidParameterSet(n, a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_n = n;
			_a = a;
			_b = b;
		}

		public override string ToString()
		{
			return $"BetaBinomial(n = {_n}, a = {_a}, b = {_b})";
		}

		public static bool IsValidParameterSet(int n, double a, double b)
		{
			if ((double)n >= 1.0 && a > 0.0)
			{
				return b > 0.0;
			}
			return false;
		}

		public static bool IsValidParameterSet(int n, double a, double b, int k)
		{
			if ((double)n >= 1.0 && a > 0.0 && b > 0.0 && k >= 0)
			{
				return k <= n;
			}
			return false;
		}

		public double Probability(int k)
		{
			return PMF(_n, _a, _b, k);
		}

		public double ProbabilityLn(int k)
		{
			return PMFLn(_n, _a, _b, k);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_n, _a, _b, (int)Math.Floor(x));
		}

		public static double PMF(int n, double a, double b, int k)
		{
			if (!IsValidParameterSet(n, a, b, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k > n)
			{
				return 0.0;
			}
			return Math.Exp(PMFLn(n, a, b, k));
		}

		public static double PMFLn(int n, double a, double b, int k)
		{
			if (!IsValidParameterSet(n, a, b, k))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.BinomialLn(n, k) + SpecialFunctions.BetaLn((double)k + a, (double)(n - k) + b) - SpecialFunctions.BetaLn(a, b);
		}

		public static double CDF(int n, double a, double b, int x)
		{
			if (!IsValidParameterSet(n, a, b, x))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = 0.0;
			for (int i = 0; i <= x; i++)
			{
				num += PMF(n, a, b, i);
			}
			return num;
		}

		private static int SampleUnchecked(System.Random rnd, int n, double a, double b)
		{
			double p = Beta.SampleUnchecked(rnd, a, b);
			return Binomial.SampleUnchecked(rnd, p, n);
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, int n, double a, double b)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, n, a, b);
			}
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, int n, double a, double b)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, n, a, b);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _n, _a, _b);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _n, _a, _b);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _n, _a, _b);
		}

		public int Sample(System.Random rnd, int n, double a, double b)
		{
			if (!IsValidParameterSet(n, a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, n, a, b);
		}

		public void Samples(System.Random rnd, int[] values, int n, double a, double b)
		{
			if (!IsValidParameterSet(n, a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, n, a, b);
		}

		public IEnumerable<int> Samples(int n, double a, double b)
		{
			if (!IsValidParameterSet(n, a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(_random, n, a, b);
		}

		public void Samples(int[] values, int n, double a, double b)
		{
			if (!IsValidParameterSet(n, a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(_random, values, n, a, b);
		}
	}
}
