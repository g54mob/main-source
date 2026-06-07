using System;
using MathNet.Numerics.Differentiation;

namespace MathNet.Numerics
{
	public static class Differentiate
	{
		public static NumericalDerivative Points(int points, int center)
		{
			return new NumericalDerivative(points, center);
		}

		public static NumericalDerivative Order(int order)
		{
			int num = order + (order.IsEven() ? 1 : 2);
			return new NumericalDerivative(num, num / 2);
		}

		public static double Derivative(Func<double, double> f, double x, int order)
		{
			return Order(order).EvaluateDerivative(f, x, order);
		}

		public static Func<double, double> DerivativeFunc(Func<double, double> f, int order)
		{
			return Order(order).CreateDerivativeFunctionHandle(f, order);
		}

		public static double FirstDerivative(Func<double, double> f, double x)
		{
			return Order(1).EvaluateDerivative(f, x, 1);
		}

		public static Func<double, double> FirstDerivativeFunc(Func<double, double> f)
		{
			return Order(1).CreateDerivativeFunctionHandle(f, 1);
		}

		public static double SecondDerivative(Func<double, double> f, double x)
		{
			return Order(2).EvaluateDerivative(f, x, 2);
		}

		public static Func<double, double> SecondDerivativeFunc(Func<double, double> f)
		{
			return Order(2).CreateDerivativeFunctionHandle(f, 2);
		}

		public static double PartialDerivative(Func<double[], double> f, double[] x, int parameterIndex, int order)
		{
			return Order(order).EvaluatePartialDerivative(f, x, parameterIndex, order);
		}

		public static Func<double[], double> PartialDerivativeFunc(Func<double[], double> f, int parameterIndex, int order)
		{
			return Order(order).CreatePartialDerivativeFunctionHandle(f, parameterIndex, order);
		}

		public static double FirstPartialDerivative(Func<double[], double> f, double[] x, int parameterIndex)
		{
			return PartialDerivative(f, x, parameterIndex, 1);
		}

		public static Func<double[], double> FirstPartialDerivativeFunc(Func<double[], double> f, int parameterIndex)
		{
			return PartialDerivativeFunc(f, parameterIndex, 1);
		}

		public static double PartialDerivative2(Func<double, double, double> f, double x, double y, int parameterIndex, int order)
		{
			return Order(order).EvaluatePartialDerivative((double[] array) => f(array[0], array[1]), new double[2] { x, y }, parameterIndex, order);
		}

		public static Func<double, double, double> PartialDerivative2Func(Func<double, double, double> f, int parameterIndex, int order)
		{
			Func<double[], double> handle = Order(order).CreatePartialDerivativeFunctionHandle((double[] array) => f(array[0], array[1]), parameterIndex, order);
			return (double x, double y) => handle(new double[2] { x, y });
		}

		public static double FirstPartialDerivative2(Func<double, double, double> f, double x, double y, int parameterIndex)
		{
			return PartialDerivative2(f, x, y, parameterIndex, 1);
		}

		public static Func<double, double, double> FirstPartialDerivative2Func(Func<double, double, double> f, int parameterIndex)
		{
			return PartialDerivative2Func(f, parameterIndex, 1);
		}
	}
}
