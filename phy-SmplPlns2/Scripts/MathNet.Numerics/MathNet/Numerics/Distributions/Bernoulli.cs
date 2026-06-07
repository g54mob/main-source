using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Bernoulli : IDiscreteDistribution, IUnivariateDistribution, IDistribution
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

		public double Mean => _p;

		public double StdDev => Math.Sqrt(_p * (1.0 - _p));

		public double Variance => _p * (1.0 - _p);

		public double Entropy => 0.0 - _p * Math.Log(_p) - (1.0 - _p) * Math.Log(1.0 - _p);

		public double Skewness => (1.0 - 2.0 * _p) / Math.Sqrt(_p * (1.0 - _p));

		public int Minimum => 0;

		public int Maximum => 1;

		public int Mode => (_p > 0.5) ? 1 : 0;

		public int[] Modes
		{
			get
			{
				if (!(_p < 0.5))
				{
					if (P > 0.5)
					{
						return new int[1] { 1 };
					}
					return new int[2] { 0, 1 };
				}
				return new int[1];
			}
		}

		public double Median
		{
			get
			{
				if (!(_p < 0.5))
				{
					if (!(_p > 0.5))
					{
						return 0.5;
					}
					return 1.0;
				}
				return 0.0;
			}
		}

		public Bernoulli(double p)
		{
			if (!IsValidParameterSet(p))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_p = p;
		}

		public Bernoulli(double p, System.Random randomSource)
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
			return $"Bernoulli(p = {_p})";
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
			return k switch
			{
				0 => 1.0 - _p, 
				1 => _p, 
				_ => 0.0, 
			};
		}

		public double ProbabilityLn(int k)
		{
			return k switch
			{
				0 => Math.Log(1.0 - _p), 
				1 => Math.Log(_p), 
				_ => double.NegativeInfinity, 
			};
		}

		public double CumulativeDistribution(double x)
		{
			if (x < 0.0)
			{
				return 0.0;
			}
			if (x >= 1.0)
			{
				return 1.0;
			}
			return 1.0 - _p;
		}

		public static double PMF(double p, int k)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return k switch
			{
				0 => 1.0 - p, 
				1 => p, 
				_ => 0.0, 
			};
		}

		public static double PMFLn(double p, int k)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return k switch
			{
				0 => Math.Log(1.0 - p), 
				1 => Math.Log(p), 
				_ => double.NegativeInfinity, 
			};
		}

		public static double CDF(double p, double x)
		{
			if (!(p >= 0.0) || !(p <= 1.0))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0)
			{
				return 0.0;
			}
			if (x >= 1.0)
			{
				return 1.0;
			}
			return 1.0 - p;
		}

		private static int SampleUnchecked(System.Random rnd, double p)
		{
			if (rnd.NextDouble() < p)
			{
				return 1;
			}
			return 0;
		}

		private static void SamplesUnchecked(System.Random rnd, int[] values, double p)
		{
			double[] uniform = rnd.NextDoubles(values.Length);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = ((uniform[i] < p) ? 1 : 0);
				}
			});
		}

		private static IEnumerable<int> SamplesUnchecked(System.Random rnd, double p)
		{
			return from r in rnd.NextDoubleSequence()
				select (r < p) ? 1 : 0;
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
			while (true)
			{
				yield return SampleUnchecked(_random, _p);
			}
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
