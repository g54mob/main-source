using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.RootFinding;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Beta : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _shapeA;

		private readonly double _shapeB;

		public double A => _shapeA;

		public double B => _shapeB;

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
				if (_shapeA == 0.0 && _shapeB == 0.0)
				{
					return 0.5;
				}
				if (_shapeA == 0.0)
				{
					return 0.0;
				}
				if (_shapeB == 0.0)
				{
					return 1.0;
				}
				if (double.IsPositiveInfinity(_shapeA) && double.IsPositiveInfinity(_shapeB))
				{
					return 0.5;
				}
				if (double.IsPositiveInfinity(_shapeA))
				{
					return 1.0;
				}
				if (double.IsPositiveInfinity(_shapeB))
				{
					return 0.0;
				}
				return _shapeA / (_shapeA + _shapeB);
			}
		}

		public double Variance => _shapeA * _shapeB / ((_shapeA + _shapeB) * (_shapeA + _shapeB) * (_shapeA + _shapeB + 1.0));

		public double StdDev => Math.Sqrt(_shapeA * _shapeB / ((_shapeA + _shapeB) * (_shapeA + _shapeB) * (_shapeA + _shapeB + 1.0)));

		public double Entropy
		{
			get
			{
				if (double.IsPositiveInfinity(_shapeA) || double.IsPositiveInfinity(_shapeB))
				{
					return 0.0;
				}
				if (_shapeA == 0.0 && _shapeB == 0.0)
				{
					return 0.0 - Math.Log(0.5);
				}
				if (_shapeA == 0.0 || _shapeB == 0.0)
				{
					return 0.0;
				}
				return SpecialFunctions.BetaLn(_shapeA, _shapeB) - (_shapeA - 1.0) * SpecialFunctions.DiGamma(_shapeA) - (_shapeB - 1.0) * SpecialFunctions.DiGamma(_shapeB) + (_shapeA + _shapeB - 2.0) * SpecialFunctions.DiGamma(_shapeA + _shapeB);
			}
		}

		public double Skewness
		{
			get
			{
				if (double.IsPositiveInfinity(_shapeA) && double.IsPositiveInfinity(_shapeB))
				{
					return 0.0;
				}
				if (double.IsPositiveInfinity(_shapeA))
				{
					return -2.0;
				}
				if (double.IsPositiveInfinity(_shapeB))
				{
					return 2.0;
				}
				if (_shapeA == 0.0 && _shapeB == 0.0)
				{
					return 0.0;
				}
				if (_shapeA == 0.0)
				{
					return 2.0;
				}
				if (_shapeB == 0.0)
				{
					return -2.0;
				}
				return 2.0 * (_shapeB - _shapeA) * Math.Sqrt(_shapeA + _shapeB + 1.0) / ((_shapeA + _shapeB + 2.0) * Math.Sqrt(_shapeA * _shapeB));
			}
		}

		public double Mode
		{
			get
			{
				if (_shapeA == 0.0 && _shapeB == 0.0)
				{
					return 0.5;
				}
				if (_shapeA == 0.0)
				{
					return 0.0;
				}
				if (_shapeB == 0.0)
				{
					return 1.0;
				}
				if (double.IsPositiveInfinity(_shapeA) && double.IsPositiveInfinity(_shapeB))
				{
					return 0.5;
				}
				if (double.IsPositiveInfinity(_shapeA))
				{
					return 1.0;
				}
				if (double.IsPositiveInfinity(_shapeB))
				{
					return 0.0;
				}
				if (_shapeA == 1.0 && _shapeB == 1.0)
				{
					return 0.5;
				}
				return (_shapeA - 1.0) / (_shapeA + _shapeB - 2.0);
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

		public double Maximum => 1.0;

		public Beta(double a, double b)
		{
			if (!IsValidParameterSet(a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_shapeA = a;
			_shapeB = b;
		}

		public Beta(double a, double b, System.Random randomSource)
		{
			if (!IsValidParameterSet(a, b))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_shapeA = a;
			_shapeB = b;
		}

		public override string ToString()
		{
			return $"Beta(α = {_shapeA}, β = {_shapeB})";
		}

		public static bool IsValidParameterSet(double a, double b)
		{
			if (a >= 0.0)
			{
				return b >= 0.0;
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_shapeA, _shapeB, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_shapeA, _shapeB, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_shapeA, _shapeB, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_shapeA, _shapeB, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _shapeA, _shapeB);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _shapeA, _shapeB);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _shapeA, _shapeB);
		}

		internal static double SampleUnchecked(System.Random rnd, double a, double b)
		{
			double num;
			double num2;
			if (a == b)
			{
				num = Gamma.SampleUnchecked(rnd, a, 1.0);
				num2 = Gamma.SampleUnchecked(rnd, b, 1.0);
				if (num == 0.0 && num2 == 0.0)
				{
					return Bernoulli.Sample(0.5);
				}
			}
			else
			{
				do
				{
					num = Gamma.SampleUnchecked(rnd, a, 1.0);
					num2 = Gamma.SampleUnchecked(rnd, b, 1.0);
				}
				while (num == 0.0 && num2 == 0.0);
			}
			return num / (num + num2);
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double a, double b)
		{
			double[] y = new double[values.Length];
			Gamma.SamplesUnchecked(rnd, values, a, 1.0);
			Gamma.SamplesUnchecked(rnd, y, b, 1.0);
			CommonParallel.For(0, values.Length, 4096, delegate(int aa, int bb)
			{
				for (int i = aa; i < bb; i++)
				{
					values[i] /= values[i] + y[i];
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double a, double b)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, a, b);
			}
		}

		public static double PDF(double a, double b, double x)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0 || x > 1.0)
			{
				return 0.0;
			}
			if (double.IsPositiveInfinity(a) && double.IsPositiveInfinity(b))
			{
				if (x != 0.5)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if (double.IsPositiveInfinity(a))
			{
				if (x != 1.0)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if (double.IsPositiveInfinity(b))
			{
				if (x != 0.0)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if (a == 0.0 && b == 0.0)
			{
				if (x == 0.0 || x == 1.0)
				{
					return double.PositiveInfinity;
				}
				return 0.0;
			}
			if (a == 0.0)
			{
				if (x != 0.0)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if (b == 0.0)
			{
				if (x != 1.0)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if (a == 1.0 && b == 1.0)
			{
				return 1.0;
			}
			if (a > 80.0 || b > 80.0)
			{
				return Math.Exp(PDFLn(a, b, x));
			}
			return SpecialFunctions.Gamma(a + b) / (SpecialFunctions.Gamma(a) * SpecialFunctions.Gamma(b)) * Math.Pow(x, a - 1.0) * Math.Pow(1.0 - x, b - 1.0);
		}

		public static double PDFLn(double a, double b, double x)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0 || x > 1.0)
			{
				return double.NegativeInfinity;
			}
			if (double.IsPositiveInfinity(a) && double.IsPositiveInfinity(b))
			{
				if (x != 0.5)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (double.IsPositiveInfinity(a))
			{
				if (x != 1.0)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (double.IsPositiveInfinity(b))
			{
				if (x != 0.0)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (a == 0.0 && b == 0.0)
			{
				if (x != 0.0 && x != 1.0)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (a == 0.0)
			{
				if (x != 0.0)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (b == 0.0)
			{
				if (x != 1.0)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (a == 1.0 && b == 1.0)
			{
				return 0.0;
			}
			double num = SpecialFunctions.GammaLn(a + b) - SpecialFunctions.GammaLn(a) - SpecialFunctions.GammaLn(b);
			double num2 = ((x != 0.0) ? ((a - 1.0) * Math.Log(x)) : ((a == 1.0) ? 0.0 : double.NegativeInfinity));
			double num3 = ((x != 1.0) ? ((b - 1.0) * Math.Log(1.0 - x)) : ((b == 1.0) ? 0.0 : double.NegativeInfinity));
			return num + num2 + num3;
		}

		public static double CDF(double a, double b, double x)
		{
			if (a < 0.0 || b < 0.0)
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
			if (double.IsPositiveInfinity(a) && double.IsPositiveInfinity(b))
			{
				if (!(x < 0.5))
				{
					return 1.0;
				}
				return 0.0;
			}
			if (double.IsPositiveInfinity(a))
			{
				if (!(x < 1.0))
				{
					return 1.0;
				}
				return 0.0;
			}
			if (double.IsPositiveInfinity(b))
			{
				if (!(x >= 0.0))
				{
					return 0.0;
				}
				return 1.0;
			}
			if (a == 0.0 && b == 0.0)
			{
				if (x >= 0.0 && x < 1.0)
				{
					return 0.5;
				}
				return 1.0;
			}
			if (a == 0.0)
			{
				return 1.0;
			}
			if (b == 0.0)
			{
				if (!(x >= 1.0))
				{
					return 0.0;
				}
				return 1.0;
			}
			if (a == 1.0 && b == 1.0)
			{
				return x;
			}
			return SpecialFunctions.BetaRegularized(a, b, x);
		}

		public static double InvCDF(double a, double b, double p)
		{
			if (a < 0.0 || b < 0.0 || p < 0.0 || p > 1.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return Brent.FindRoot((double x) => SpecialFunctions.BetaRegularized(a, b, x) - p, 0.0, 1.0, 1E-12);
		}

		public static double Sample(System.Random rnd, double a, double b)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, a, b);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double a, double b)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, a, b);
		}

		public static void Samples(System.Random rnd, double[] values, double a, double b)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, a, b);
		}

		public static double Sample(double a, double b)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, a, b);
		}

		public static IEnumerable<double> Samples(double a, double b)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, a, b);
		}

		public static void Samples(double[] values, double a, double b)
		{
			if (a < 0.0 || b < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, a, b);
		}
	}
}
