using System;
using System.Collections.Generic;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Distributions
{
	public class NormalGamma : IDistribution
	{
		private System.Random _random;

		private readonly double _meanLocation;

		private readonly double _meanScale;

		private readonly double _precisionShape;

		private readonly double _precisionInvScale;

		public double MeanLocation => _meanLocation;

		public double MeanScale => _meanScale;

		public double PrecisionShape => _precisionShape;

		public double PrecisionInverseScale => _precisionInvScale;

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

		public MeanPrecisionPair Mean
		{
			get
			{
				if (!double.IsPositiveInfinity(_precisionInvScale))
				{
					return new MeanPrecisionPair(_meanLocation, _precisionShape / _precisionInvScale);
				}
				return new MeanPrecisionPair(_meanLocation, _precisionShape);
			}
		}

		public MeanPrecisionPair Variance => new MeanPrecisionPair(_precisionInvScale / (_meanScale * (_precisionShape - 1.0)), _precisionShape / Math.Sqrt(_precisionInvScale));

		public NormalGamma(double meanLocation, double meanScale, double precisionShape, double precisionInverseScale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(meanLocation, meanScale, precisionShape, precisionInverseScale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = SystemRandomSource.Default;
			_meanLocation = meanLocation;
			_meanScale = meanScale;
			_precisionShape = precisionShape;
			_precisionInvScale = precisionInverseScale;
		}

		public NormalGamma(double meanLocation, double meanScale, double precisionShape, double precisionInverseScale, System.Random randomSource)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(meanLocation, meanScale, precisionShape, precisionInverseScale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			_meanLocation = meanLocation;
			_meanScale = meanScale;
			_precisionShape = precisionShape;
			_precisionInvScale = precisionInverseScale;
		}

		public override string ToString()
		{
			return $"NormalGamma(Mean Location = {_meanLocation}, Mean Scale = {_meanScale}, Precision Shape = {_precisionShape}, Precision Inverse Scale = {_precisionInvScale})";
		}

		public static bool IsValidParameterSet(double meanLocation, double meanScale, double precShape, double precInvScale)
		{
			if (meanScale > 0.0 && precShape > 0.0 && precInvScale > 0.0)
			{
				return !double.IsNaN(meanLocation);
			}
			return false;
		}

		public StudentT MeanMarginal()
		{
			if (double.IsPositiveInfinity(_precisionInvScale))
			{
				return new StudentT(_meanLocation, 1.0 / (_meanScale * _precisionShape), double.PositiveInfinity);
			}
			return new StudentT(_meanLocation, Math.Sqrt(_precisionInvScale / (_meanScale * _precisionShape)), 2.0 * _precisionShape);
		}

		public Gamma PrecisionMarginal()
		{
			return new Gamma(_precisionShape, _precisionInvScale);
		}

		public double Density(MeanPrecisionPair mp)
		{
			return Density(mp.Mean, mp.Precision);
		}

		public double Density(double mean, double prec)
		{
			if (double.IsPositiveInfinity(_precisionInvScale) && _meanScale == 0.0)
			{
				throw new NotSupportedException();
			}
			if (double.IsPositiveInfinity(_precisionInvScale))
			{
				throw new NotSupportedException();
			}
			if (_meanScale <= 0.0)
			{
				throw new NotSupportedException();
			}
			if (_precisionShape > 160.0)
			{
				return Math.Exp(DensityLn(mean, prec));
			}
			double d = 0.0 - 0.5 * prec * _meanScale * (mean - _meanLocation) * (mean - _meanLocation) - prec * _precisionInvScale;
			return Math.Pow(prec * _precisionInvScale, _precisionShape) * Math.Exp(d) * Math.Sqrt(_meanScale) / (2.5066282746310007 * Math.Sqrt(prec) * SpecialFunctions.Gamma(_precisionShape));
		}

		public double DensityLn(MeanPrecisionPair mp)
		{
			return DensityLn(mp.Mean, mp.Precision);
		}

		public double DensityLn(double mean, double prec)
		{
			if (double.IsPositiveInfinity(_precisionInvScale) && _meanScale == 0.0)
			{
				throw new NotSupportedException();
			}
			if (double.IsPositiveInfinity(_precisionInvScale))
			{
				throw new NotSupportedException();
			}
			if (_meanScale <= 0.0)
			{
				throw new NotSupportedException();
			}
			double num = 0.0 - 0.5 * prec * _meanScale * (mean - _meanLocation) * (mean - _meanLocation) - prec * _precisionInvScale;
			return (_precisionShape - 0.5) * Math.Log(prec) + _precisionShape * Math.Log(_precisionInvScale) - 0.5 * Math.Log(_meanScale) + num - 0.9189385332046728 - SpecialFunctions.GammaLn(_precisionShape);
		}

		public MeanPrecisionPair Sample()
		{
			return Sample(_random, _meanLocation, _meanScale, _precisionShape, _precisionInvScale);
		}

		public IEnumerable<MeanPrecisionPair> Samples()
		{
			while (true)
			{
				yield return Sample(_random, _meanLocation, _meanScale, _precisionShape, _precisionInvScale);
			}
		}

		public static MeanPrecisionPair Sample(System.Random rnd, double meanLocation, double meanScale, double precisionShape, double precisionInverseScale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(meanLocation, meanScale, precisionShape, precisionInverseScale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			MeanPrecisionPair result = default(MeanPrecisionPair);
			result.Precision = (double.IsPositiveInfinity(precisionInverseScale) ? precisionShape : Gamma.Sample(rnd, precisionShape, precisionInverseScale));
			result.Mean = ((meanScale == 0.0) ? meanLocation : Normal.Sample(rnd, meanLocation, Math.Sqrt(1.0 / (meanScale * result.Precision))));
			return result;
		}

		public static IEnumerable<MeanPrecisionPair> Samples(System.Random rnd, double meanLocation, double meanScale, double precisionShape, double precisionInvScale)
		{
			if (Control.CheckDistributionParameters && !IsValidParameterSet(meanLocation, meanScale, precisionShape, precisionInvScale))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			while (true)
			{
				MeanPrecisionPair meanPrecisionPair = default(MeanPrecisionPair);
				meanPrecisionPair.Precision = (double.IsPositiveInfinity(precisionInvScale) ? precisionShape : Gamma.Sample(rnd, precisionShape, precisionInvScale));
				meanPrecisionPair.Mean = ((meanScale == 0.0) ? meanLocation : Normal.Sample(rnd, meanLocation, Math.Sqrt(1.0 / (meanScale * meanPrecisionPair.Precision))));
				yield return meanPrecisionPair;
			}
		}
	}
}
