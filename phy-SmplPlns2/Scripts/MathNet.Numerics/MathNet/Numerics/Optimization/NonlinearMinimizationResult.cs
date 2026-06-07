using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public class NonlinearMinimizationResult
	{
		public IObjectiveModel ModelInfoAtMinimum { get; }

		public Vector<double> MinimizingPoint => ModelInfoAtMinimum.Point;

		public Vector<double> StandardErrors { get; private set; }

		public Vector<double> MinimizedValues => ModelInfoAtMinimum.ModelValues;

		public Matrix<double> Covariance { get; private set; }

		public Matrix<double> Correlation { get; private set; }

		public int Iterations { get; }

		public ExitCondition ReasonForExit { get; }

		public NonlinearMinimizationResult(IObjectiveModel modelInfo, int iterations, ExitCondition reasonForExit)
		{
			ModelInfoAtMinimum = modelInfo;
			Iterations = iterations;
			ReasonForExit = reasonForExit;
			EvaluateCovariance(modelInfo);
		}

		private void EvaluateCovariance(IObjectiveModel objective)
		{
			objective.EvaluateAt(objective.Point);
			Matrix<double> hessian = objective.Hessian;
			if (hessian == null || objective.DegreeOfFreedom < 1)
			{
				Covariance = null;
				Correlation = null;
				StandardErrors = null;
				return;
			}
			Covariance = hessian.PseudoInverse() * objective.Value / objective.DegreeOfFreedom;
			if (Covariance != null)
			{
				StandardErrors = Covariance.Diagonal().PointwiseSqrt();
				Matrix<double> matrix = Covariance.Clone();
				Vector<double> vector = matrix.Diagonal().PointwiseSqrt();
				Matrix<double> divisor = vector.OuterProduct(vector);
				Correlation = matrix.PointwiseDivide(divisor);
			}
			else
			{
				StandardErrors = null;
				Correlation = null;
			}
		}
	}
}
