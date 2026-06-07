using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class GradientObjectiveFunction : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private readonly Func<Vector<double>, (double, Vector<double>)> _function;

		public bool IsGradientSupported => true;

		public bool IsHessianSupported => false;

		public Vector<double> Point { get; private set; }

		public double Value { get; private set; }

		public Vector<double> Gradient { get; private set; }

		public Matrix<double> Hessian
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public GradientObjectiveFunction(Func<Vector<double>, (double, Vector<double>)> function)
		{
			_function = function;
		}

		public IObjectiveFunction CreateNew()
		{
			return new GradientObjectiveFunction(_function);
		}

		public IObjectiveFunction Fork()
		{
			return new GradientObjectiveFunction(_function)
			{
				Point = Point,
				Value = Value,
				Gradient = Gradient
			};
		}

		public void EvaluateAt(Vector<double> point)
		{
			Point = point;
			(Value, Gradient) = _function(point);
		}
	}
}
