using System;
using System.Numerics;
using MathNet.Numerics.Integration;

namespace MathNet.Numerics
{
	public static class ContourIntegrate
	{
		public static Complex DoubleExponential(Func<double, Complex> f, double intervalBegin, double intervalEnd, double targetAbsoluteError = 1E-08)
		{
			if (intervalBegin > intervalEnd)
			{
				return -DoubleExponential(f, intervalEnd, intervalBegin, targetAbsoluteError);
			}
			if (double.IsInfinity(intervalBegin) && double.IsInfinity(intervalEnd))
			{
				return DoubleExponentialTransformation.ContourIntegrate((double t) => f(t / (1.0 - t * t)) * (1.0 + t * t) / ((1.0 - t * t) * (1.0 - t * t)), -1.0, 1.0, targetAbsoluteError);
			}
			if (double.IsInfinity(intervalEnd))
			{
				return DoubleExponentialTransformation.ContourIntegrate((double s) => 2.0 * s * f(intervalBegin + s / (1.0 - s) * (s / (1.0 - s))) / ((1.0 - s) * (1.0 - s) * (1.0 - s)), 0.0, 1.0, targetAbsoluteError);
			}
			if (double.IsInfinity(intervalBegin))
			{
				return DoubleExponentialTransformation.ContourIntegrate((double s) => -2.0 * s * f(intervalEnd - s / (1.0 + s) * (s / (1.0 + s))) / ((1.0 + s) * (1.0 + s) * (1.0 + s)), -1.0, 0.0, targetAbsoluteError);
			}
			return DoubleExponentialTransformation.ContourIntegrate(f, intervalBegin, intervalEnd, targetAbsoluteError);
		}

		public static Complex GaussLegendre(Func<double, Complex> f, double intervalBegin, double intervalEnd, int order = 128)
		{
			if (intervalBegin > intervalEnd)
			{
				return -GaussLegendre(f, intervalEnd, intervalBegin, order);
			}
			if (double.IsInfinity(intervalBegin) && double.IsInfinity(intervalEnd))
			{
				return GaussLegendreRule.ContourIntegrate((double t) => f(t / (1.0 - t * t)) * (1.0 + t * t) / ((1.0 - t * t) * (1.0 - t * t)), -1.0, 1.0, order);
			}
			if (double.IsInfinity(intervalEnd))
			{
				return GaussLegendreRule.ContourIntegrate((double s) => 2.0 * s * f(intervalBegin + s / (1.0 - s) * (s / (1.0 - s))) / ((1.0 - s) * (1.0 - s) * (1.0 - s)), 0.0, 1.0, order);
			}
			if (double.IsInfinity(intervalBegin))
			{
				return GaussLegendreRule.ContourIntegrate((double s) => -2.0 * s * f(intervalEnd - s / (1.0 + s) * (s / (1.0 + s))) / ((1.0 + s) * (1.0 + s) * (1.0 + s)), -1.0, 0.0, order);
			}
			return GaussLegendreRule.ContourIntegrate((double t) => f((intervalEnd - intervalBegin) / 4.0 * t * (3.0 - t * t) + (intervalEnd + intervalBegin) / 2.0) * 3 * (intervalEnd - intervalBegin) / 4 * (1.0 - t * t), -1.0, 1.0, order);
		}

		public static Complex GaussKronrod(Func<double, Complex> f, double intervalBegin, double intervalEnd, double targetRelativeError = 1E-08, int maximumDepth = 15, int order = 15)
		{
			double error;
			double L1Norm;
			return GaussKronrodRule.ContourIntegrate(f, intervalBegin, intervalEnd, out error, out L1Norm, targetRelativeError, maximumDepth, order);
		}

		public static Complex GaussKronrod(Func<double, Complex> f, double intervalBegin, double intervalEnd, out double error, out double L1Norm, double targetRelativeError = 1E-08, int maximumDepth = 15, int order = 15)
		{
			return GaussKronrodRule.ContourIntegrate(f, intervalBegin, intervalEnd, out error, out L1Norm, targetRelativeError, maximumDepth, order);
		}
	}
}
