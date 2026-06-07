using System;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public class UnivariateHybridMC : HybridMCGeneric<double>
	{
		private readonly Normal _distribution;

		private double _sdv;

		public double MomentumStdDev
		{
			get
			{
				return _sdv;
			}
			set
			{
				if (_sdv != value)
				{
					_sdv = SetPositive(value);
				}
			}
		}

		public UnivariateHybridMC(double x0, DensityLn<double> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval = 0, double pSdv = 1.0)
			: this(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, pSdv, SystemRandomSource.Default)
		{
		}

		public UnivariateHybridMC(double x0, DensityLn<double> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval, double pSdv, System.Random randomSource)
			: this(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, pSdv, randomSource, Grad)
		{
		}

		public UnivariateHybridMC(double x0, DensityLn<double> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval, double pSdv, System.Random randomSource, DiffMethod diff)
			: base(x0, pdfLnP, frogLeapSteps, stepSize, burnInterval, randomSource, diff)
		{
			MomentumStdDev = pSdv;
			_distribution = new Normal(0.0, MomentumStdDev, base.RandomSource);
			Burn(base.BurnInterval);
		}

		protected override double Copy(double source)
		{
			return source;
		}

		protected override double Create()
		{
			return 0.0;
		}

		protected override void DoAdd(ref double first, double factor, double second)
		{
			first += factor * second;
		}

		protected override double DoProduct(double first, double second)
		{
			return first * second;
		}

		protected override void DoSubtract(ref double first, double factor, double second)
		{
			first -= factor * second;
		}

		protected override void RandomizeMomentum(ref double p)
		{
			p = _distribution.Sample();
		}

		private static double Grad(DensityLn<double> function, double x)
		{
			double num = Math.Max(0.001, 1E-06 * x);
			double sample = x + num;
			double sample2 = x - num;
			return (function(sample) - function(sample2)) / (2.0 * num);
		}
	}
}
