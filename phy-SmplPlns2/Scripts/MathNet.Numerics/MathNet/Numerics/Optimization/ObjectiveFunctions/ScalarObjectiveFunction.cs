using System;

namespace MathNet.Numerics.Optimization.ObjectiveFunctions
{
	internal class ScalarObjectiveFunction : IScalarObjectiveFunction
	{
		public Func<double, double> Objective { get; }

		public Func<double, double> Derivative { get; }

		public Func<double, double> SecondDerivative { get; }

		public bool IsDerivativeSupported => Derivative != null;

		public bool IsSecondDerivativeSupported => SecondDerivative != null;

		public ScalarObjectiveFunction(Func<double, double> objective)
		{
			Objective = objective;
			Derivative = null;
			SecondDerivative = null;
		}

		public ScalarObjectiveFunction(Func<double, double> objective, Func<double, double> derivative)
		{
			Objective = objective;
			Derivative = derivative;
			SecondDerivative = null;
		}

		public ScalarObjectiveFunction(Func<double, double> objective, Func<double, double> derivative, Func<double, double> secondDerivative)
		{
			Objective = objective;
			Derivative = derivative;
			SecondDerivative = secondDerivative;
		}

		public IScalarObjectiveFunctionEvaluation Evaluate(double point)
		{
			return new LazyScalarObjectiveFunctionEvaluation(this, point);
		}
	}
}
