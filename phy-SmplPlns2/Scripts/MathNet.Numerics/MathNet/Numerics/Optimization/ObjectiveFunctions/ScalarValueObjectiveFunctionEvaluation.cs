using System;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class ScalarValueObjectiveFunctionEvaluation : IScalarObjectiveFunctionEvaluation
	{
		public double Point { get; }

		public double Value { get; }

		public double Derivative
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public double SecondDerivative
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public ScalarValueObjectiveFunctionEvaluation(double point, double value)
		{
			Point = point;
			Value = value;
		}
	}
}
