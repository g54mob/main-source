using System;

namespace MathNet.Numerics.Optimization
{
	public class EvaluationException : OptimizationException
	{
		public IObjectiveFunctionEvaluation ObjectiveFunction { get; }

		public EvaluationException(string message, IObjectiveFunctionEvaluation eval)
			: base(message)
		{
			ObjectiveFunction = eval;
		}

		public EvaluationException(string message, IObjectiveFunctionEvaluation eval, Exception innerException)
			: base(message, innerException)
		{
			ObjectiveFunction = eval;
		}
	}
}
