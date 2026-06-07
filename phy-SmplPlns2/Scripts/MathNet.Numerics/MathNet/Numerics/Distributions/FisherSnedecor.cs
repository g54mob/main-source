using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.RootFinding;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class FisherSnedecor : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _freedom1;

		private readonly double _freedom2;

		public double DegreesOfFreedom1 => _freedom1;

		public double DegreesOfFreedom2 => _freedom2;

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
				if (_freedom2 <= 2.0)
				{
					throw new NotSupportedException();
				}
				return _freedom2 / (_freedom2 - 2.0);
			}
		}

		public double Variance
		{
			get
			{
				if (_freedom2 <= 4.0)
				{
					throw new NotSupportedException();
				}
				return 2.0 * _freedom2 * _freedom2 * (_freedom1 + _freedom2 - 2.0) / (_freedom1 * (_freedom2 - 2.0) * (_freedom2 - 2.0) * (_freedom2 - 4.0));
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
				if (_freedom2 <= 6.0)
				{
					throw new NotSupportedException();
				}
				return (2.0 * _freedom1 + _freedom2 - 2.0) * Math.Sqrt(8.0 * (_freedom2 - 4.0)) / ((_freedom2 - 6.0) * Math.Sqrt(_freedom1 * (_freedom1 + _freedom2 - 2.0)));
			}
		}

		public double Mode
		{
			get
			{
				if (_freedom1 <= 2.0)
				{
					throw new NotSupportedException();
				}
				return _freedom2 * (_freedom1 - 2.0) / (_freedom1 * (_freedom2 + 2.0));
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

		public FisherSnedecor(double d1, double d2)
		{
			if (!IsValidParameterSet(d1, d2))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_freedom1 = d1;
			_freedom2 = d2;
		}

		public FisherSnedecor(double d1, double d2, System.Random randomSource)
		{
			if (!IsValidParameterSet(d1, d2))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_freedom1 = d1;
			_freedom2 = d2;
		}

		public override string ToString()
		{
			return $"FisherSnedecor(d1 = {_freedom1}, d2 = {_freedom2})";
		}

		public static bool IsValidParameterSet(double d1, double d2)
		{
			if (d1 > 0.0)
			{
				return d2 > 0.0;
			}
			return false;
		}

		public double Density(double x)
		{
			return Math.Sqrt(Math.Pow(_freedom1 * x, _freedom1) * Math.Pow(_freedom2, _freedom2) / Math.Pow(_freedom1 * x + _freedom2, _freedom1 + _freedom2)) / (x * SpecialFunctions.Beta(_freedom1 / 2.0, _freedom2 / 2.0));
		}

		public double DensityLn(double x)
		{
			return Math.Log(Density(x));
		}

		public double CumulativeDistribution(double x)
		{
			return SpecialFunctions.BetaRegularized(_freedom1 / 2.0, _freedom2 / 2.0, _freedom1 * x / (_freedom1 * x + _freedom2));
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_freedom1, _freedom2, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _freedom1, _freedom2);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _freedom1, _freedom2);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _freedom1, _freedom2);
		}

		private static double SampleUnchecked(System.Random rnd, double d1, double d2)
		{
			return ChiSquared.Sample(rnd, d1) * d2 / (ChiSquared.Sample(rnd, d2) * d1);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double d1, double d2)
		{
			double[] values2 = new double[values.Length];
			ChiSquared.SamplesUnchecked(rnd, values, d1);
			ChiSquared.SamplesUnchecked(rnd, values2, d2);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = values[i] * d2 / (values2[i] * d1);
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double d1, double d2)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, d1, d2);
			}
		}

		public static double PDF(double d1, double d2, double x)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Math.Sqrt(Math.Pow(d1 * x, d1) * Math.Pow(d2, d2) / Math.Pow(d1 * x + d2, d1 + d2)) / (x * SpecialFunctions.Beta(d1 / 2.0, d2 / 2.0));
		}

		public static double PDFLn(double d1, double d2, double x)
		{
			return Math.Log(PDF(d1, d2, x));
		}

		public static double CDF(double d1, double d2, double x)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.BetaRegularized(d1 / 2.0, d2 / 2.0, d1 * x / (d1 * x + d2));
		}

		public static double InvCDF(double d1, double d2, double p)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Brent.FindRoot((double x) => SpecialFunctions.BetaRegularized(d1 / 2.0, d2 / 2.0, d1 * x / (d1 * x + d2)) - p, 0.0, 1000.0, 1E-12);
		}

		public static double Sample(System.Random rnd, double d1, double d2)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, d1, d2);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double d1, double d2)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, d1, d2);
		}

		public static void Samples(System.Random rnd, double[] values, double d1, double d2)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, d1, d2);
		}

		public static double Sample(double d1, double d2)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, d1, d2);
		}

		public static IEnumerable<double> Samples(double d1, double d2)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, d1, d2);
		}

		public static void Samples(double[] values, double d1, double d2)
		{
			if (d1 <= 0.0 || d2 <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, d1, d2);
		}
	}
}
