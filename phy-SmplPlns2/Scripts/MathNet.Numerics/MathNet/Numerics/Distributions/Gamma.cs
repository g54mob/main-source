using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Gamma : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _shape;

		private readonly double _rate;

		public double Shape => _shape;

		public double Rate => _rate;

		public double Scale => 1.0 / _rate;

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
				if (double.IsPositiveInfinity(_rate))
				{
					return _shape;
				}
				if (_rate == 0.0 && _shape == 0.0)
				{
					return double.NaN;
				}
				return _shape / _rate;
			}
		}

		public double Variance
		{
			get
			{
				if (double.IsPositiveInfinity(_rate))
				{
					return 0.0;
				}
				if (_rate == 0.0 && _shape == 0.0)
				{
					return double.NaN;
				}
				return _shape / (_rate * _rate);
			}
		}

		public double StdDev
		{
			get
			{
				if (double.IsPositiveInfinity(_rate))
				{
					return 0.0;
				}
				if (_rate == 0.0 && _shape == 0.0)
				{
					return double.NaN;
				}
				return Math.Sqrt(_shape / (_rate * _rate));
			}
		}

		public double Entropy
		{
			get
			{
				if (double.IsPositiveInfinity(_rate))
				{
					return 0.0;
				}
				if (_rate == 0.0 && _shape == 0.0)
				{
					return double.NaN;
				}
				return _shape - Math.Log(_rate) + SpecialFunctions.GammaLn(_shape) + (1.0 - _shape) * SpecialFunctions.DiGamma(_shape);
			}
		}

		public double Skewness
		{
			get
			{
				if (double.IsPositiveInfinity(_rate))
				{
					return 0.0;
				}
				if (_rate == 0.0 && _shape == 0.0)
				{
					return double.NaN;
				}
				return 2.0 / Math.Sqrt(_shape);
			}
		}

		public double Mode
		{
			get
			{
				if (double.IsPositiveInfinity(_rate))
				{
					return _shape;
				}
				if (_rate == 0.0 && _shape == 0.0)
				{
					return double.NaN;
				}
				return (_shape - 1.0) / _rate;
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

		public Gamma(double shape, double rate)
		{
			if (!IsValidParameterSet(shape, rate))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_shape = shape;
			_rate = rate;
		}

		public Gamma(double shape, double rate, System.Random randomSource)
		{
			if (!IsValidParameterSet(shape, rate))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_shape = shape;
			_rate = rate;
		}

		public static Gamma WithShapeScale(double shape, double scale, System.Random randomSource = null)
		{
			return new Gamma(shape, 1.0 / scale, randomSource);
		}

		public static Gamma WithShapeRate(double shape, double rate, System.Random randomSource = null)
		{
			return new Gamma(shape, rate, randomSource);
		}

		public override string ToString()
		{
			return $"Gamma(α = {_shape}, β = {_rate})";
		}

		public static bool IsValidParameterSet(double shape, double rate)
		{
			if (shape >= 0.0)
			{
				return rate >= 0.0;
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_shape, _rate, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_shape, _rate, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_shape, _rate, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_shape, _rate, p);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _shape, _rate);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _shape, _rate);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _shape, _rate);
		}

		internal static double SampleUnchecked(System.Random rnd, double shape, double rate)
		{
			if (double.IsPositiveInfinity(rate))
			{
				return shape;
			}
			double num = shape;
			double num2 = 1.0;
			if (shape < 1.0)
			{
				num = shape + 1.0;
				num2 = Math.Pow(rnd.NextDouble(), 1.0 / shape);
			}
			double num3 = num - 1.0 / 3.0;
			double num4 = 1.0 / Math.Sqrt(9.0 * num3);
			double num6;
			double num7;
			double num5;
			do
			{
				num5 = Normal.Sample(rnd, 0.0, 1.0);
				for (num6 = 1.0 + num4 * num5; num6 <= 0.0; num6 = 1.0 + num4 * num5)
				{
					num5 = Normal.Sample(rnd, 0.0, 1.0);
				}
				num6 = num6 * num6 * num6;
				num7 = rnd.NextDouble();
				num5 *= num5;
				if (num7 < 1.0 - 0.0331 * num5 * num5)
				{
					return num2 * num3 * num6 / rate;
				}
			}
			while (!(Math.Log(num7) < 0.5 * num5 + num3 * (1.0 - num6 + Math.Log(num6))));
			return num2 * num3 * num6 / rate;
		}

		internal static void SamplesUnchecked(System.Random rnd, double[] values, double shape, double rate)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = SampleUnchecked(rnd, shape, rate);
			}
		}

		internal static IEnumerable<double> SamplesUnchecked(System.Random rnd, double location, double scale)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, location, scale);
			}
		}

		public static double PDF(double shape, double rate, double x)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(rate))
			{
				if (x != shape)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if (shape == 0.0 && rate == 0.0)
			{
				return 0.0;
			}
			if (shape == 1.0)
			{
				return rate * Math.Exp((0.0 - rate) * x);
			}
			if (shape > 160.0)
			{
				return Math.Exp(PDFLn(shape, rate, x));
			}
			return Math.Pow(rate, shape) * Math.Pow(x, shape - 1.0) * Math.Exp((0.0 - rate) * x) / SpecialFunctions.Gamma(shape);
		}

		public static double PDFLn(double shape, double rate, double x)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(rate))
			{
				if (x != shape)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if (shape == 0.0 && rate == 0.0)
			{
				return double.NegativeInfinity;
			}
			if (shape == 1.0)
			{
				return Math.Log(rate) - rate * x;
			}
			return shape * Math.Log(rate) + (shape - 1.0) * Math.Log(x) - rate * x - SpecialFunctions.GammaLn(shape);
		}

		public static double CDF(double shape, double rate, double x)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(rate))
			{
				if (!(x >= shape))
				{
					return 0.0;
				}
				return 1.0;
			}
			if (shape == 0.0 && rate == 0.0)
			{
				return 0.0;
			}
			return SpecialFunctions.GammaLowerRegularized(shape, x * rate);
		}

		public static double InvCDF(double shape, double rate, double p)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.GammaLowerRegularizedInv(shape, p) / rate;
		}

		public static double Sample(System.Random rnd, double shape, double rate)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, shape, rate);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double shape, double rate)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, shape, rate);
		}

		public static void Samples(System.Random rnd, double[] values, double shape, double rate)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, shape, rate);
		}

		public static double Sample(double shape, double rate)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, shape, rate);
		}

		public static IEnumerable<double> Samples(double shape, double rate)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, shape, rate);
		}

		public static void Samples(double[] values, double shape, double rate)
		{
			if (shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, shape, rate);
		}
	}
}
