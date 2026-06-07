using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Poisson : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _lambda;

		public double Lambda => _lambda;

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

		public double Mean => _lambda;

		public double Variance => _lambda;

		public double StdDev => Math.Sqrt(_lambda);

		public double Entropy => 0.5 * Math.Log(17.079468445347132 * _lambda) - 1.0 / (12.0 * _lambda) - 1.0 / (24.0 * _lambda * _lambda) - 19.0 / (360.0 * _lambda * _lambda * _lambda);

		public double Skewness => 1.0 / Math.Sqrt(_lambda);

		public int Minimum => 0;

		public int Maximum => int.MaxValue;

		public int Mode => (int)Math.Floor(_lambda);

		public double Median => Math.Floor(_lambda + 1.0 / 3.0 - 0.02 / _lambda);

		public Poisson(double lambda)
		{
			if (!IsValidParameterSet(lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_lambda = lambda;
		}

		public Poisson(double lambda, System.Random randomSource)
		{
			if (!IsValidParameterSet(lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_lambda = lambda;
		}

		public override string ToString()
		{
			return $"Poisson(λ = {_lambda})";
		}

		public static bool IsValidParameterSet(double lambda)
		{
			return lambda > 0.0;
		}

		public double Probability(int k)
		{
			return Math.Exp(0.0 - _lambda + (double)k * Math.Log(_lambda) - SpecialFunctions.FactorialLn(k));
		}

		public double ProbabilityLn(int k)
		{
			return 0.0 - _lambda + (double)k * Math.Log(_lambda) - SpecialFunctions.FactorialLn(k);
		}

		public double CumulativeDistribution(double x)
		{
			return 1.0 - SpecialFunctions.GammaLowerRegularized(x + 1.0, _lambda);
		}

		public static double PMF(double lambda, int k)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Exp(0.0 - lambda + (double)k * Math.Log(lambda) - SpecialFunctions.FactorialLn(k));
		}

		public static double PMFLn(double lambda, int k)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 0.0 - lambda + (double)k * Math.Log(lambda) - SpecialFunctions.FactorialLn(k);
		}

		public static double CDF(double lambda, double x)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 1.0 - SpecialFunctions.GammaLowerRegularized(x + 1.0, lambda);
		}

		private static int SampleUnchecked(System.Random rnd, double lambda)
		{
			if (!(lambda < 30.0))
			{
				return DoSampleLarge(rnd, lambda);
			}
			return DoSampleShort(rnd, lambda);
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double lambda)
		{
			if (lambda < 30.0)
			{
				double num = Math.Exp(0.0 - lambda);
				for (int i = 0; i < values.Length; i++)
				{
					int num2 = 0;
					for (double num3 = rnd.NextDouble(); num3 >= num; num3 *= rnd.NextDouble())
					{
						num2++;
					}
					values[i] = num2;
				}
				return;
			}
			double d = 0.767 - 3.36 / lambda;
			double num4 = Math.PI / Math.Sqrt(3.0 * lambda);
			double num5 = num4 * lambda;
			double num6 = Math.Log(d) - lambda - Math.Log(num4);
			for (int j = 0; j < values.Length; j++)
			{
				int num9;
				while (true)
				{
					double num7 = rnd.NextDouble();
					double num8 = (num5 - Math.Log((1.0 - num7) / num7)) / num4;
					num9 = (int)Math.Floor(num8 + 0.5);
					if (num9 >= 0)
					{
						double num10 = rnd.NextDouble();
						double num11 = num5 - num4 * num8;
						double num12 = 1.0 + Math.Exp(num11);
						double num13 = num11 + Math.Log(num10 / (num12 * num12));
						double num14 = num6 + (double)num9 * Math.Log(lambda) - SpecialFunctions.FactorialLn(num9);
						if (num13 <= num14)
						{
							break;
						}
					}
				}
				values[j] = num9;
			}
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double lambda)
		{
			if (lambda < 30.0)
			{
				while (true)
				{
					yield return DoSampleShort(rnd, lambda);
				}
			}
			while (true)
			{
				yield return DoSampleLarge(rnd, lambda);
			}
		}

		private static int DoSampleShort(System.Random rnd, double lambda)
		{
			double num = Math.Exp(0.0 - lambda);
			int num2 = 0;
			for (double num3 = rnd.NextDouble(); num3 >= num; num3 *= rnd.NextDouble())
			{
				num2++;
			}
			return num2;
		}

		private static int DoSampleLarge(System.Random rnd, double lambda)
		{
			double d = 0.767 - 3.36 / lambda;
			double num = Math.PI / Math.Sqrt(3.0 * lambda);
			double num2 = num * lambda;
			double num3 = Math.Log(d) - lambda - Math.Log(num);
			int num6;
			while (true)
			{
				double num4 = rnd.NextDouble();
				double num5 = (num2 - Math.Log((1.0 - num4) / num4)) / num;
				num6 = (int)Math.Floor(num5 + 0.5);
				if (num6 >= 0)
				{
					double num7 = rnd.NextDouble();
					double num8 = num2 - num * num5;
					double num9 = 1.0 + Math.Exp(num8);
					double num10 = num8 + Math.Log(num7 / (num9 * num9));
					double num11 = num3 + (double)num6 * Math.Log(lambda) - SpecialFunctions.FactorialLn(num6);
					if (num10 <= num11)
					{
						break;
					}
				}
			}
			return num6;
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _lambda);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _lambda);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _lambda);
		}

		public static int Sample(System.Random rnd, double lambda)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, lambda);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double lambda)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, lambda);
		}

		public static void Samples(System.Random rnd, int[] values, double lambda)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, lambda);
		}

		public static int Sample(double lambda)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, lambda);
		}

		public static IEnumerable<int> Samples(double lambda)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, lambda);
		}

		public static void Samples(int[] values, double lambda)
		{
			if (!(lambda > 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, lambda);
		}
	}
}
