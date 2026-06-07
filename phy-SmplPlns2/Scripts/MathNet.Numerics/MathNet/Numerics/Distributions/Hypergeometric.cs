using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Hypergeometric : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly int _population;

		private readonly int _success;

		private readonly int _draws;

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

		public int Population => _population;

		public int Draws => _draws;

		public int Success => _success;

		public double Mean => (double)_success * (double)_draws / (double)_population;

		public double Variance => (double)(_draws * _success * (_population - _draws) * (_population - _success)) / ((double)(_population * _population) * ((double)_population - 1.0));

		public double StdDev => Math.Sqrt(Variance);

		public double Entropy
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Skewness => Math.Sqrt((double)_population - 1.0) * (double)(_population - 2 * _draws) * (double)(_population - 2 * _success) / (Math.Sqrt(_draws * _success * (_population - _success) * (_population - _draws)) * ((double)_population - 2.0));

		public int Mode => (_draws + 1) * (_success + 1) / (_population + 2);

		public double Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public int Minimum => Math.Max(0, _draws + _success - _population);

		public int Maximum => Math.Min(_success, _draws);

		public Hypergeometric(int population, int success, int draws)
		{
			if (!IsValidParameterSet(population, success, draws))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_population = population;
			_success = success;
			_draws = draws;
		}

		public Hypergeometric(int population, int success, int draws, System.Random randomSource)
		{
			if (!IsValidParameterSet(population, success, draws))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_population = population;
			_success = success;
			_draws = draws;
		}

		public override string ToString()
		{
			return $"Hypergeometric(N = {_population}, M = {_success}, n = {_draws})";
		}

		public static bool IsValidParameterSet(int population, int success, int draws)
		{
			if (population >= 0 && success >= 0 && draws >= 0 && success <= population)
			{
				return draws <= population;
			}
			return false;
		}

		public double Probability(int k)
		{
			return SpecialFunctions.Binomial(_success, k) * SpecialFunctions.Binomial(_population - _success, _draws - k) / SpecialFunctions.Binomial(_population, _draws);
		}

		public double ProbabilityLn(int k)
		{
			return SpecialFunctions.BinomialLn(_success, k) + SpecialFunctions.BinomialLn(_population - _success, _draws - k) - SpecialFunctions.BinomialLn(_population, _draws);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_population, _success, _draws, x);
		}

		public static double PMF(int population, int success, int draws, int k)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.Binomial(success, k) * SpecialFunctions.Binomial(population - success, draws - k) / SpecialFunctions.Binomial(population, draws);
		}

		public static double PMFLn(int population, int success, int draws, int k)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.BinomialLn(success, k) + SpecialFunctions.BinomialLn(population - success, draws - k) - SpecialFunctions.BinomialLn(population, draws);
		}

		public static double CDF(int population, int success, int draws, double x)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < (double)Math.Max(0, draws + success - population))
			{
				return 0.0;
			}
			if (x >= (double)Math.Min(success, draws))
			{
				return 1.0;
			}
			int num = (int)Math.Floor(x);
			double num2 = SpecialFunctions.BinomialLn(population, draws);
			double num3 = 0.0;
			for (int i = 0; i <= num; i++)
			{
				num3 += Math.Exp(SpecialFunctions.BinomialLn(success, i) + SpecialFunctions.BinomialLn(population - success, draws - i) - num2);
			}
			return Math.Min(num3, 1.0);
		}

		private static int SampleUnchecked(System.Random rnd, int population, int success, int draws)
		{
			int num = 0;
			do
			{
				double num2 = (double)success / (double)population;
				if (rnd.NextDouble() < num2)
				{
					num++;
					success--;
				}
				population--;
				draws--;
			}
			while (0 < draws);
			return num;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, int population, int success, int draws)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, population, success, draws);
			}
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, int population, int success, int draws)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, population, success, draws);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _population, _success, _draws);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _population, _success, _draws);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _population, _success, _draws);
		}

		public static int Sample(System.Random rnd, int population, int success, int draws)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, population, success, draws);
		}

		public static IEnumerable<int> Samples(System.Random rnd, int population, int success, int draws)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, population, success, draws);
		}

		public static void Samples(System.Random rnd, int[] values, int population, int success, int draws)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, population, success, draws);
		}

		public static int Sample(int population, int success, int draws)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, population, success, draws);
		}

		public static IEnumerable<int> Samples(int population, int success, int draws)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, population, success, draws);
		}

		public static void Samples(int[] values, int population, int success, int draws)
		{
			if (population < 0 || success < 0 || draws < 0 || success > population || draws > population)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, population, success, draws);
		}
	}
}
