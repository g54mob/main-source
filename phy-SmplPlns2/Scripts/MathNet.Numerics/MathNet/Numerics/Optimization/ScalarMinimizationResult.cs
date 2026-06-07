namespace MathNet.Numerics.Optimization
{
	public class ScalarMinimizationResult
	{
		public double MinimizingPoint => FunctionInfoAtMinimum.Point;

		public IScalarObjectiveFunctionEvaluation FunctionInfoAtMinimum { get; }

		public int Iterations { get; }

		public ExitCondition ReasonForExit { get; }

		public ScalarMinimizationResult(IScalarObjectiveFunctionEvaluation functionInfo, int iterations, ExitCondition reasonForExit)
		{
			FunctionInfoAtMinimum = functionInfo;
			Iterations = iterations;
			ReasonForExit = reasonForExit;
		}
	}
}
