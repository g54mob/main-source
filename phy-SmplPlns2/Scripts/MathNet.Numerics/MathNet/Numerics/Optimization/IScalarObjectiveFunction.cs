namespace MathNet.Numerics.Optimization
{
	public interface IScalarObjectiveFunction
	{
		bool IsDerivativeSupported { get; }

		bool IsSecondDerivativeSupported { get; }

		IScalarObjectiveFunctionEvaluation Evaluate(double point);
	}
}
