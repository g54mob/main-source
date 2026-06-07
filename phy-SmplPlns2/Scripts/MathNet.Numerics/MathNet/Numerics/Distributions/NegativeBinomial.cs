using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class NegativeBinomial : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _r;

		private readonly double _p;

		public double R => _r;

		public double P => _p;

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

		public double Mean => _r * (1.0 - _p) / _p;

		public double Variance => _r * (1.0 - _p) / (_p * _p);

		public double StdDev => Math.Sqrt(_r * (1.0 - _p)) / _p;

		public double Entropy
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Skewness => (2.0 - _p) / Math.Sqrt(_r * (1.0 - _p));

		public int Mode
		{
			get
			{
				if (!(_r > 1.0))
				{
					return 0;
				}
				return (int)Math.Floor((_r - 1.0) * (1.0 - _p) / _p);
			}
		}

		public double Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public int Minimum => 0;

		public int Maximum => int.MaxValue;

		public NegativeBinomial(double r, double p)
		{
			if (!IsValidParameterSet(r, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_p = p;
			_r = r;
		}

		public NegativeBinomial(double r, double p, System.Random randomSource)
		{
			if (!IsValidParameterSet(r, p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_p = p;
			_r = r;
		}

		public override string ToString()
		{
			return $"NegativeBinomial(R = {_r}, P = {_p})";
		}

		public static bool IsValidParameterSet(double r, double p)
		{
			if (r >= 0.0 && p >= 0.0)
			{
				return p <= 1.0;
			}
			return false;
		}

		public double Probability(int k)
		{
			return PMF(_r, _p, k);
		}

		public double ProbabilityLn(int k)
		{
			return PMFLn(_r, _p, k);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_r, _p, x);
		}

		public static double PMF(double r, double p, int k)
		{
			return Math.Exp(PMFLn(r, p, k));
		}

		public static double PMFLn(double r, double p, int k)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.GammaLn(r + (double)k) - SpecialFunctions.GammaLn(r) - SpecialFunctions.GammaLn((double)k + 1.0) + r * Math.Log(p) + (double)k * Math.Log(1.0 - p);
		}

		public static double CDF(double r, double p, double x)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 1.0 - SpecialFunctions.BetaRegularized(x + 1.0, r, 1.0 - p);
		}

		private static int SampleUnchecked(System.Random rnd, double r, double p)
		{
			double num = Math.Exp(0.0 - Gamma.SampleUnchecked(rnd, r, p));
			double num2 = 1.0;
			int num3 = 0;
			do
			{
				num3++;
				num2 *= rnd.NextDouble();
			}
			while (num2 >= num);
			return num3 - 1;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double r, double p)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, r, p);
			}
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double r, double p)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, r, p);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _r, _p);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _r, _p);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _r, _p);
		}

		public static int Sample(System.Random rnd, double r, double p)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, r, p);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double r, double p)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, r, p);
		}

		public static void Samples(System.Random rnd, int[] values, double r, double p)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, r, p);
		}

		public static int Sample(double r, double p)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, r, p);
		}

		public static IEnumerable<int> Samples(double r, double p)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, r, p);
		}

		public static void Samples(int[] values, double r, double p)
		{
			if (!(r >= 0.0) || !(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, r, p);
		}
	}
}
