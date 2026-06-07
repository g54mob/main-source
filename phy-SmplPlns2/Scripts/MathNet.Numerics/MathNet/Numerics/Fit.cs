using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics
{
	public static class Fit
	{
		public static (double A, double B) Line(double[] x, double[] y)
		{
			return SimpleRegression.Fit(x, y);
		}

		public static Func<double, double> LineFunc(double[] x, double[] y)
		{
			var (intercept, slope) = SimpleRegression.Fit(x, y);
			return (double z) => intercept + slope * z;
		}

		public static double LineThroughOrigin(double[] x, double[] y)
		{
			return SimpleRegression.FitThroughOrigin(x, y);
		}

		public static Func<double, double> LineThroughOriginFunc(double[] x, double[] y)
		{
			double slope = SimpleRegression.FitThroughOrigin(x, y);
			return (double z) => slope * z;
		}

		public static (double A, double R) Exponential(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			double[] y2 = Generate.Map(y, Math.Log);
			double[] array = LinearCombination(x, y2, method, (double _) => 1.0, (double t) => t);
			return (A: Math.Exp(array[0]), R: array[1]);
		}

		public static Func<double, double> ExponentialFunc(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			var (a, r) = Exponential(x, y, method);
			return (double z) => a * Math.Exp(r * z);
		}

		public static (double A, double B) Logarithm(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			double[] array = LinearCombination(Generate.Map(x, Math.Log), y, method, (double _) => 1.0, (double t) => t);
			return (A: array[0], B: array[1]);
		}

		public static Func<double, double> LogarithmFunc(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			var (a, b) = Logarithm(x, y, method);
			return (double z) => a + b * Math.Log(z);
		}

		public static (double A, double B) Power(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			double[] y2 = Generate.Map(y, Math.Log);
			double[] array = LinearCombination(x, y2, method, (double _) => 1.0, Math.Log);
			return (A: Math.Exp(array[0]), B: array[1]);
		}

		public static Func<double, double> PowerFunc(double[] x, double[] y, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			var (a, b) = Power(x, y, method);
			return (double z) => a * Math.Pow(z, b);
		}

		public static double[] Polynomial(double[] x, double[] y, int order, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			return MultipleRegression.DirectMethod(Matrix<double>.Build.Dense(x.Length, order + 1, (int i, int j) => Math.Pow(x[i], j)), Vector<double>.Build.Dense(y), method).ToArray();
		}

		public static Func<double, double> PolynomialFunc(double[] x, double[] y, int order, DirectRegressionMethod method = DirectRegressionMethod.QR)
		{
			double[] parameters = Polynomial(x, y, order, method);
			return (double z) => MathNet.Numerics.Polynomial.Evaluate(z, parameters);
		}

		public static double[] PolynomialWeighted(double[] x, double[] y, double[] w, int order)
		{
			return WeightedRegression.Weighted(Matrix<double>.Build.Dense(x.Length, order + 1, (int i, int j) => Math.Pow(x[i], j)), Vector<double>.Build.Dense(y), Matrix<double>.Build.Diagonal(w)).ToArray();
		}

		public static double[] LinearCombination(double[] x, double[] y, params Func<double, double>[] functions)
		{
			return MultipleRegression.QR(Matrix<double>.Build.Dense(x.Length, functions.Length, (int i, int j) => functions[j](x[i])), Vector<double>.Build.Dense(y)).ToArray();
		}

		public static Func<double, double> LinearCombinationFunc(double[] x, double[] y, params Func<double, double>[] functions)
		{
			double[] parameters = LinearCombination(x, y, functions);
			return (double z) => functions.Zip(parameters, (Func<double, double> f, double p) => p * f(z)).Sum();
		}

		public static double[] LinearCombination(double[] x, double[] y, DirectRegressionMethod method, params Func<double, double>[] functions)
		{
			return MultipleRegression.DirectMethod(Matrix<double>.Build.Dense(x.Length, functions.Length, (int i, int j) => functions[j](x[i])), Vector<double>.Build.Dense(y), method).ToArray();
		}

		public static Func<double, double> LinearCombinationFunc(double[] x, double[] y, DirectRegressionMethod method, params Func<double, double>[] functions)
		{
			double[] parameters = LinearCombination(x, y, method, functions);
			return (double z) => functions.Zip(parameters, (Func<double, double> f, double p) => p * f(z)).Sum();
		}

		public static double[] MultiDim(double[][] x, double[] y, bool intercept = false, DirectRegressionMethod method = DirectRegressionMethod.NormalEquations)
		{
			return MultipleRegression.DirectMethod(x, y, intercept, method);
		}

		public static Func<double[], double> MultiDimFunc(double[][] x, double[] y, bool intercept = false, DirectRegressionMethod method = DirectRegressionMethod.NormalEquations)
		{
			double[] parameters = MultipleRegression.DirectMethod(x, y, intercept, method);
			return (double[] z) => LinearAlgebraControl.Provider.DotProduct(parameters, z);
		}

		public static double[] MultiDimWeighted(double[][] x, double[] y, double[] w)
		{
			return WeightedRegression.Weighted(x, y, w);
		}

		public static double[] LinearMultiDim(double[][] x, double[] y, params Func<double[], double>[] functions)
		{
			return MultipleRegression.QR(Matrix<double>.Build.Dense(x.Length, functions.Length, (int i, int j) => functions[j](x[i])), Vector<double>.Build.Dense(y)).ToArray();
		}

		public static Func<double[], double> LinearMultiDimFunc(double[][] x, double[] y, params Func<double[], double>[] functions)
		{
			double[] parameters = LinearMultiDim(x, y, functions);
			return (double[] z) => functions.Zip(parameters, (Func<double[], double> f, double p) => p * f(z)).Sum();
		}

		public static double[] LinearMultiDim(double[][] x, double[] y, DirectRegressionMethod method, params Func<double[], double>[] functions)
		{
			return MultipleRegression.DirectMethod(Matrix<double>.Build.Dense(x.Length, functions.Length, (int i, int j) => functions[j](x[i])), Vector<double>.Build.Dense(y), method).ToArray();
		}

		public static Func<double[], double> LinearMultiDimFunc(double[][] x, double[] y, DirectRegressionMethod method, params Func<double[], double>[] functions)
		{
			double[] parameters = LinearMultiDim(x, y, method, functions);
			return (double[] z) => functions.Zip(parameters, (Func<double[], double> f, double p) => p * f(z)).Sum();
		}

		public static double[] LinearGeneric<T>(T[] x, double[] y, params Func<T, double>[] functions)
		{
			return MultipleRegression.QR(Matrix<double>.Build.Dense(x.Length, functions.Length, (int i, int j) => functions[j](x[i])), Vector<double>.Build.Dense(y)).ToArray();
		}

		public static Func<T, double> LinearGenericFunc<T>(T[] x, double[] y, params Func<T, double>[] functions)
		{
			double[] parameters = LinearGeneric(x, y, functions);
			return (T z) => functions.Zip(parameters, (Func<T, double> f, double p) => p * f(z)).Sum();
		}

		public static double[] LinearGeneric<T>(T[] x, double[] y, DirectRegressionMethod method, params Func<T, double>[] functions)
		{
			return MultipleRegression.DirectMethod(Matrix<double>.Build.Dense(x.Length, functions.Length, (int i, int j) => functions[j](x[i])), Vector<double>.Build.Dense(y), method).ToArray();
		}

		public static Func<T, double> LinearGenericFunc<T>(T[] x, double[] y, DirectRegressionMethod method, params Func<T, double>[] functions)
		{
			double[] parameters = LinearGeneric(x, y, method, functions);
			return (T z) => functions.Zip(parameters, (Func<T, double> f, double p) => p * f(z)).Sum();
		}

		public static double Curve(double[] x, double[] y, Func<double, double, double> f, double initialGuess, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return FindMinimum.OfScalarFunction((double p) => Distance.Euclidean(Generate.Map(x, (double t) => f(p, t)), y), initialGuess, tolerance, maxIterations);
		}

		public static (double P0, double P1) Curve(double[] x, double[] y, Func<double, double, double, double> f, double initialGuess0, double initialGuess1, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return FindMinimum.OfFunction((double p0, double p1) => Distance.Euclidean(Generate.Map(x, (double t) => f(p0, p1, t)), y), initialGuess0, initialGuess1, tolerance, maxIterations);
		}

		public static (double P0, double P1, double P2) Curve(double[] x, double[] y, Func<double, double, double, double, double> f, double initialGuess0, double initialGuess1, double initialGuess2, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return FindMinimum.OfFunction((double p0, double p1, double p2) => Distance.Euclidean(Generate.Map(x, (double t) => f(p0, p1, p2, t)), y), initialGuess0, initialGuess1, initialGuess2, tolerance, maxIterations);
		}

		public static (double P0, double P1, double P2, double P3) Curve(double[] x, double[] y, Func<double, double, double, double, double, double> f, double initialGuess0, double initialGuess1, double initialGuess2, double initialGuess3, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return FindMinimum.OfFunction((double p0, double p1, double p2, double p3) => Distance.Euclidean(Generate.Map(x, (double t) => f(p0, p1, p2, p3, t)), y), initialGuess0, initialGuess1, initialGuess2, initialGuess3, tolerance, maxIterations);
		}

		public static (double P0, double P1, double P2, double P3, double P4) Curve(double[] x, double[] y, Func<double, double, double, double, double, double, double> f, double initialGuess0, double initialGuess1, double initialGuess2, double initialGuess3, double initialGuess4, double tolerance = 1E-08, int maxIterations = 1000)
		{
			return FindMinimum.OfFunction((double p0, double p1, double p2, double p3, double p4) => Distance.Euclidean(Generate.Map(x, (double t) => f(p0, p1, p2, p3, p4, t)), y), initialGuess0, initialGuess1, initialGuess2, initialGuess3, initialGuess4, tolerance, maxIterations);
		}

		public static Func<double, double> CurveFunc(double[] x, double[] y, Func<double, double, double> f, double initialGuess, double tolerance = 1E-08, int maxIterations = 1000)
		{
			double parameters = Curve(x, y, f, initialGuess, tolerance, maxIterations);
			return (double z) => f(parameters, z);
		}

		public static Func<double, double> CurveFunc(double[] x, double[] y, Func<double, double, double, double> f, double initialGuess0, double initialGuess1, double tolerance = 1E-08, int maxIterations = 1000)
		{
			var (p0, p1) = Curve(x, y, f, initialGuess0, initialGuess1, tolerance, maxIterations);
			return (double z) => f(p0, p1, z);
		}

		public static Func<double, double> CurveFunc(double[] x, double[] y, Func<double, double, double, double, double> f, double initialGuess0, double initialGuess1, double initialGuess2, double tolerance = 1E-08, int maxIterations = 1000)
		{
			var (p0, p1, p2) = Curve(x, y, f, initialGuess0, initialGuess1, initialGuess2, tolerance, maxIterations);
			return (double z) => f(p0, p1, p2, z);
		}

		public static Func<double, double> CurveFunc(double[] x, double[] y, Func<double, double, double, double, double, double> f, double initialGuess0, double initialGuess1, double initialGuess2, double initialGuess3, double tolerance = 1E-08, int maxIterations = 1000)
		{
			var (p0, p1, p2, p3) = Curve(x, y, f, initialGuess0, initialGuess1, initialGuess2, initialGuess3, tolerance, maxIterations);
			return (double z) => f(p0, p1, p2, p3, z);
		}

		public static Func<double, double> CurveFunc(double[] x, double[] y, Func<double, double, double, double, double, double, double> f, double initialGuess0, double initialGuess1, double initialGuess2, double initialGuess3, double initialGuess4, double tolerance = 1E-08, int maxIterations = 1000)
		{
			var (p0, p1, p2, p3, p4) = Curve(x, y, f, initialGuess0, initialGuess1, initialGuess2, initialGuess3, initialGuess4, tolerance, maxIterations);
			return (double z) => f(p0, p1, p2, p3, p4, z);
		}
	}
}
