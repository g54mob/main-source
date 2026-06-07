using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Geometric : IDiscreteDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _p;

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

		public double Mean => 1.0 / _p;

		public double Variance => (1.0 - _p) / (_p * _p);

		public double StdDev => Math.Sqrt(1.0 - _p) / _p;

		public double Entropy => ((0.0 - _p) * Math.Log(_p, 2.0) - (1.0 - _p) * Math.Log(1.0 - _p, 2.0)) / _p;

		public double Skewness => (2.0 - _p) / Math.Sqrt(1.0 - _p);

		public int Mode => 1;

		public double Median
		{
			get
			{
				if (_p != 0.0)
				{
					if (_p != 1.0)
					{
						return Math.Ceiling(-0.6931471805599453 / Math.Log(1.0 - _p));
					}
					return 1.0;
				}
				return double.PositiveInfinity;
			}
		}

		public int Minimum => 1;

		public int Maximum => int.MaxValue;

		public Geometric(double p)
		{
			if (!IsValidParameterSet(p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_p = p;
		}

		public Geometric(double p, System.Random randomSource)
		{
			if (!IsValidParameterSet(p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_p = p;
		}

		public override string ToString()
		{
			return $"Geometric(p = {_p})";
		}

		public static bool IsValidParameterSet(double p)
		{
			if (p >= 0.0)
			{
				return p <= 1.0;
			}
			return false;
		}

		public double Probability(int k)
		{
			if (k <= 0)
			{
				return 0.0;
			}
			return Math.Pow(1.0 - _p, k - 1) * _p;
		}

		public double ProbabilityLn(int k)
		{
			if (k <= 0)
			{
				return double.NegativeInfinity;
			}
			return (double)(k - 1) * Math.Log(1.0 - _p) + Math.Log(_p);
		}

		public double CumulativeDistribution(double x)
		{
			return 1.0 - Math.Pow(1.0 - _p, x);
		}

		public static double PMF(double p, int k)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k <= 0)
			{
				return 0.0;
			}
			return Math.Pow(1.0 - p, k - 1) * p;
		}

		public static double PMFLn(double p, int k)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (k <= 0)
			{
				return double.NegativeInfinity;
			}
			return (double)(k - 1) * Math.Log(1.0 - p) + Math.Log(p);
		}

		public static double CDF(double p, double x)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return 1.0 - Math.Pow(1.0 - p, x);
		}

		private static int SampleUnchecked(System.Random rnd, double p)
		{
			if (p != 1.0)
			{
				return (int)Math.Ceiling(Math.Log(1.0 - rnd.NextDouble(), 1.0 - p));
			}
			return 1;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double p)
		{
			if (p == 1.0)
			{
				CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						values[i] = 1;
					}
				});
				return;
			}
			double[] uniform = rnd.NextDoubles(values.Length);
			double rp = 1.0 - p;
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = (int)Math.Ceiling(Math.Log(1.0 - uniform[i], rp));
				}
			});
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double p)
		{
			if (p == 1.0)
			{
				return Generate.RepeatSequence(1);
			}
			double rp = 1.0 - p;
			return from r in rnd.NextDoubleSequence()
				select (int)Math.Ceiling(Math.Log(1.0 - r, rp));
		}

		public int Sample()
		{
			return SampleUnchecked(_random, _p);
		}

		public void Samples(int[] values)
		{
			SamplesUnchecked(_random, values, _p);
		}

		public IEnumerable<int> Samples()
		{
			return SamplesUnchecked(_random, _p);
		}

		public static int Sample(System.Random rnd, double p)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, p);
		}

		public static IEnumerable<int> Samples(System.Random rnd, double p)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, p);
		}

		public static void Samples(System.Random rnd, int[] values, double p)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, p);
		}

		public static int Sample(double p)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, p);
		}

		public static IEnumerable<int> Samples(double p)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, p);
		}

		public static void Samples(int[] values, double p)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, p);
		}
	}
}
