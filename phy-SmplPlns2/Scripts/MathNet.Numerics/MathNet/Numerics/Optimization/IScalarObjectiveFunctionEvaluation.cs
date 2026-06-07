namespace MathNet.Numerics.Optimization
{
	public interface IScalarObjectiveFunctionEvaluation
	{
		double Point { get; }

		double Value { get; }

		double Derivative { get; }

		double SecondDerivative { get; }
	}
}
