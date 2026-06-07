using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public interface IObjectiveFunction : IObjectiveFunctionEvaluation
	{
		void EvaluateAt(Vector<double> point);

		IObjectiveFunction Fork();
	}
}
