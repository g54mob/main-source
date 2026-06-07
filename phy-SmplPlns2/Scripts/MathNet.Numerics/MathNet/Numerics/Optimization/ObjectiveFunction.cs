using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization.ObjectiveFunctions;

namespace MathNet.Numerics.Optimization
{
	public static class ObjectiveFunction
	{
		public static IObjectiveFunction Value(Func<Vector<double>, double> function)
		{
			return new ValueObjectiveFunction(function);
		}

		public static IObjectiveFunction Gradient(Func<Vector<double>, (double, Vector<double>)> function)
		{
			return new GradientObjectiveFunction(function);
		}

		public static IObjectiveFunction Gradient(Func<Vector<double>, double> function, Func<Vector<double>, Vector<double>> gradient)
		{
			return new LazyObjectiveFunction(function, gradient);
		}

		public static IObjectiveFunction Hessian(Func<Vector<double>, (double, Matrix<double>)> function)
		{
			return new HessianObjectiveFunction(function);
		}

		public static IObjectiveFunction Hessian(Func<Vector<double>, double> function, Func<Vector<double>, Matrix<double>> hessian)
		{
			return new LazyObjectiveFunction(function, null, hessian);
		}

		public static IObjectiveFunction GradientHessian(Func<Vector<double>, (double, Vector<double>, Matrix<double>)> function)
		{
			return new GradientHessianObjectiveFunction(function);
		}

		public static IObjectiveFunction GradientHessian(Func<Vector<double>, double> function, Func<Vector<double>, Vector<double>> gradient, Func<Vector<double>, Matrix<double>> hessian)
		{
			return new LazyObjectiveFunction(function, gradient, hessian);
		}

		public static IScalarObjectiveFunction ScalarValue(Func<double, double> function)
		{
			return new ScalarValueObjectiveFunction(function);
		}

		public static IScalarObjectiveFunction ScalarDerivative(Func<double, double> function, Func<double, double> derivative)
		{
			return new ScalarObjectiveFunction(function, derivative);
		}

		public static IScalarObjectiveFunction ScalarSecondDerivative(Func<double, double> function, Func<double, double> derivative, Func<double, double> secondDerivative)
		{
			return new ScalarObjectiveFunction(function, derivative, secondDerivative);
		}

		public static IObjectiveModel NonlinearModel(Func<Vector<double>, Vector<double>, Vector<double>> function, Func<Vector<double>, Vector<double>, Matrix<double>> derivatives, Vector<double> observedX, Vector<double> observedY, Vector<double> weight = null)
		{
			NonlinearObjectiveFunction nonlinearObjectiveFunction = new NonlinearObjectiveFunction(function, derivatives);
			nonlinearObjectiveFunction.SetObserved(observedX, observedY, weight);
			return nonlinearObjectiveFunction;
		}

		public static IObjectiveModel NonlinearModel(Func<Vector<double>, Vector<double>, Vector<double>> function, Vector<double> observedX, Vector<double> observedY, Vector<double> weight = null, int accuracyOrder = 2)
		{
			NonlinearObjectiveFunction nonlinearObjectiveFunction = new NonlinearObjectiveFunction(function, null, accuracyOrder);
			nonlinearObjectiveFunction.SetObserved(observedX, observedY, weight);
			return nonlinearObjectiveFunction;
		}

		public static IObjectiveModel NonlinearModel(Func<Vector<double>, double, double> function, Func<Vector<double>, double, Vector<double>> derivatives, Vector<double> observedX, Vector<double> observedY, Vector<double> weight = null)
		{
			NonlinearObjectiveFunction nonlinearObjectiveFunction = new NonlinearObjectiveFunction(Func, Prime);
			nonlinearObjectiveFunction.SetObserved(observedX, observedY, weight);
			return nonlinearObjectiveFunction;
			Vector<double> Func(Vector<double> point, Vector<double> x)
			{
				Vector<double> vector = CreateVector.Dense<double>(x.Count);
				for (int i = 0; i < x.Count; i++)
				{
					vector[i] = function(point, x[i]);
				}
				return vector;
			}
			Matrix<double> Prime(Vector<double> point, Vector<double> x)
			{
				Matrix<double> matrix = CreateMatrix.Dense<double>(x.Count, point.Count);
				for (int i = 0; i < x.Count; i++)
				{
					matrix.SetRow(i, derivatives(point, x[i]));
				}
				return matrix;
			}
		}

		public static IObjectiveModel NonlinearModel(Func<Vector<double>, double, double> function, Vector<double> observedX, Vector<double> observedY, Vector<double> weight = null, int accuracyOrder = 2)
		{
			NonlinearObjectiveFunction nonlinearObjectiveFunction = new NonlinearObjectiveFunction(Func, null, accuracyOrder);
			nonlinearObjectiveFunction.SetObserved(observedX, observedY, weight);
			return nonlinearObjectiveFunction;
			Vector<double> Func(Vector<double> point, Vector<double> x)
			{
				Vector<double> vector = CreateVector.Dense<double>(x.Count);
				for (int i = 0; i < x.Count; i++)
				{
					vector[i] = function(point, x[i]);
				}
				return vector;
			}
		}

		public static IObjectiveFunction NonlinearFunction(Func<Vector<double>, Vector<double>, Vector<double>> function, Func<Vector<double>, Vector<double>, Matrix<double>> derivatives, Vector<double> observedX, Vector<double> observedY, Vector<double> weight = null)
		{
			NonlinearObjectiveFunction nonlinearObjectiveFunction = new NonlinearObjectiveFunction(function, derivatives);
			nonlinearObjectiveFunction.SetObserved(observedX, observedY, weight);
			return nonlinearObjectiveFunction.ToObjectiveFunction();
		}

		public static IObjectiveFunction NonlinearFunction(Func<Vector<double>, Vector<double>, Vector<double>> function, Vector<double> observedX, Vector<double> observedY, Vector<double> weight = null, int accuracyOrder = 2)
		{
			NonlinearObjectiveFunction nonlinearObjectiveFunction = new NonlinearObjectiveFunction(function, null, accuracyOrder);
			nonlinearObjectiveFunction.SetObserved(observedX, observedY, weight);
			return nonlinearObjectiveFunction.ToObjectiveFunction();
		}
	}
}
