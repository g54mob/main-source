using System;
using MathNet.Numerics.Integration;

namespace MathNet.Numerics
{
	public static class Integrate
	{
		public static double OnClosedInterval(Func<double, double> f, double intervalBegin, double intervalEnd, double targetAbsoluteError)
		{
			return DoubleExponentialTransformation.Integrate(f, intervalBegin, intervalEnd, targetAbsoluteError);
		}

		public static double OnClosedInterval(Func<double, double> f, double intervalBegin, double intervalEnd)
		{
			return DoubleExponentialTransformation.Integrate(f, intervalBegin, intervalEnd, 1E-08);
		}

		public static double OnRectangle(Func<double, double, double> f, double invervalBeginA, double invervalEndA, double invervalBeginB, double invervalEndB, int order)
		{
			return GaussLegendreRule.Integrate(f, invervalBeginA, invervalEndA, invervalBeginB, invervalEndB, order);
		}

		public static double OnRectangle(Func<double, double, double> f, double invervalBeginA, double invervalEndA, double invervalBeginB, double invervalEndB)
		{
			return GaussLegendreRule.Integrate(f, invervalBeginA, invervalEndA, invervalBeginB, invervalEndB, 32);
		}

		public static double OnCuboid(Func<double, double, double, double> f, double invervalBeginA, double invervalEndA, double invervalBeginB, double invervalEndB, double invervalBeginC, double invervalEndC, int order = 32)
		{
			return GaussLegendreRule.Integrate(f, invervalBeginA, invervalEndA, invervalBeginB, invervalEndB, invervalBeginC, invervalEndC, order);
		}

		public static double DoubleExponential(Func<double, double> f, double intervalBegin, double intervalEnd, double targetAbsoluteError = 1E-08)
		{
			if (intervalBegin > intervalEnd)
			{
				return 0.0 - DoubleExponential(f, intervalEnd, intervalBegin, targetAbsoluteError);
			}
			if (double.IsInfinity(intervalBegin) && double.IsInfinity(intervalEnd))
			{
				return DoubleExponentialTransformation.Integrate((double t) => f(t / (1.0 - t * t)) * (1.0 + t * t) / ((1.0 - t * t) * (1.0 - t * t)), -1.0, 1.0, targetAbsoluteError);
			}
			if (double.IsInfinity(intervalEnd))
			{
				return DoubleExponentialTransformation.Integrate((double s) => 2.0 * s * f(intervalBegin + s / (1.0 - s) * (s / (1.0 - s))) / ((1.0 - s) * (1.0 - s) * (1.0 - s)), 0.0, 1.0, targetAbsoluteError);
			}
			if (double.IsInfinity(intervalBegin))
			{
				return DoubleExponentialTransformation.Integrate((double s) => -2.0 * s * f(intervalEnd - s / (1.0 + s) * (s / (1.0 + s))) / ((1.0 + s) * (1.0 + s) * (1.0 + s)), -1.0, 0.0, targetAbsoluteError);
			}
			return DoubleExponentialTransformation.Integrate(f, intervalBegin, intervalEnd, targetAbsoluteError);
		}

		public static double GaussLegendre(Func<double, double> f, double intervalBegin, double intervalEnd, int order = 128)
		{
			if (intervalBegin > intervalEnd)
			{
				return 0.0 - GaussLegendre(f, intervalEnd, intervalBegin, order);
			}
			if (double.IsInfinity(intervalBegin) && double.IsInfinity(intervalEnd))
			{
				return GaussLegendreRule.Integrate((double t) => f(t / (1.0 - t * t)) * (1.0 + t * t) / ((1.0 - t * t) * (1.0 - t * t)), -1.0, 1.0, order);
			}
			if (double.IsInfinity(intervalEnd))
			{
				return GaussLegendreRule.Integrate((double s) => 2.0 * s * f(intervalBegin + s / (1.0 - s) * (s / (1.0 - s))) / ((1.0 - s) * (1.0 - s) * (1.0 - s)), 0.0, 1.0, order);
			}
			if (double.IsInfinity(intervalBegin))
			{
				return GaussLegendreRule.Integrate((double s) => -2.0 * s * f(intervalEnd - s / (1.0 + s) * (s / (1.0 + s))) / ((1.0 + s) * (1.0 + s) * (1.0 + s)), -1.0, 0.0, order);
			}
			return GaussLegendreRule.Integrate((double t) => f((intervalEnd - intervalBegin) / 4.0 * t * (3.0 - t * t) + (intervalEnd + intervalBegin) / 2.0) * 3.0 * (intervalEnd - intervalBegin) / 4.0 * (1.0 - t * t), -1.0, 1.0, order);
		}

		public static double GaussKronrod(Func<double, double> f, double intervalBegin, double intervalEnd, double targetRelativeError = 1E-08, int maximumDepth = 15, int order = 15)
		{
			double error;
			double L1Norm;
			return GaussKronrodRule.Integrate(f, intervalBegin, intervalEnd, out error, out L1Norm, targetRelativeError, maximumDepth, order);
		}

		public static double GaussKronrod(Func<double, double> f, double intervalBegin, double intervalEnd, out double error, out double L1Norm, double targetRelativeError = 1E-08, int maximumDepth = 15, int order = 15)
		{
			return GaussKronrodRule.Integrate(f, intervalBegin, intervalEnd, out error, out L1Norm, targetRelativeError, maximumDepth, order);
		}
	}
}
