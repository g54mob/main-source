using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public interface IObjectiveFunctionEvaluation
	{
		Vector<double> Point { get; }

		double Value { get; }

		bool IsGradientSupported { get; }

		Vector<double> Gradient { get; }

		bool IsHessianSupported { get; }

		Matrix<double> Hessian { get; }

		IObjectiveFunction CreateNew();
	}
}
