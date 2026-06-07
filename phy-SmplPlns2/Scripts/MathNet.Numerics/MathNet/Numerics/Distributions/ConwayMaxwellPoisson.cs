using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class ConwayMaxwellPoisson : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _lambda;

		private readonly double _nu;

		private double _mean = double.MinValue;

		private double _variance = double.MinValue;

		private double _z = double.MinValue;

		private const double Tolerance = 1E-12;

		public double Lambda => _lambda;

		public double Nu => _nu;

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

		public double Mean
		{
			get
			{
				if (_lambda == 0.0)
				{
					return 0.0;
				}
				if (_mean != double.MinValue)
				{
					return _mean;
				}
				double num = 1.0 + _lambda;
				double num2 = _lambda * _lambda / Math.Pow(2.0, _nu);
				double num3 = _lambda;
				double num4 = 2.0 * num2;
				for (int i = 3; i < 1000; i++)
				{
					double num5 = _lambda / Math.Pow(i, _nu);
					double num6 = _lambda / Math.Pow(i, _nu - 1.0) / (double)(i - 1);
					double num7 = num2 * num5;
					double num8 = num4 * num6;
					if (num8 < num4 && num7 < num2)
					{
						double num9 = num3 / num;
						double num10 = (num3 + num4 / (1.0 - num8 / num4)) / num;
						double num11 = num3 / (num + num2 / (1.0 - num7 / num2));
						if ((num10 - num11) / num9 < 1E-12)
						{
							break;
						}
					}
					num += num2;
					num3 += num4;
					num2 = num7;
					num4 = num8;
				}
				_mean = num3 / num;
				return _mean;
			}
		}

		public double Variance
		{
			get
			{
				if (_lambda == 0.0)
				{
					return 0.0;
				}
				if (_variance != double.MinValue)
				{
					return _variance;
				}
				double num = 1.0 + _lambda;
				double num2 = _lambda * _lambda / Math.Pow(2.0, _nu);
				double num3 = _lambda;
				double num4 = 4.0 * num2;
				for (int i = 3; i < 1000; i++)
				{
					double num5 = _lambda / Math.Pow(i, _nu);
					double num6 = _lambda / Math.Pow(i, _nu - 2.0) / (double)(i - 1) / (double)(i - 1);
					double num7 = num2 * num5;
					double num8 = num4 * num6;
					if (num8 < num4 && num7 < num2)
					{
						double num9 = num3 / num;
						double num10 = (num3 + num4 / (1.0 - num8 / num4)) / num;
						double num11 = num3 / (num + num2 / (1.0 - num7 / num2));
						if ((num10 - num11) / num9 < 1E-12)
						{
							break;
						}
					}
					num += num2;
					num3 += num4;
					num2 = num7;
					num4 = num8;
				}
				double mean = Mean;
				_variance = num3 / num - mean * mean;
				return _variance;
			}
		}

		public double StdDev => Math.Sqrt(Variance);

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
				throw new NotSupportedException();
			}
		}

		public int Mode
		{
			get
			{
				throw new NotSupportedException();
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

		public int Maximum
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		private double Z
		{
			get
			{
				if (_z != double.MinValue)
				{
					return _z;
				}
				_z = Normalization(_lambda, _nu);
				return _z;
			}
		}

		public ConwayMaxwellPoisson(double lambda, double nu)
		{
			if (!IsValidParameterSet(lambda, nu))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_lambda = lambda;
			_nu = nu;
		}

		public ConwayMaxwellPoisson(double lambda, double nu, System.Random randomSource)
		{
			if (!IsValidParameterSet(lambda, nu))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_lambda = lambda;
			_nu = nu;
		}

		public override string ToString()
		{
			return $"ConwayMaxwellPoisson(λ = {_lambda}, ν = {_nu})";
		}

		public static bool IsValidParameterSet(double lambda, double nu)
		{
			if (lambda > 0.0)
			{
				return nu >= 0.0;
			}
			return false;
		}

		public double Probability(int k)
		{
			return Math.Pow(_lambda, k) / Math.Pow(SpecialFunctions.Factorial(k), _nu) / Z;
		}

		public double ProbabilityLn(int k)
		{
			return (double)k * Math.Log(_lambda) - _nu * SpecialFunctions.FactorialLn(k) - Math.Log(Z);
		}

		public double CumulativeDistribution(double x)
		{
			double z = Z;
			double num = 0.0;
			for (int i = 0; (double)i < x + 1.0; i++)
			{
				num += Math.Pow(_lambda, i) / Math.Pow(SpecialFunctions.Factorial(i), _nu) / z;
			}
			return num;
		}

		public static double PMF(double lambda, double nu, int k)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = Normalization(lambda, nu);
			return Math.Pow(lambda, k) / Math.Pow(SpecialFunctions.Factorial(k), nu) / num;
		}

		public static double PMFLn(double lambda, double nu, int k)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double d = Normalization(lambda, nu);
			return (double)k * Math.Log(lambda) - nu * SpecialFunctions.FactorialLn(k) - Math.Log(d);
		}

		public static double CDF(double lambda, double nu, double x)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double num = Normalization(lambda, nu);
			double num2 = 0.0;
			for (int i = 0; (double)i < x + 1.0; i++)
			{
				num2 += Math.Pow(lambda, i) / Math.Pow(SpecialFunctions.Factorial(i), nu) / num;
			}
			return num2;
		}

		private static double Normalization(double lambda, double nu)
		{
			double num = 1.0 + lambda;
			double num2 = lambda;
			for (int i = 2; i < 1000; i++)
			{
				double num3 = lambda / Math.Pow(i, nu);
				num2 *= num3;
				num += num2;
				if (num3 < 1.0 && num2 / (1.0 - num3) / num < 1E-12)
				{
					break;
				}
			}
			return num;
		}

		private static int SampleUnchecked(System.Random rnd, double lambda, double nu, double z)
		{
			double num = rnd.NextDouble();
			double num2 = 1.0 / z;
			double num3 = num2;
			int num4 = 0;
			for (; num > num3; num3 += num2)
			{
				num4++;
				num2 = num2 * lambda / Math.Pow(num4, nu);
			}
			return num4;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double lambda, double nu, double z)
		{
			double[] uniform = rnd.NextDoubles(values.Length);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					double num = uniform[i];
					double num2 = 1.0 / z;
					double num3 = num2;
					int num4 = 0;
					for (; num > num3; num3 += num2)
					{
						num4++;
						num2 = num2 * lambda / Math.Pow(num4, nu);
					}
					values[i] = num4;
				}
			});
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double lambda, double nu, double z)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, lambda, nu, z);
			}
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _lambda, _nu, Z);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _lambda, _nu, Z);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _lambda, _nu, Z);
		}

		public static int Sample(System.Random rnd, double lambda, double nu)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double z = Normalization(lambda, nu);
			return SampleUnchecked(rnd, lambda, nu, z);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double lambda, double nu)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double z = Normalization(lambda, nu);
			return SamplesUnchecked(rnd, lambda, nu, z);
		}

		public static void Samples(System.Random rnd, int[] values, double lambda, double nu)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double z = Normalization(lambda, nu);
			SamplesUnchecked(rnd, values, lambda, nu, z);
		}

		public static int Sample(double lambda, double nu)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double z = Normalization(lambda, nu);
			return SampleUnchecked(SystemRandomSource.Default, lambda, nu, z);
		}

		public static IEnumerable<int> Samples(double lambda, double nu)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double z = Normalization(lambda, nu);
			return SamplesUnchecked(SystemRandomSource.Default, lambda, nu, z);
		}

		public static void Samples(int[] values, double lambda, double nu)
		{
			if (!(lambda > 0.0) || !(nu >= 0.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			double z = Normalization(lambda, nu);
			SamplesUnchecked(SystemRandomSource.Default, values, lambda, nu, z);
		}
	}
}
