using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class GradientHessianObjectiveFunction : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private readonly Func<Vector<double>, (double, Vector<double>, Matrix<double>)> _function;

		public bool IsGradientSupported => true;

		public bool IsHessianSupported => true;

		public Vector<double> Point { get; private set; }

		public double Value { get; private set; }

		public Vector<double> Gradient { get; private set; }

		public Matrix<double> Hessian { get; private set; }

		public GradientHessianObjectiveFunction(Func<Vector<double>, (double, Vector<double>, Matrix<double>)> function)
		{
			_function = function;
		}

		public IObjectiveFunction CreateNew()
		{
			return new GradientHessianObjectiveFunction(_function);
		}

		public IObjectiveFunction Fork()
		{
			return new GradientHessianObjectiveFunction(_function)
			{
				Point = Point,
				Value = Value,
				Gradient = Gradient,
				Hessian = Hessian
			};
		}

		public void EvaluateAt(Vector<double> point)
		{
			Point = point;
			(Value, Gradient, Hessian) = _function(point);
		}
	}
}
