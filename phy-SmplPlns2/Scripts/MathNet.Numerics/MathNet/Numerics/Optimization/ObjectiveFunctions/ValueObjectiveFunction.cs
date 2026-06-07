using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class ValueObjectiveFunction : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private readonly Func<Vector<double>, double> _function;

		public bool IsGradientSupported => false;

		public bool IsHessianSupported => false;

		public Vector<double> Point { get; private set; }

		public double Value { get; private set; }

		public Matrix<double> Hessian
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public Vector<double> Gradient
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public ValueObjectiveFunction(Func<Vector<double>, double> function)
		{
			_function = function;
		}

		public IObjectiveFunction CreateNew()
		{
			return new ValueObjectiveFunction(_function);
		}

		public IObjectiveFunction Fork()
		{
			return new ValueObjectiveFunction(_function)
			{
				Point = Point,
				Value = Value
			};
		}

		public void EvaluateAt(Vector<double> point)
		{
			Point = point;
			Value = _function(point);
		}
	}
}
