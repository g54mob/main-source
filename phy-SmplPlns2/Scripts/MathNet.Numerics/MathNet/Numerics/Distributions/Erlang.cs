using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Erlang : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly int _shape;

		private readonly double _rate;

		public int Shape => _shape;

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
				if (_rate == 0.0 && (double)_shape == 0.0)
				{
					return double.NaN;
				}
				return (double)_shape / _rate;
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
				if (_rate == 0.0 && (double)_shape == 0.0)
				{
					return double.NaN;
				}
				return (double)_shape / (_rate * _rate);
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
				if (_rate == 0.0 && (double)_shape == 0.0)
				{
					return double.NaN;
				}
				return Math.Sqrt(_shape) / _rate;
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
				if (_rate == 0.0 && (double)_shape == 0.0)
				{
					return double.NaN;
				}
				return (double)_shape - Math.Log(_rate) + SpecialFunctions.GammaLn(_shape) + (1.0 - (double)_shape) * SpecialFunctions.DiGamma(_shape);
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
				if (_rate == 0.0 && (double)_shape == 0.0)
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
				if (_shape < 1)
				{
					throw new NotSupportedException();
				}
				if (double.IsPositiveInfinity(_rate))
				{
					return _shape;
				}
				if (_rate == 0.0 && (double)_shape == 0.0)
				{
					return double.NaN;
				}
				return ((double)_shape - 1.0) / _rate;
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

		public Erlang(int shape, double rate)
		{
			if (!IsValidParameterSet(shape, rate))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_shape = shape;
			_rate = rate;
		}

		public Erlang(int shape, double rate, System.Random randomSource)
		{
			if (!IsValidParameterSet(shape, rate))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_shape = shape;
			_rate = rate;
		}

		public static Erlang WithShapeScale(int shape, double scale, System.Random randomSource = null)
		{
			return new Erlang(shape, 1.0 / scale, randomSource);
		}

		public static Erlang WithShapeRate(int shape, double rate, System.Random randomSource = null)
		{
			return new Erlang(shape, rate, randomSource);
		}

		public override string ToString()
		{
			return $"Erlang(k = {_shape}, λ = {_rate})";
		}

		public static bool IsValidParameterSet(int shape, double rate)
		{
			if (shape >= 0)
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

		public double Sample()
		{
			return Gamma.SampleUnchecked(_random, _shape, _rate);
		}

		public void Samples(double[] values)
		{
			Gamma.SamplesUnchecked(_random, values, _shape, _rate);
		}

		public IEnumerable<double> Samples()
		{
			while (true)
			{
				yield return Gamma.SampleUnchecked(_random, _shape, _rate);
			}
		}

		public static double PDF(int shape, double rate, double x)
		{
			if ((double)shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(rate))
			{
				if (x != (double)shape)
				{
					return 0.0;
				}
				return double.PositiveInfinity;
			}
			if ((double)shape == 0.0 && rate == 0.0)
			{
				return 0.0;
			}
			if ((double)shape == 1.0)
			{
				return rate * Math.Exp((0.0 - rate) * x);
			}
			if ((double)shape > 160.0)
			{
				return Math.Exp(PDFLn(shape, rate, x));
			}
			return Math.Pow(rate, shape) * Math.Pow(x, (double)shape - 1.0) * Math.Exp((0.0 - rate) * x) / SpecialFunctions.Gamma(shape);
		}

		public static double PDFLn(int shape, double rate, double x)
		{
			if ((double)shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(rate))
			{
				if (x != (double)shape)
				{
					return double.NegativeInfinity;
				}
				return double.PositiveInfinity;
			}
			if ((double)shape == 0.0 && rate == 0.0)
			{
				return double.NegativeInfinity;
			}
			if ((double)shape == 1.0)
			{
				return Math.Log(rate) - rate * x;
			}
			return (double)shape * Math.Log(rate) + ((double)shape - 1.0) * Math.Log(x) - rate * x - SpecialFunctions.GammaLn(shape);
		}

		public static double CDF(int shape, double rate, double x)
		{
			if ((double)shape < 0.0 || rate < 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(rate))
			{
				if (!(x >= (double)shape))
				{
					return 0.0;
				}
				return 1.0;
			}
			if ((double)shape == 0.0 && rate == 0.0)
			{
				return 0.0;
			}
			return SpecialFunctions.GammaLowerRegularized(shape, x * rate);
		}

		public static double Sample(System.Random rnd, int shape, double rate)
		{
			return Gamma.Sample(rnd, shape, rate);
		}

		public static IEnumerable<double> Samples(System.Random rnd, int shape, double rate)
		{
			return Gamma.Samples(rnd, shape, rate);
		}

		public static void Samples(System.Random rnd, double[] values, int shape, double rate)
		{
			Gamma.Samples(rnd, values, shape, rate);
		}

		public static double Sample(int shape, double rate)
		{
			return Gamma.Sample(shape, rate);
		}

		public static IEnumerable<double> Samples(int shape, double rate)
		{
			return Gamma.Samples(shape, rate);
		}

		public static void Samples(double[] values, int shape, double rate)
		{
			Gamma.Samples(values, shape, rate);
		}
	}
}
