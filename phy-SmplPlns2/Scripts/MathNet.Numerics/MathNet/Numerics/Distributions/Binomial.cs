using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Binomial : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _p;

		private readonly int _trials;

		public double P => _p;

		public int N => _trials;

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

		public double Mean => _p * (double)_trials;

		public double StdDev => Math.Sqrt(_p * (1.0 - _p) * (double)_trials);

		public double Variance => _p * (1.0 - _p) * (double)_trials;

		public double Entropy
		{
			get
			{
				if (_p == 0.0 || _p == 1.0)
				{
					return 0.0;
				}
				double num = 0.0;
				for (int i = 0; i <= _trials; i++)
				{
					double num2 = Probability(i);
					num -= num2 * Math.Log(num2);
				}
				return num;
			}
		}

		public double Skewness => (1.0 - 2.0 * _p) / Math.Sqrt((double)_trials * _p * (1.0 - _p));

		public int Minimum => 0;

		public int Maximum => _trials;

		public int Mode
		{
			get
			{
				if (_p == 1.0)
				{
					return _trials;
				}
				if (_p == 0.0)
				{
					return 0;
				}
				return (int)Math.Floor((double)(_trials + 1) * _p);
			}
		}

		public int[] Modes
		{
			get
			{
				if (_p == 1.0)
				{
					return new int[1] { _trials };
				}
				if (_p == 0.0)
				{
					return new int[1];
				}
				double num = (double)(_trials + 1) * _p;
				int num2 = (int)Math.Floor(num);
				if ((double)num2 != num)
				{
					return new int[1] { num2 };
				}
				return new int[2]
				{
					num2,
					num2 - 1
				};
			}
		}

		public double Median => Math.Floor(_p * (double)_trials);

		public Binomial(double p, int n)
		{
			if (!IsValidParameterSet(p, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_p = p;
			_trials = n;
		}

		public Binomial(double p, int n, System.Random randomSource)
		{
			if (!IsValidParameterSet(p, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_p = p;
			_trials = n;
		}

		public override string ToString()
		{
			return $"Binomial(p = {_p}, n = {_trials})";
		}

		public static bool IsValidParameterSet(double p, int n)
		{
			if (p >= 0.0 && p <= 1.0)
			{
				return n >= 0;
			}
			return false;
		}

		public double Probability(int k)
		{
			return PMF(_p, _trials, k);
		}

		public double ProbabilityLn(int k)
		{
			return PMFLn(_p, _trials, k);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_p, _trials, x);
		}

		public static double PMF(double p, int n, int k)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k < 0 || k > n)
			{
				return 0.0;
			}
			if (p == 0.0)
			{
				if (k != 0)
				{
					return 0.0;
				}
				return 1.0;
			}
			if (p == 1.0)
			{
				if (k != n)
				{
					return 0.0;
				}
				return 1.0;
			}
			return Math.Exp(SpecialFunctions.BinomialLn(n, k) + (double)k * Math.Log(p) + (double)(n - k) * Math.Log(1.0 - p));
		}

		public static double PMFLn(double p, int n, int k)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k < 0 || k > n)
			{
				return double.NegativeInfinity;
			}
			if (p == 0.0)
			{
				if (k != 0)
				{
					return double.NegativeInfinity;
				}
				return 0.0;
			}
			if (p == 1.0)
			{
				if (k != n)
				{
					return double.NegativeInfinity;
				}
				return 0.0;
			}
			return SpecialFunctions.BinomialLn(n, k) + (double)k * Math.Log(p) + (double)(n - k) * Math.Log(1.0 - p);
		}

		public static double CDF(double p, int n, double x)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0)
			{
				return 0.0;
			}
			if (x > (double)n)
			{
				return 1.0;
			}
			double num = Math.Floor(x);
			return SpecialFunctions.BetaRegularized((double)n - num, num + 1.0, 1.0 - p);
		}

		internal static int SampleUnchecked(System.Random rnd, double p, int n)
		{
			int num = 0;
			for (int i = 0; i < n; i++)
			{
				num += ((rnd.NextDouble() < p) ? 1 : 0);
			}
			return num;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double p, int n)
		{
			double[] uniform = rnd.NextDoubles(values.Length * n);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					int num = i * n;
					int num2 = 0;
					for (int j = 0; j < n; j++)
					{
						num2 += ((uniform[num + j] < p) ? 1 : 0);
					}
					values[i] = num2;
				}
			});
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double p, int n)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, p, n);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _p, _trials);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _p, _trials);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _p, _trials);
		}

		public static int Sample(System.Random rnd, double p, int n)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, p, n);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double p, int n)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, p, n);
		}

		public static void Samples(System.Random rnd, int[] values, double p, int n)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, p, n);
		}

		public static int Sample(double p, int n)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, p, n);
		}

		public static IEnumerable<int> Samples(double p, int n)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, p, n);
		}

		public static void Samples(int[] values, double p, int n)
		{
			if (!(p >= 0.0) || !(p <= 1.0) || n < 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, p, n);
		}
	}
}
