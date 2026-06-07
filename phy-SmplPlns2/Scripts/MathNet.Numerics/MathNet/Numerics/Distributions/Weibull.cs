using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Distributions
{
	public class Weibull : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _shape;

		private readonly double _scale;

		private readonly double _scalePowShapeInv;

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

		public double Mean => _scale * SpecialFunctions.Gamma(1.0 + 1.0 / _shape);

		public double Variance => _scale * _scale * SpecialFunctions.Gamma(1.0 + 2.0 / _shape) - Mean * Mean;

		public double StdDev => Math.Sqrt(Variance);

		public double Entropy => 0.5772156649015329 * (1.0 - 1.0 / _shape) + Math.Log(_scale / _shape) + 1.0;

		public double Skewness
		{
			get
			{
				double mean = Mean;
				double stdDev = StdDev;
				double num = stdDev * stdDev;
				double num2 = num * stdDev;
				return (_scale * _scale * _scale * SpecialFunctions.Gamma(1.0 + 3.0 / _shape) - 3.0 * num * mean - mean * mean * mean) / num2;
			}
		}

		public double Mode
		{
			get
			{
				if (_shape <= 1.0)
				{
					return 0.0;
				}
				return _scale * Math.Pow((_shape - 1.0) / _shape, 1.0 / _shape);
			}
		}

		public double Median => _scale * Math.Pow(0.6931471805599453, 1.0 / _shape);

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public Weibull(double shape, double scale)
		{
			if (!IsValidParameterSet(shape, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_shape = shape;
			_scale = scale;
			_scalePowShapeInv = Math.Pow(scale, 0.0 - shape);
		}

		public Weibull(double shape, double scale, System.Random randomSource)
		{
			if (!IsValidParameterSet(shape, scale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_shape = shape;
			_scale = scale;
			_scalePowShapeInv = Math.Pow(scale, 0.0 - shape);
		}

		public override string ToString()
		{
			return $"Weibull(k = {_shape}, λ = {_scale})";
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
			if (x >= 0.0)
			{
				if (x == 0.0 && _shape == 1.0)
				{
					return _shape / _scale;
				}
				return _shape * Math.Pow(x / _scale, _shape - 1.0) * Math.Exp((0.0 - Math.Pow(x, _shape)) * _scalePowShapeInv) / _scale;
			}
			return 0.0;
		}

		public double DensityLn(double x)
		{
			if (x >= 0.0)
			{
				if (x == 0.0 && _shape == 1.0)
				{
					return Math.Log(_shape) - Math.Log(_scale);
				}
				return Math.Log(_shape) + (_shape - 1.0) * Math.Log(x / _scale) - Math.Pow(x, _shape) * _scalePowShapeInv - Math.Log(_scale);
			}
			return double.NegativeInfinity;
		}

		public double CumulativeDistribution(double x)
		{
			if (x < 0.0)
			{
				return 0.0;
			}
			return 0.0 - SpecialFunctions.Expm1((0.0 - Math.Pow(x, _shape)) * _scalePowShapeInv);
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
			double d = rnd.NextDouble();
			return scale * Math.Pow(0.0 - Math.Log(d), 1.0 / shape);
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double shape, double scale)
		{
			double exponent = 1.0 / shape;
			return from x in rnd.NextDoubleSequence()
				select scale * Math.Pow(0.0 - Math.Log(x), exponent);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double shape, double scale)
		{
			double exponent = 1.0 / shape;
			rnd.NextDoubles(values);
			CommonParallel.For(0, values.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					values[i] = scale * Math.Pow(0.0 - Math.Log(values[i]), exponent);
				}
			});
		}

		public static double PDF(double shape, double scale, double x)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x >= 0.0)
			{
				if (x == 0.0 && shape == 1.0)
				{
					return shape / scale;
				}
				return shape * Math.Pow(x / scale, shape - 1.0) * Math.Exp((0.0 - Math.Pow(x, shape)) * Math.Pow(scale, 0.0 - shape)) / scale;
			}
			return 0.0;
		}

		public static double PDFLn(double shape, double scale, double x)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x >= 0.0)
			{
				if (x == 0.0 && shape == 1.0)
				{
					return Math.Log(shape) - Math.Log(scale);
				}
				return Math.Log(shape) + (shape - 1.0) * Math.Log(x / scale) - Math.Pow(x, shape) * Math.Pow(scale, 0.0 - shape) - Math.Log(scale);
			}
			return double.NegativeInfinity;
		}

		public static double CDF(double shape, double scale, double x)
		{
			if (shape <= 0.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (x < 0.0)
			{
				return 0.0;
			}
			return 0.0 - SpecialFunctions.Expm1((0.0 - Math.Pow(x, shape)) * Math.Pow(scale, 0.0 - shape));
		}

		public static Weibull Estimate(IEnumerable<double> samples, System.Random randomSource = null)
		{
			double[] array = (samples as double[]) ?? samples.ToArray();
			double num = array.Length;
			double num2 = -2147483648.0;
			if (num <= 1.0)
			{
				throw new Exception("Observations not sufficient");
			}
			double num3 = 10.0;
			double num4 = 0.0;
			double[] array2;
			while (Math.Abs(num3 - num2) >= 0.0001)
			{
				double num6;
				double num7;
				double num5 = (num6 = (num7 = 0.0));
				array2 = array;
				foreach (double num8 in array2)
				{
					if (num8 > 0.0)
					{
						num5 += Math.Log(num8);
						num6 += Math.Pow(num8, num3);
						num7 += Math.Pow(num8, num3) * Math.Log(num8);
					}
				}
				double num9 = num * num6 / (num * num7 - num5 * num6);
				num2 = num3;
				num3 = (num3 + num9) / 2.0;
			}
			array2 = array;
			foreach (double num10 in array2)
			{
				if (num10 > 0.0)
				{
					num4 += Math.Pow(num10, num3);
				}
			}
			num4 = Math.Pow(num4 / num, 1.0 / num3);
			return new Weibull(num3, num4, randomSource);
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
