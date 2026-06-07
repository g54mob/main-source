using System;

namespace MathNet.Numerics
{
	public static class DifferIntegrate
	{
		public static double DoubleExponential(Func<double, double> f, double x, double order, double x0 = 0.0, double targetAbsoluteError = 1E-10)
		{
			if (Math.Abs(order) < double.Epsilon)
			{
				return f(x);
			}
			if (order > 0.0 && Math.Abs(order - (double)(int)order) < double.Epsilon)
			{
				return Differentiate.Derivative(f, x, (int)order);
			}
			int num = (int)Math.Ceiling(order) + 1;
			if (num < 1)
			{
				num = 1;
			}
			double r = (double)num - order - 1.0;
			double num2 = Differentiate.Derivative((double v) => Integrate.DoubleExponential((double t) => Math.Pow(v - t, r) * f(t), x0, v, targetAbsoluteError), x, num);
			double num3 = SpecialFunctions.Gamma((double)num - order);
			return num2 / num3;
		}

		public static double GaussLegendre(Func<double, double> f, double x, double order, double x0 = 0.0, int gaussLegendrePoints = 128)
		{
			if (Math.Abs(order) < double.Epsilon)
			{
				return f(x);
			}
			if (order > 0.0 && Math.Abs(order - (double)(int)order) < double.Epsilon)
			{
				return Differentiate.Derivative(f, x, (int)order);
			}
			int num = (int)Math.Ceiling(order) + 1;
			if (num < 1)
			{
				num = 1;
			}
			double r = (double)num - order - 1.0;
			double num2 = Differentiate.Derivative((double v) => Integrate.GaussLegendre((double t) => Math.Pow(v - t, r) * f(t), x0, v, gaussLegendrePoints), x, num);
			double num3 = SpecialFunctions.Gamma((double)num - order);
			return num2 / num3;
		}

		public static double GaussKronrod(Func<double, double> f, double x, double order, double x0 = 0.0, double targetRelativeError = 1E-10, int gaussKronrodPoints = 15)
		{
			if (Math.Abs(order) < double.Epsilon)
			{
				return f(x);
			}
			if (order > 0.0 && Math.Abs(order - (double)(int)order) < double.Epsilon)
			{
				return Differentiate.Derivative(f, x, (int)order);
			}
			int num = (int)Math.Ceiling(order) + 1;
			if (num < 1)
			{
				num = 1;
			}
			double r = (double)num - order - 1.0;
			double num2 = Differentiate.Derivative((double v) => Integrate.GaussKronrod((double t) => Math.Pow(v - t, r) * f(t), x0, v, targetRelativeError, 15, gaussKronrodPoints), x, num);
			double num3 = SpecialFunctions.Gamma((double)num - order);
			return num2 / num3;
		}
	}
}
