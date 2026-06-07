using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class InverseGamma : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _shape;

		private readonly double _scale;

		public double Shape => _shape;

		public double Scale => _scale;

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
				if (_shape <= 1.0)
				{
					throw new NotSupportedException();
				}
				return _scale / (_shape - 1.0);
			}
		}

		public double Variance
		{
			get
			{
				if (_shape <= 2.0)
				{
					throw new NotSupportedException();
				}
				return _scale * _scale / ((_shape - 1.0) * (_shape - 1.0) * (_shape - 2.0));
			}
		}

		public double StdDev => _scale / (Math.Abs(_shape - 1.0) * Math.Sqrt(_shape - 2.0));

		public double Entropy => _shape + Math.Log(_scale) + SpecialFunctions.GammaLn(_shape) - (1.0 + _shape) * SpecialFunctions.DiGamma(_shape);

		public double Skewness
		{
			get
			{
				if (_shape <= 3.0)
				{
					throw new NotSupportedException();
				}
				return 4.0 * Math.Sqrt(_shape - 2.0) / (_shape - 3.0);
			}
		}

		public double Mode => _scale / (_shape + 1.0);

		public double Median
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public InverseGamma(double shape, double scale)
		{
			if (!IsValidParameterSet(shape, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_shape = shape;
			_scale = scale;
		}

		public InverseGamma(double shape, double scale, System.Random randomSource)
		{
			if (!IsValidParameterSet(shape, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_shape = shape;
			_scale = scale;
		}

		public override string ToString()
		{
			return $"InverseGamma(α = {_shape}, β = {_scale})";
		}

		public static bool IsValidParameterSet(double shape, double scale)
		{
			if (shape > 0.0)
			{
				return scale > 0.0;
			}
			return false;
		}

		public double Density(double x)
		{
			if (!(x < 0.0))
			{
				return Math.Pow(_scale, _shape) * Math.Pow(x, 0.0 - _shape - 1.0) * Math.Exp((0.0 - _scale) / x) / SpecialFunctions.Gamma(_shape);
			}
			return 0.0;
		}

		public double DensityLn(double x)
		{
			return Math.Log(Density(x));
		}

		public double CumulativeDistribution(double x)
		{
			return SpecialFunctions.GammaUpperRegularized(_shape, _scale / x);
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _shape, _scale);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _shape, _scale);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _shape, _scale);
		}

		private static double SampleUnchecked(System.Random rnd, double shape, double scale)
		{
			return 1.0 / Gamma.SampleUnchecked(rnd, shape, scale);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double shape, double scale)
		{
			Gamma.SamplesUnchecked(rnd, values, shape, scale);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = 1.0 / values[i];
				}
			});
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double shape, double scale)
		{
			return from z in Gamma.SamplesUnchecked(rnd, shape, scale)
				select 1.0 / z;
		}

		public static double PDF(double shape, double scale, double x)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (!(x < 0.0))
			{
				return Math.Pow(scale, shape) * Math.Pow(x, 0.0 - shape - 1.0) * Math.Exp((0.0 - scale) / x) / SpecialFunctions.Gamma(shape);
			}
			return 0.0;
		}

		public static double PDFLn(double shape, double scale, double x)
		{
			return Math.Log(PDF(shape, scale, x));
		}

		public static double CDF(double shape, double scale, double x)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SpecialFunctions.GammaUpperRegularized(shape, scale / x);
		}

		public static double Sample(System.Random rnd, double shape, double scale)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, shape, scale);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double shape, double scale)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, shape, scale);
		}

		public static void Samples(System.Random rnd, double[] values, double shape, double scale)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, shape, scale);
		}

		public static double Sample(double shape, double scale)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, shape, scale);
		}

		public static IEnumerable<double> Samples(double shape, double scale)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, shape, scale);
		}

		public static void Samples(double[] values, double shape, double scale)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, shape, scale);
		}
	}
}
