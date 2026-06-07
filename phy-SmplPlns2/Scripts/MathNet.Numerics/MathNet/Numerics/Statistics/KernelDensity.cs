using System;
using System.Collections.Generic;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Statistics
{
	public static class KernelDensity
	{
		public static double Estimate(double x, double bandwidth, IList<double> samples, Func<double, double> kernel)
		{
			if (bandwidth <= 0.0)
			{
				throw new ArgumentException("The bandwidth must be a positive number!");
			}
			int count = samples.Count;
			return CommonParallel.Aggregate(0, count, (int i) => kernel((x - samples[i]) / bandwidth), (double a, double b) => a + b, 0.0) / ((double)count * bandwidth);
		}

		public static double EstimateGaussian(double x, double bandwidth, IList<double> samples)
		{
			return Estimate(x, bandwidth, samples, GaussianKernel);
		}

		public static double EstimateEpanechnikov(double x, double bandwidth, IList<double> samples)
		{
			return Estimate(x, bandwidth, samples, EpanechnikovKernel);
		}

		public static double EstimateUniform(double x, double bandwidth, IList<double> samples)
		{
			return Estimate(x, bandwidth, samples, UniformKernel);
		}

		public static double EstimateTriangular(double x, double bandwidth, IList<double> samples)
		{
			return Estimate(x, bandwidth, samples, TriangularKernel);
		}

		public static double GaussianKernel(double x)
		{
			return Normal.PDF(0.0, 1.0, x);
		}

		public static double EpanechnikovKernel(double x)
		{
			if (!(Math.Abs(x) <= 1.0))
			{
				return 0.0;
			}
			return 0.75 * (1.0 - x * x);
		}

		public static double UniformKernel(double x)
		{
			return ContinuousUniform.PDF(-1.0, 1.0, x);
		}

		public static double TriangularKernel(double x)
		{
			return Triangular.PDF(-1.0, 1.0, 0.0, x);
		}
	}
}
