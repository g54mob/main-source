using System;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class ScalarValueObjectiveFunction : IScalarObjectiveFunction
	{
		public Func<double, double> Objective { get; }

		public bool IsDerivativeSupported => false;

		public bool IsSecondDerivativeSupported => false;

		public ScalarValueObjectiveFunction(Func<double, double> objective)
		{
			Objective = objective;
		}

		public IScalarObjectiveFunctionEvaluation Evaluate(double point)
		{
			return new ScalarValueObjectiveFunctionEvaluation(point, Objective(point));
		}
	}
}
