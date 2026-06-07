using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class DiscreteUniform : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly int _lower;

		private readonly int _upper;

		public int LowerBound => _lower;

		public int UpperBound => _upper;

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

		public double Mean => (double)(_lower + _upper) / 2.0;

		public double StdDev => Math.Sqrt((((double)(_upper - _lower) + 1.0) * ((double)(_upper - _lower) + 1.0) - 1.0) / 12.0);

		public double Variance => (((double)(_upper - _lower) + 1.0) * ((double)(_upper - _lower) + 1.0) - 1.0) / 12.0;

		public double Entropy => Math.Log((double)(_upper - _lower) + 1.0);

		public double Skewness => 0.0;

		public int Minimum => _lower;

		public int Maximum => _upper;

		public int Mode => (int)Math.Floor((double)(_lower + _upper) / 2.0);

		public double Median => (double)(_lower + _upper) / 2.0;

		public DiscreteUniform(int lower, int upper)
		{
			if (!IsValidParameterSet(lower, upper))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_lower = lower;
			_upper = upper;
		}

		public DiscreteUniform(int lower, int upper, System.Random randomSource)
		{
			if (!IsValidParameterSet(lower, upper))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_lower = lower;
			_upper = upper;
		}

		public override string ToString()
		{
			return $"DiscreteUniform(Lower = {_lower}, Upper = {_upper})";
		}

		public static bool IsValidParameterSet(int lower, int upper)
		{
			return lower <= upper;
		}

		public double Probability(int k)
		{
			return PMF(_lower, _upper, k);
		}

		public double ProbabilityLn(int k)
		{
			return PMFLn(_lower, _upper, k);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_lower, _upper, x);
		}

		public static double PMF(int lower, int upper, int k)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k < lower || k > upper)
			{
				return 0.0;
			}
			return 1.0 / (double)(upper - lower + 1);
		}

		public static double PMFLn(int lower, int upper, int k)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k < lower || k > upper)
			{
				return double.NegativeInfinity;
			}
			return 0.0 - Math.Log(upper - lower + 1);
		}

		public static double CDF(int lower, int upper, double x)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < (double)lower)
			{
				return 0.0;
			}
			if (x >= (double)upper)
			{
				return 1.0;
			}
			return Math.Min(1.0, (Math.Floor(x) - (double)lower + 1.0) / (double)(upper - lower + 1));
		}

		private static int SampleUnchecked(System.Random rnd, int lower, int upper)
		{
			return rnd.Next(lower, upper + 1);
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, int lower, int upper)
		{
			rnd.NextInt32s(values, lower, upper + 1);
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, int lower, int upper)
		{
			return rnd.NextInt32Sequence(lower, upper + 1);
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _lower, _upper);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _lower, _upper);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _lower, _upper);
		}

		public static int Sample(System.Random rnd, int lower, int upper)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, lower, upper);
		}

		public static IEnumerable<int> Samples(System.Random rnd, int lower, int upper)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, lower, upper);
		}

		public static void Samples(System.Random rnd, int[] values, int lower, int upper)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, lower, upper);
		}

		public static int Sample(int lower, int upper)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, lower, upper);
		}

		public static IEnumerable<int> Samples(int lower, int upper)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, lower, upper);
		}

		public static void Samples(int[] values, int lower, int upper)
		{
			if (lower > upper)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, lower, upper);
		}
	}
}
