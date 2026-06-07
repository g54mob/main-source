using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class ChiSquared : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _freedom;

		public double DegreesOfFreedom => _freedom;

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

		public double Mean => _freedom;

		public double Variance => 2.0 * _freedom;

		public double StdDev => Math.Sqrt(2.0 * _freedom);

		public double Entropy => _freedom / 2.0 + Math.Log(2.0 * SpecialFunctions.Gamma(_freedom / 2.0)) + (1.0 - _freedom / 2.0) * SpecialFunctions.DiGamma(_freedom / 2.0);

		public double Skewness => Math.Sqrt(8.0 / _freedom);

		public double Mode => _freedom - 2.0;

		public double Median => _freedom - 2.0 / 3.0;

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public ChiSquared(double freedom)
		{
			if (!IsValidParameterSet(freedom))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_freedom = freedom;
		}

		public ChiSquared(double freedom, System.Random randomSource)
		{
			if (!IsValidParameterSet(freedom))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_freedom = freedom;
		}

		public override string ToString()
		{
			return $"ChiSquared(k = {_freedom})";
		}

		public static bool IsValidParameterSet(double freedom)
		{
			return freedom > 0.0;
		}

		public double Density(double x)
		{
			return PDF(_freedom, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_freedom, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_freedom, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_freedom, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _freedom);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _freedom);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _freedom);
		}

		private static double SampleUnchecked(System.Random rnd, double freedom)
		{
			if (Math.Floor(freedom) == freedom && freedom < 2147483647.0)
			{
				double num = 0.0;
				int num2 = (int)freedom;
				for (int i = 0; i < num2; i++)
				{
					num += Math.Pow(Normal.Sample(rnd, 0.0, 1.0), 2.0);
				}
				return num;
			}
			return Gamma.SampleUnchecked(rnd, freedom / 2.0, 0.5);
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double freedom)
		{
			if (Math.Floor(freedom) == freedom && freedom < 2147483647.0)
			{
				int n = (int)freedom;
				double[] standard = new double[values.Length * n];
				Normal.SamplesUnchecked(rnd, standard, 0.0, 1.0);
				CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						int num = i * n;
						double num2 = 0.0;
						for (int j = 0; j < n; j++)
						{
							num2 += standard[num + j] * standard[num + j];
						}
						values[i] = num2;
					}
				});
			}
			else
			{
				Gamma.SamplesUnchecked(rnd, values, freedom / 2.0, 0.5);
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double freedom)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, freedom);
			}
		}

		public static double PDF(double freedom, double x)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(freedom) || double.IsPositiveInfinity(x) || x == 0.0)
			{
				return 0.0;
			}
			if (freedom > 160.0)
			{
				return Math.Exp(PDFLn(freedom, x));
			}
			return Math.Pow(x, freedom / 2.0 - 1.0) * Math.Exp((0.0 - x) / 2.0) / (Math.Pow(2.0, freedom / 2.0) * SpecialFunctions.Gamma(freedom / 2.0));
		}

		public static double PDFLn(double freedom, double x)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(freedom) || double.IsPositiveInfinity(x) || x == 0.0)
			{
				return double.NegativeInfinity;
			}
			return (0.0 - x) / 2.0 + (freedom / 2.0 - 1.0) * Math.Log(x) - freedom / 2.0 * Math.Log(2.0) - SpecialFunctions.GammaLn(freedom / 2.0);
		}

		public static double CDF(double freedom, double x)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(x))
			{
				return 1.0;
			}
			if (double.IsPositiveInfinity(freedom))
			{
				return 1.0;
			}
			return SpecialFunctions.GammaLowerRegularized(freedom / 2.0, x / 2.0);
		}

		public static double InvCDF(double freedom, double p)
		{
			if (!IsValidParameterSet(freedom))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.GammaLowerRegularizedInv(freedom / 2.0, p) / 0.5;
		}

		public static double Sample(System.Random rnd, double freedom)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, freedom);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double freedom)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, freedom);
		}

		public static void Samples(System.Random rnd, double[] values, double freedom)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, freedom);
		}

		public static double Sample(double freedom)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, freedom);
		}

		public static IEnumerable<double> Samples(double freedom)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, freedom);
		}

		public static void Samples(double[] values, double freedom)
		{
			if (freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, freedom);
		}
	}
}
