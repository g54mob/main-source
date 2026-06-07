using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Zipf : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _s;

		private readonly int _n;

		public double S => _s;

		public int N => _n;

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

		public double Mean => SpecialFunctions.GeneralHarmonic(_n, _s - 1.0) / SpecialFunctions.GeneralHarmonic(_n, _s);

		public double Variance
		{
			get
			{
				if (_s <= 3.0)
				{
					throw new NotSupportedException();
				}
				double num = SpecialFunctions.GeneralHarmonic(_n, _s);
				return SpecialFunctions.GeneralHarmonic(_n, _s - 2.0) * SpecialFunctions.GeneralHarmonic(_n, _s) - Math.Pow(SpecialFunctions.GeneralHarmonic(_n, _s - 1.0), 2.0) / (num * num);
			}
		}

		public double StdDev => Math.Sqrt(Variance);

		public double Entropy
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < _n; i++)
				{
					num += Math.Log(i + 1) / Math.Pow(i + 1, _s);
				}
				return _s / SpecialFunctions.GeneralHarmonic(_n, _s) * num + Math.Log(SpecialFunctions.GeneralHarmonic(_n, _s));
			}
		}

		public double Skewness
		{
			get
			{
				if (_s <= 4.0)
				{
					throw new NotSupportedException();
				}
				return (SpecialFunctions.GeneralHarmonic(_n, _s - 3.0) * Math.Pow(SpecialFunctions.GeneralHarmonic(_n, _s), 2.0) - SpecialFunctions.GeneralHarmonic(_n, _s - 1.0) * (3.0 * SpecialFunctions.GeneralHarmonic(_n, _s - 2.0) * SpecialFunctions.GeneralHarmonic(_n, _s) - Math.Pow(SpecialFunctions.GeneralHarmonic(_n, _s - 1.0), 2.0))) / Math.Pow(SpecialFunctions.GeneralHarmonic(_n, _s - 2.0) * SpecialFunctions.GeneralHarmonic(_n, _s) - Math.Pow(SpecialFunctions.GeneralHarmonic(_n, _s - 1.0), 2.0), 1.5);
			}
		}

		public int Mode => 1;

		public double Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public int Minimum => 1;

		public int Maximum => _n;

		public Zipf(double s, int n)
		{
			if (!IsValidParameterSet(s, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_s = s;
			_n = n;
		}

		public Zipf(double s, int n, System.Random randomSource)
		{
			if (!IsValidParameterSet(s, n))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_s = s;
			_n = n;
		}

		public override string ToString()
		{
			return $"Zipf(S = {_s}, N = {_n})";
		}

		public static bool IsValidParameterSet(double s, int n)
		{
			if (n > 0)
			{
				return s > 0.0;
			}
			return false;
		}

		public double Probability(int k)
		{
			return 1.0 / Math.Pow(k, _s) / SpecialFunctions.GeneralHarmonic(_n, _s);
		}

		public double ProbabilityLn(int k)
		{
			return Math.Log(Probability(k));
		}

		public double CumulativeDistribution(double x)
		{
			if (x < 1.0)
			{
				return 0.0;
			}
			return SpecialFunctions.GeneralHarmonic((int)x, _s) / SpecialFunctions.GeneralHarmonic(_n, _s);
		}

		public static double PMF(double s, int n, int k)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 1.0 / Math.Pow(k, s) / SpecialFunctions.GeneralHarmonic(n, s);
		}

		public static double PMFLn(double s, int n, int k)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Log(PMF(s, n, k));
		}

		public static double CDF(double s, int n, double x)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 1.0)
			{
				return 0.0;
			}
			return SpecialFunctions.GeneralHarmonic((int)x, s) / SpecialFunctions.GeneralHarmonic(n, s);
		}

		private static int SampleUnchecked(System.Random rnd, double s, int n)
		{
			double num;
			for (num = 0.0; num == 0.0; num = rnd.NextDouble())
			{
			}
			double num2 = 1.0 / SpecialFunctions.GeneralHarmonic(n, s);
			double num3 = 0.0;
			int i;
			for (i = 1; i <= n; i++)
			{
				num3 += num2 / Math.Pow(i, s);
				if (num3 >= num)
				{
					break;
				}
			}
			return i;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double s, int n)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, s, n);
			}
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double s, int n)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, s, n);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _s, _n);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _s, _n);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _s, _n);
		}

		public static int Sample(System.Random rnd, double s, int n)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, s, n);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double s, int n)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, s, n);
		}

		public static void Samples(System.Random rnd, int[] values, double s, int n)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, s, n);
		}

		public static int Sample(double s, int n)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, s, n);
		}

		public static IEnumerable<int> Samples(double s, int n)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, s, n);
		}

		public static void Samples(int[] values, double s, int n)
		{
			if (n <= 0 || !(s > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, s, n);
		}
	}
}
