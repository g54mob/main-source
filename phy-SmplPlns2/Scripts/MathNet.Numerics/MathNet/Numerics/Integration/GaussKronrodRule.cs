using System;
using System.Numerics;
using MathNet.Numerics.Integration.GaussRule;

namespace MathNet.Numerics.Integration
{
	public class GaussKronrodRule
	{
		private readonly GaussPointPair _gaussKronrodPoint;

		public int Order => _gaussKronrodPoint.Order;

		public double[] KronrodAbscissas => _gaussKronrodPoint.Abscissas.Clone() as double[];

		public double[] KronrodWeights => _gaussKronrodPoint.Weights.Clone() as double[];

		public double[] GaussWeights => _gaussKronrodPoint.SecondWeights.Clone() as double[];

		public GaussKronrodRule(int order)
		{
			_gaussKronrodPoint = GaussKronrodPointFactory.GetGaussPoint(order);
		}

		public static double Integrate(Func<double, double> f, double intervalBegin, double intervalEnd, out double error, out double L1Norm, double targetRelativeError = 1E-10, int maximumDepth = 15, int order = 15)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (intervalBegin > intervalEnd)
			{
				return 0.0 - Integrate(f, intervalEnd, intervalBegin, out error, out L1Norm, targetRelativeError, maximumDepth, order);
			}
			GaussPointPair gaussPoint = GaussKronrodPointFactory.GetGaussPoint(order);
			if (intervalBegin < double.MinValue && intervalEnd > double.MaxValue)
			{
				return recursive_adaptive_integrate((double t) => f(t / (1.0 - t * t)) * (1.0 + t * t) / ((1.0 - t * t) * (1.0 - t * t)), -1.0, 1.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
			}
			if (intervalEnd > double.MaxValue)
			{
				return recursive_adaptive_integrate((double s) => 2.0 * s * f(intervalBegin + s / (1.0 - s) * (s / (1.0 - s))) / ((1.0 - s) * (1.0 - s) * (1.0 - s)), 0.0, 1.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
			}
			if (intervalBegin < double.MinValue)
			{
				return recursive_adaptive_integrate((double s) => -2.0 * s * f(intervalEnd - s / (1.0 + s) * (s / (1.0 + s))) / ((1.0 + s) * (1.0 + s) * (1.0 + s)), -1.0, 0.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
			}
			return recursive_adaptive_integrate((double t) => f((intervalEnd - intervalBegin) / 4.0 * t * (3.0 - t * t) + (intervalEnd + intervalBegin) / 2.0) * 3.0 * (intervalEnd - intervalBegin) / 4.0 * (1.0 - t * t), -1.0, 1.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
		}

		public static Complex ContourIntegrate(Func<double, Complex> f, double intervalBegin, double intervalEnd, out double error, out double L1Norm, double targetRelativeError = 1E-10, int maximumDepth = 15, int order = 15)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (intervalBegin > intervalEnd)
			{
				return -ContourIntegrate(f, intervalEnd, intervalBegin, out error, out L1Norm, targetRelativeError, maximumDepth, order);
			}
			GaussPointPair gaussPoint = GaussKronrodPointFactory.GetGaussPoint(order);
			if (intervalBegin < double.MinValue && intervalEnd > double.MaxValue)
			{
				return contour_recursive_adaptive_integrate((double t) => f(t / (1.0 - t * t)) * (1.0 + t * t) / ((1.0 - t * t) * (1.0 - t * t)), -1.0, 1.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
			}
			if (intervalEnd > double.MaxValue)
			{
				return contour_recursive_adaptive_integrate((double s) => 2.0 * s * f(intervalBegin + s / (1.0 - s) * (s / (1.0 - s))) / ((1.0 - s) * (1.0 - s) * (1.0 - s)), 0.0, 1.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
			}
			if (intervalBegin < double.MinValue)
			{
				return contour_recursive_adaptive_integrate((double s) => -2.0 * s * f(intervalEnd - s / (1.0 + s) * (s / (1.0 + s))) / ((1.0 + s) * (1.0 + s) * (1.0 + s)), -1.0, 0.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
			}
			return contour_recursive_adaptive_integrate((double t) => f((intervalEnd - intervalBegin) / 4.0 * t * (3.0 - t * t) + (intervalEnd + intervalBegin) / 2.0) * 3 * (intervalEnd - intervalBegin) / 4 * (1.0 - t * t), -1.0, 1.0, maximumDepth, targetRelativeError, 0.0, out error, out L1Norm, gaussPoint);
		}

		private static double integrate_non_adaptive_m1_1(Func<double, double> f, out double error, out double pL1, GaussPointPair gaussKronrodPoint)
		{
			int num = 2;
			int num2 = 1;
			int num3 = (gaussKronrodPoint.Order - 1) / 2;
			double num4 = 0.0;
			double[] abscissas = gaussKronrodPoint.Abscissas;
			double[] weights = gaussKronrodPoint.Weights;
			double[] secondWeights = gaussKronrodPoint.SecondWeights;
			double num6;
			if ((num3 & 1) == 1)
			{
				double num5 = f(0.0);
				num6 = num5 * weights[0];
				num4 += num5 * secondWeights[0];
			}
			else
			{
				double num5 = f(0.0);
				num6 = num5 * weights[0];
				num = 1;
				num2 = 2;
			}
			double num7 = Math.Abs(num6);
			for (int i = num; i < abscissas.Length; i += 2)
			{
				double num5 = f(abscissas[i]);
				double num8 = f(0.0 - abscissas[i]);
				num6 += (num5 + num8) * weights[i];
				num7 += (Math.Abs(num5) + Math.Abs(num8)) * weights[i];
				num4 += (num5 + num8) * secondWeights[i / 2];
			}
			for (int j = num2; j < abscissas.Length; j += 2)
			{
				double num5 = f(abscissas[j]);
				double num8 = f(0.0 - abscissas[j]);
				num6 += (num5 + num8) * weights[j];
				num7 += (Math.Abs(num5) + Math.Abs(num8)) * weights[j];
			}
			pL1 = num7;
			error = Math.Max(Math.Abs(num6 - num4), Math.Abs(num6 * Precision.MachineEpsilon * 2.0));
			return num6;
		}

		private static Complex contour_integrate_non_adaptive_m1_1(Func<double, Complex> f, out double error, out double pL1, GaussPointPair gaussKronrodPoint)
		{
			int num = 2;
			int num2 = 1;
			int number = (gaussKronrodPoint.Order - 1) / 2;
			Complex complex = default(Complex);
			double[] abscissas = gaussKronrodPoint.Abscissas;
			double[] weights = gaussKronrodPoint.Weights;
			double[] secondWeights = gaussKronrodPoint.SecondWeights;
			Complex complex3;
			if (number.IsOdd())
			{
				Complex complex2 = f(0.0);
				complex3 = complex2 * weights[0];
				complex += complex2 * secondWeights[0];
			}
			else
			{
				Complex complex2 = f(0.0);
				complex3 = complex2 * weights[0];
				num = 1;
				num2 = 2;
			}
			double num3 = Complex.Abs(complex3);
			for (int i = num; i < abscissas.Length; i += 2)
			{
				Complex complex2 = f(abscissas[i]);
				Complex complex4 = f(0.0 - abscissas[i]);
				complex3 += (complex2 + complex4) * weights[i];
				num3 += (Complex.Abs(complex2) + Complex.Abs(complex4)) * weights[i];
				complex += (complex2 + complex4) * secondWeights[i / 2];
			}
			for (int j = num2; j < abscissas.Length; j += 2)
			{
				Complex complex2 = f(abscissas[j]);
				Complex complex4 = f(0.0 - abscissas[j]);
				complex3 += (complex2 + complex4) * weights[j];
				num3 += (Complex.Abs(complex2) + Complex.Abs(complex4)) * weights[j];
			}
			pL1 = num3;
			error = Math.Max(Complex.Abs(complex3 - complex), Complex.Abs(complex3 * Precision.MachineEpsilon * 2.0));
			return complex3;
		}

		private static double recursive_adaptive_integrate(Func<double, double> f, double a, double b, int maxLevels, double relTol, double absTol, out double error, out double L1, GaussPointPair gaussKronrodPoint)
		{
			double mean = (b + a) / 2.0;
			double scale = (b - a) / 2.0;
			double error2;
			double num = integrate_non_adaptive_m1_1((double x) => f(scale * x + mean), out error2, out L1, gaussKronrodPoint);
			double num2 = scale * num;
			double num3 = Math.Abs(num2 * relTol);
			if (absTol == 0.0)
			{
				absTol = num3;
			}
			if (maxLevels > 0 && num3 < error2 && absTol < error2)
			{
				double num4 = (a + b) / 2.0;
				num2 = recursive_adaptive_integrate(f, a, num4, maxLevels - 1, relTol, absTol / 2.0, out error, out L1, gaussKronrodPoint);
				num2 += recursive_adaptive_integrate(f, num4, b, maxLevels - 1, relTol, absTol / 2.0, out error2, out var L2, gaussKronrodPoint);
				error += error2;
				L1 += L2;
				return num2;
			}
			L1 *= scale;
			error = error2;
			return num2;
		}

		private static Complex contour_recursive_adaptive_integrate(Func<double, Complex> f, double a, double b, int maxLevels, double relTol, double absTol, out double error, out double L1, GaussPointPair gaussKronrodPoint)
		{
			double mean = (b + a) / 2.0;
			double scale = (b - a) / 2.0;
			double error2;
			Complex complex = contour_integrate_non_adaptive_m1_1((double x) => f(scale * x + mean), out error2, out L1, gaussKronrodPoint);
			Complex complex2 = scale * complex;
			double num = Complex.Abs(complex2 * relTol);
			if (absTol == 0.0)
			{
				absTol = num;
			}
			if (maxLevels > 0 && num < error2 && absTol < error2)
			{
				double num2 = (a + b) / 2.0;
				complex2 = contour_recursive_adaptive_integrate(f, a, num2, maxLevels - 1, relTol, absTol / 2.0, out error, out L1, gaussKronrodPoint);
				complex2 += contour_recursive_adaptive_integrate(f, num2, b, maxLevels - 1, relTol, absTol / 2.0, out error2, out var L2, gaussKronrodPoint);
				error += error2;
				L1 += L2;
				return complex2;
			}
			L1 *= scale;
			error = error2;
			return complex2;
		}
	}
}
