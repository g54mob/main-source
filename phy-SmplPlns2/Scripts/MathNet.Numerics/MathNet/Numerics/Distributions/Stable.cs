using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class Stable : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _alpha;

		private readonly double _beta;

		private readonly double _scale;

		private readonly double _location;

		public double Alpha => _alpha;

		public double Beta => _beta;

		public double Scale => _scale;

		public double Location => _location;

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
				if (_alpha <= 1.0)
				{
					throw new NotSupportedException();
				}
				return _location;
			}
		}

		public double Variance
		{
			get
			{
				if (_alpha == 2.0)
				{
					return 2.0 * _scale * _scale;
				}
				return double.PositiveInfinity;
			}
		}

		public double StdDev
		{
			get
			{
				if (_alpha == 2.0)
				{
					return 1.4142135623730951 * _scale;
				}
				return double.PositiveInfinity;
			}
		}

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
				if (_alpha != 2.0)
				{
					throw new NotSupportedException();
				}
				return 0.0;
			}
		}

		public double Mode
		{
			get
			{
				if (_beta != 0.0)
				{
					throw new NotSupportedException();
				}
				return _location;
			}
		}

		public double Median
		{
			get
			{
				if (_beta != 0.0)
				{
					throw new NotSupportedException();
				}
				return _location;
			}
		}

		public double Minimum
		{
			get
			{
				if (Math.Abs(_beta) == 1.0)
				{
					return 0.0;
				}
				return double.NegativeInfinity;
			}
		}

		public double Maximum => double.PositiveInfinity;

		public Stable(double alpha, double beta, double scale, double location)
		{
			if (!IsValidParameterSet(alpha, beta, scale, location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_alpha = alpha;
			_beta = beta;
			_scale = scale;
			_location = location;
		}

		public Stable(double alpha, double beta, double scale, double location, System.Random randomSource)
		{
			if (!IsValidParameterSet(alpha, beta, scale, location))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_alpha = alpha;
			_beta = beta;
			_scale = scale;
			_location = location;
		}

		public override string ToString()
		{
			return $"Stable(α = {_alpha}, β = {_beta}, c = {_scale}, μ = {_location})";
		}

		public static bool IsValidParameterSet(double alpha, double beta, double scale, double location)
		{
			if (alpha > 0.0 && alpha <= 2.0 && beta >= -1.0 && beta <= 1.0 && scale > 0.0)
			{
				return !double.IsNaN(location);
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_alpha, _beta, _scale, _location, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_alpha, _beta, _scale, _location, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_alpha, _beta, _scale, _location, x);
		}

		private static double SampleUnchecked(System.Random rnd, double alpha, double beta, double scale, double location)
		{
			double num = ContinuousUniform.Sample(rnd, -Math.PI / 2.0, Math.PI / 2.0);
			double num2 = Exponential.Sample(rnd, 1.0);
			if (!1.0.AlmostEqual(alpha))
			{
				double num3 = 1.0 / alpha * Math.Atan(beta * Math.Tan(Math.PI / 2.0 * alpha));
				double num4 = alpha * (num + num3);
				double num5 = beta * Math.Tan(Math.PI / 2.0 * alpha);
				double num6 = Math.Pow(1.0 + num5 * num5, 1.0 / (2.0 * alpha));
				double num7 = Math.Sin(num4) / Math.Pow(Math.Cos(num), 1.0 / alpha);
				double num8 = Math.Pow(Math.Cos(num - num4) / num2, (1.0 - alpha) / alpha);
				return location + scale * (num6 * num7 * num8);
			}
			double num9 = Math.PI / 2.0 + beta * num;
			double num10 = num9 * Math.Tan(num);
			double num11 = beta * Math.Log(Math.PI / 2.0 * num2 * Math.Cos(num) / num9);
			return location + scale * (2.0 / Math.PI) * (num10 - num11);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double alpha, double beta, double scale, double location)
		{
			double[] array = new double[values.Length];
			double[] array2 = new double[values.Length];
			ContinuousUniform.SamplesUnchecked(rnd, array, -Math.PI / 2.0, Math.PI / 2.0);
			Exponential.SamplesUnchecked(rnd, array2, 1.0);
			if (!1.0.AlmostEqual(alpha))
			{
				for (int i = 0; i < values.Length; i++)
				{
					double num = array[i];
					double num2 = 1.0 / alpha * Math.Atan(beta * Math.Tan(Math.PI / 2.0 * alpha));
					double num3 = alpha * (num + num2);
					double num4 = beta * Math.Tan(Math.PI / 2.0 * alpha);
					double num5 = Math.Pow(1.0 + num4 * num4, 1.0 / (2.0 * alpha));
					double num6 = Math.Sin(num3) / Math.Pow(Math.Cos(num), 1.0 / alpha);
					double num7 = Math.Pow(Math.Cos(num - num3) / array2[i], (1.0 - alpha) / alpha);
					values[i] = location + scale * (num5 * num6 * num7);
				}
			}
			else
			{
				for (int j = 0; j < values.Length; j++)
				{
					double num8 = array[j];
					double num9 = Math.PI / 2.0 + beta * num8;
					double num10 = num9 * Math.Tan(num8);
					double num11 = beta * Math.Log(Math.PI / 2.0 * array2[j] * Math.Cos(num8) / num9);
					values[j] = location + scale * (2.0 / Math.PI) * (num10 - num11);
				}
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double alpha, double beta, double scale, double location)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, alpha, beta, scale, location);
			}
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _alpha, _beta, _scale, _location);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _alpha, _beta, _scale, _location);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _alpha, _beta, _scale, _location);
		}

		public static double PDF(double alpha, double beta, double scale, double location, double x)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (alpha == 2.0)
			{
				return Normal.PDF(location, 1.4142135623730951 * scale, x);
			}
			if (alpha == 1.0 && beta == 0.0)
			{
				return Cauchy.PDF(location, scale, x);
			}
			if (alpha == 0.5 && beta == 1.0 && x >= location)
			{
				return Math.Sqrt(scale / (Math.PI * 2.0)) * Math.Exp((0.0 - scale) / (2.0 * (x - location))) / Math.Pow(x - location, 1.5);
			}
			throw new NotSupportedException();
		}

		public static double PDFLn(double alpha, double beta, double scale, double location, double x)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (alpha == 2.0)
			{
				return Normal.PDFLn(location, 1.4142135623730951 * scale, x);
			}
			if (alpha == 1.0 && beta == 0.0)
			{
				return Cauchy.PDFLn(location, scale, x);
			}
			if (alpha == 0.5 && beta == 1.0 && x >= location)
			{
				return Math.Log(scale / (Math.PI * 2.0)) / 2.0 - scale / (2.0 * (x - location)) - 1.5 * Math.Log(x - location);
			}
			throw new NotSupportedException();
		}

		public static double CDF(double alpha, double beta, double scale, double location, double x)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (alpha == 2.0)
			{
				return Normal.CDF(location, 1.4142135623730951 * scale, x);
			}
			if (alpha == 1.0 && beta == 0.0)
			{
				return Cauchy.CDF(location, scale, x);
			}
			if (alpha == 0.5 && beta == 1.0)
			{
				return SpecialFunctions.Erfc(Math.Sqrt(scale / (2.0 * (x - location))));
			}
			throw new NotSupportedException();
		}

		public static double Sample(System.Random rnd, double alpha, double beta, double scale, double location)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, alpha, beta, scale, location);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double alpha, double beta, double scale, double location)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, alpha, beta, scale, location);
		}

		public static void Samples(System.Random rnd, double[] values, double alpha, double beta, double scale, double location)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, alpha, beta, scale, location);
		}

		public static double Sample(double alpha, double beta, double scale, double location)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, alpha, beta, scale, location);
		}

		public static IEnumerable<double> Samples(double alpha, double beta, double scale, double location)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, alpha, beta, scale, location);
		}

		public static void Samples(double[] values, double alpha, double beta, double scale, double location)
		{
			if (alpha <= 0.0 || alpha > 2.0 || beta < -1.0 || beta > 1.0 || scale <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, alpha, beta, scale, location);
		}
	}
}
