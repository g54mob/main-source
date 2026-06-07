using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;
using MathNet.Numerics.RootFinding;

namespace MathNet.Numerics.Distributions
{
	public class StudentT : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		private readonly double _location;

		private readonly double _scale;

		private readonly double _freedom;

		public double Location => _location;

		public double Scale => _scale;

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

		public double Mean
		{
			get
			{
				if (!(_freedom > 1.0))
				{
					return double.NaN;
				}
				return _location;
			}
		}

		public double Variance
		{
			get
			{
				if (double.IsPositiveInfinity(_freedom))
				{
					return _scale * _scale;
				}
				if (_freedom > 2.0)
				{
					return _freedom * _scale * _scale / (_freedom - 2.0);
				}
				if (!(_freedom > 1.0))
				{
					return double.NaN;
				}
				return double.PositiveInfinity;
			}
		}

		public double StdDev
		{
			get
			{
				if (double.IsPositiveInfinity(_freedom))
				{
					return Math.Sqrt(_scale * _scale);
				}
				if (_freedom > 2.0)
				{
					return Math.Sqrt(_freedom * _scale * _scale / (_freedom - 2.0));
				}
				if (!(_freedom > 1.0))
				{
					return double.NaN;
				}
				return double.PositiveInfinity;
			}
		}

		public double Entropy
		{
			get
			{
				if (_location != 0.0 || _scale != 1.0)
				{
					throw new NotSupportedException();
				}
				return (_freedom + 1.0) / 2.0 * (SpecialFunctions.DiGamma((1.0 + _freedom) / 2.0) - SpecialFunctions.DiGamma(_freedom / 2.0)) + Math.Log(Math.Sqrt(_freedom) * SpecialFunctions.Beta(_freedom / 2.0, 0.5));
			}
		}

		public double Skewness
		{
			get
			{
				if (_freedom <= 3.0)
				{
					throw new NotSupportedException();
				}
				return 0.0;
			}
		}

		public double Mode => _location;

		public double Median => _location;

		public double Minimum => double.NegativeInfinity;

		public double Maximum => double.PositiveInfinity;

		public StudentT()
		{
			_random = SystemRandomSource.Default;
			_location = 0.0;
			_scale = 1.0;
			_freedom = 1.0;
		}

		public StudentT(double location, double scale, double freedom)
		{
			if (!IsValidParameterSet(location, scale, freedom))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_location = location;
			_scale = scale;
			_freedom = freedom;
		}

		public StudentT(double location, double scale, double freedom, System.Random randomSource)
		{
			if (!IsValidParameterSet(location, scale, freedom))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_location = location;
			_scale = scale;
			_freedom = freedom;
		}

		public override string ToString()
		{
			return $"StudentT(μ = {_location}, σ = {_scale}, ν = {_freedom})";
		}

		public static bool IsValidParameterSet(double location, double scale, double freedom)
		{
			if (scale > 0.0 && freedom > 0.0)
			{
				return !double.IsNaN(location);
			}
			return false;
		}

		public double Density(double x)
		{
			return PDF(_location, _scale, _freedom, x);
		}

		public double DensityLn(double x)
		{
			return PDFLn(_location, _scale, _freedom, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CDF(_location, _scale, _freedom, x);
		}

		public double InverseCumulativeDistribution(double p)
		{
			return InvCDF(_location, _scale, _freedom, p);
		}

		private static double SampleUnchecked(System.Random rnd, double location, double scale, double freedom)
		{
			double num = Gamma.SampleUnchecked(rnd, 0.5 * freedom, 0.5);
			return Normal.Sample(rnd, location, scale * Math.Sqrt(freedom / num));
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double location, double scale, double freedom)
		{
			Gamma.SamplesUnchecked(rnd, values, 0.5 * freedom, 0.5);
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = Normal.Sample(rnd, location, scale * Math.Sqrt(freedom / values[i]));
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double location, double scale, double freedom)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, location, scale, freedom);
			}
		}

		public double Sample()
		{
			return SampleUnchecked(_random, _location, _scale, _freedom);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, _location, _scale, _freedom);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, _location, _scale, _freedom);
		}

		public static double PDF(double location, double scale, double freedom, double x)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (freedom >= 100000000.0)
			{
				return Normal.PDF(location, scale, x);
			}
			double num = (x - location) / scale;
			return Math.Exp(SpecialFunctions.GammaLn((freedom + 1.0) / 2.0) - SpecialFunctions.GammaLn(freedom / 2.0)) * Math.Pow(1.0 + num * num / freedom, -0.5 * (freedom + 1.0)) / Math.Sqrt(freedom * Math.PI) / scale;
		}

		public static double PDFLn(double location, double scale, double freedom, double x)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (freedom >= 100000000.0)
			{
				return Normal.PDFLn(location, scale, x);
			}
			double num = (x - location) / scale;
			return SpecialFunctions.GammaLn((freedom + 1.0) / 2.0) - 0.5 * ((freedom + 1.0) * Math.Log(1.0 + num * num / freedom)) - SpecialFunctions.GammaLn(freedom / 2.0) - 0.5 * Math.Log(freedom * Math.PI) - Math.Log(scale);
		}

		public static double CDF(double location, double scale, double freedom, double x)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(freedom))
			{
				return Normal.CDF(location, scale, x);
			}
			double num = (x - location) / scale;
			double x2 = freedom / (freedom + num * num);
			double num2 = 0.5 * SpecialFunctions.BetaRegularized(freedom / 2.0, 0.5, x2);
			if (!(x <= location))
			{
				return 1.0 - num2;
			}
			return num2;
		}

		public static double InvCDF(double location, double scale, double freedom, double p)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			if (double.IsPositiveInfinity(freedom))
			{
				return Normal.InvCDF(location, scale, p);
			}
			if (p == 0.5)
			{
				return location;
			}
			return Brent.FindRoot(delegate(double x)
			{
				double num = (x - location) / scale;
				double x2 = freedom / (freedom + num * num);
				double num2 = 0.5 * SpecialFunctions.BetaRegularized(freedom / 2.0, 0.5, x2);
				return (!(x <= location)) ? (1.0 - num2 - p) : (num2 - p);
			}, -800.0, 800.0, 1E-12);
		}

		public static double Sample(System.Random rnd, double location, double scale, double freedom)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, location, scale, freedom);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double location, double scale, double freedom)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, location, scale, freedom);
		}

		public static void Samples(System.Random rnd, double[] values, double location, double scale, double freedom)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, location, scale, freedom);
		}

		public static double Sample(double location, double scale, double freedom)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(SystemRandomSource.Default, location, scale, freedom);
		}

		public static IEnumerable<double> Samples(double location, double scale, double freedom)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(SystemRandomSource.Default, location, scale, freedom);
		}

		public static void Samples(double[] values, double location, double scale, double freedom)
		{
			if (scale <= 0.0 || freedom <= 0.0)
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(SystemRandomSource.Default, values, location, scale, freedom);
		}
	}
}
