using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Chi : IContinuousDistribution, IUnivariateDistribution, IDistribution
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

		public double Mean => 1.4142135623730951 * (SpecialFunctions.Gamma((_freedom + 1.0) / 2.0) / SpecialFunctions.Gamma(_freedom / 2.0));

		public double Variance => _freedom - Mean * Mean;

		public double StdDev => Math.Sqrt(Variance);

		public double Entropy => SpecialFunctions.GammaLn(_freedom / 2.0) + (_freedom - Math.Log(2.0) - (_freedom - 1.0) * SpecialFunctions.DiGamma(_freedom / 2.0)) / 2.0;

		public double Skewness
		{
			get
			{
				double stdDev = StdDev;
				return Mean * (1.0 - 2.0 * (stdDev * stdDev)) / (stdDev * stdDev * stdDev);
			}
		}

		public double Mode
		{
			get
			{
				if (_freedom < 1.0)
				{
					throw new NotSupportedException();
				}
				return Math.Sqrt(_freedom - 1.0);
			}
		}

		public double Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public Chi(double freedom)
		{
			if (!IsValidParameterSet(freedom))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_freedom = freedom;
		}

		public Chi(double freedom, System.Random randomSource)
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
			return $"Chi(k = {_freedom})";
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

		public double Sample()
		{
			return SampleUnchecked(_random, (int)_freedom);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, (int)_freedom);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, (int)_freedom);
		}

		private static double SampleUnchecked(System.Random rnd, int freedom)
		{
			double num = 0.0;
			for (int i = 0; i < freedom; i++)
			{
				num += Math.Pow(Normal.Sample(rnd, 0.0, 1.0), 2.0);
			}
			return Math.Sqrt(num);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, int freedom)
		{
			double[] standard = new double[values.Length * freedom];
			Normal.SamplesUnchecked(rnd, standard, 0.0, 1.0);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					int num = i * freedom;
					double num2 = 0.0;
					for (int j = 0; j < freedom; j++)
					{
						num2 += standard[num + j] * standard[num + j];
					}
					values[i] = Math.Sqrt(num2);
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, int freedom)
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
			return Math.Pow(2.0, 1.0 - freedom / 2.0) * Math.Pow(x, freedom - 1.0) * Math.Exp((0.0 - x) * x / 2.0) / SpecialFunctions.Gamma(freedom / 2.0);
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
			return (1.0 - freedom / 2.0) * Math.Log(2.0) + (freedom - 1.0) * Math.Log(x) - x * x / 2.0 - SpecialFunctions.GammaLn(freedom / 2.0);
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
			return SpecialFunctions.GammaLowerRegularized(freedom / 2.0, x * x / 2.0);
		}

		public static double Sample(System.Random rnd, int freedom)
		{
			if (freedom <= 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, freedom);
		}

		public static IEnumerable<double> Samples(System.Random rnd, int freedom)
		{
			if (freedom <= 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, freedom);
		}

		public static void Samples(System.Random rnd, double[] values, int freedom)
		{
			if (freedom <= 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, freedom);
		}

		public static double Sample(int freedom)
		{
			if (freedom <= 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, freedom);
		}

		public static IEnumerable<double> Samples(int freedom)
		{
			if (freedom <= 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, freedom);
		}

		public static void Samples(double[] values, int freedom)
		{
			if (freedom <= 0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, freedom);
		}
	}
}
