using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class HessianObjectiveFunction : IObjectiveFunction, IObjectiveFunctionEvaluation
	{
		private readonly Func<Vector<double>, (double, Matrix<double>)> _function;

		public bool IsGradientSupported => false;

		public bool IsHessianSupported => true;

		public Vector<double> Point { get; private set; }

		public double Value { get; private set; }

		public Matrix<double> Hessian { get; private set; }

		public Vector<double> Gradient
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public HessianObjectiveFunction(Func<Vector<double>, (double, Matrix<double>)> function)
		{
			_function = function;
		}

		public IObjectiveFunction CreateNew()
		{
			return new HessianObjectiveFunction(_function);
		}

		public IObjectiveFunction Fork()
		{
			return new HessianObjectiveFunction(_function)
			{
				Point = Point,
				Value = Value,
				Hessian = Hessian
			};
		}

		public void EvaluateAt(Vector<double> point)
		{
			Point = point;
			(Value, Hessian) = _function(point);
		}
	}
}
