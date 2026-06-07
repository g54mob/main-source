using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public interface IObjectiveModelEvaluation
	{
		Vector<double> ObservedY { get; }

		Matrix<double> Weights { get; }

		Vector<double> ModelValues { get; }

		Vector<double> Point { get; }

		double Value { get; }

		Vector<double> Gradient { get; }

		Matrix<double> Hessian { get; }

		int FunctionEvaluations { get; set; }

		int JacobianEvaluations { get; set; }

		int DegreeOfFreedom { get; }

		bool IsGradientSupported { get; }

		bool IsHessianSupported { get; }

		IObjectiveModel CreateNew();
	}
}
