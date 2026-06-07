using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Random;
using MathNet.Numerics.RootFinding;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics.Distributions
{
	public class InverseGaussian : IContinuousDistribution, IUnivariateDistribution, IDistribution
	{
		private System.Random _random;

		public double Mu { get; }

		public double Lambda { get; }

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

		public double Mean => Mu;

		public double Variance => Math.Pow(Mu, 3.0) / Lambda;

		public double StdDev => Math.Sqrt(Variance);

		public double Median => InvCDF(0.5);

		public double Minimum => 0.0;

		public double Maximum => double.PositiveInfinity;

		public double Skewness => 3.0 * Math.Sqrt(Mu / Lambda);

		public double Kurtosis => 15.0 * Mu / Lambda;

		public double Mode => Mu * (Math.Sqrt(1.0 + 9.0 * Mu * Mu / (4.0 * Lambda * Lambda)) - 3.0 * Mu / (2.0 * Lambda));

		public double Entropy
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public InverseGaussian(double mu, double lambda, System.Random randomSource = null)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			_random = randomSource ?? SystemRandomSource.Default;
			Mu = mu;
			Lambda = lambda;
		}

		public override string ToString()
		{
			return $"InverseGaussian(μ = {Mu}, λ = {Lambda})";
		}

		public static bool IsValidParameterSet(double mu, double lambda)
		{
			if (mu.IsFinite() && lambda.IsFinite() && mu > 0.0)
			{
				return lambda > 0.0;
			}
			return false;
		}

		public double Sample()
		{
			return SampleUnchecked(_random, Mu, Lambda);
		}

		public void Samples(double[] values)
		{
			SamplesUnchecked(_random, values, Mu, Lambda);
		}

		public IEnumerable<double> Samples()
		{
			return SamplesUnchecked(_random, Mu, Lambda);
		}

		public static double Sample(System.Random rnd, double mu, double lambda)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SampleUnchecked(rnd, mu, lambda);
		}

		public static void Samples(System.Random rnd, double[] values, double mu, double lambda)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			SamplesUnchecked(rnd, values, mu, lambda);
		}

		public static IEnumerable<double> Samples(System.Random rnd, double mu, double lambda)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return SamplesUnchecked(rnd, mu, lambda);
		}

		private static double SampleUnchecked(System.Random rnd, double mu, double lambda)
		{
			double normalSample = Normal.Sample(rnd, 0.0, 1.0);
			double uniformSample = rnd.NextDouble();
			return InverseGaussianSampleImpl(mu, lambda, normalSample, uniformSample);
		}

		private static void SamplesUnchecked(System.Random rnd, double[] values, double mu, double lambda)
		{
			if (values.Length != 0)
			{
				double[] array = new double[values.Length];
				Normal.Samples(rnd, array, 0.0, 1.0);
				double[] array2 = rnd.NextDoubles(values.Length);
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = InverseGaussianSampleImpl(mu, lambda, array[i], array2[i]);
				}
			}
		}

		private static IEnumerable<double> SamplesUnchecked(System.Random rnd, double mu, double lambda)
		{
			while (true)
			{
				yield return SampleUnchecked(rnd, mu, lambda);
			}
		}

		private static double InverseGaussianSampleImpl(double mu, double lambda, double normalSample, double uniformSample)
		{
			double num = normalSample * normalSample;
			double num2 = mu + mu * mu * num / (2.0 * lambda) - mu / (2.0 * lambda) * Math.Sqrt(4.0 * mu * lambda * num + mu * mu * num * num);
			if (uniformSample <= mu / (mu + num2))
			{
				return num2;
			}
			return mu * mu / num2;
		}

		public double Density(double x)
		{
			return DensityImpl(Mu, Lambda, x);
		}

		public double DensityLn(double x)
		{
			return DensityLnImpl(Mu, Lambda, x);
		}

		public double CumulativeDistribution(double x)
		{
			return CumulativeDistributionImpl(Mu, Lambda, x);
		}

		public double InvCDF(double p)
		{
			if (!NewtonRaphson.TryFindRoot(EquationToSolve, Density, Mode, 0.0, double.PositiveInfinity, 1E-08, 100, out var root))
			{
				throw new NonConvergenceException("Numerical estimation of the statistic has failed. The used solver did not succeed in finding a root.");
			}
			return root;
			double EquationToSolve(double x)
			{
				return CumulativeDistribution(x) - p;
			}
		}

		public static double PDF(double mu, double lambda, double x)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DensityImpl(mu, lambda, x);
		}

		public static double PDFLn(double mu, double lambda, double x)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return DensityLnImpl(mu, lambda, x);
		}

		public static double CDF(double mu, double lambda, double x)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return CumulativeDistributionImpl(mu, lambda, x);
		}

		public static double InvCDF(double mu, double lambda, double p)
		{
			if (!IsValidParameterSet(mu, lambda))
			{
				throw new ArgumentException("Invalid parametrization for the distribution.");
			}
			return new InverseGaussian(mu, lambda).InvCDF(p);
		}

		public static InverseGaussian Estimate(IEnumerable<double> samples, System.Random randomSource = null)
		{
			double[] data = samples.ToArray();
			double num = data.Mean();
			double lambda = 1.0 / (1.0 / data.HarmonicMean() - 1.0 / num);
			return new InverseGaussian(num, lambda, randomSource);
		}

		private static double DensityImpl(double mu, double lambda, double x)
		{
			return Math.Sqrt(lambda / (Math.PI * 2.0 * Math.Pow(x, 3.0))) * Math.Exp(0.0 - lambda * Math.Pow(x - mu, 2.0) / (2.0 * mu * mu * x));
		}

		private static double DensityLnImpl(double mu, double lambda, double x)
		{
			return Math.Log(Math.Sqrt(lambda / (Math.PI * 2.0 * Math.Pow(x, 3.0)))) - lambda * Math.Pow(x - mu, 2.0) / (2.0 * mu * mu * x);
		}

		private static double CumulativeDistributionImpl(double mu, double lambda, double x)
		{
			return Normal.CDF(0.0, 1.0, Math.Sqrt(lambda / x) * (x / mu - 1.0)) + Math.Exp(2.0 * lambda / mu) * Normal.CDF(0.0, 1.0, (0.0 - Math.Sqrt(lambda / x)) * (x / mu + 1.0));
		}
	}
}
