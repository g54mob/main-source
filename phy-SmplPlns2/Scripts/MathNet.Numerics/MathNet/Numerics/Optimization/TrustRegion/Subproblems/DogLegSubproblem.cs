using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.TrustRegion.Subproblems
{
	internal class DogLegSubproblem : ITrustRegionSubproblem
	{
		public Vector<double> Pstep { get; private set; }

		public bool HitBoundary { get; private set; }

		public void Solve(IObjectiveModel objective, double delta)
		{
			Vector<double> gradient = objective.Gradient;
			Matrix<double> hessian = objective.Hessian;
			Vector<double> vector = -hessian.PseudoInverse() * gradient;
			double num = gradient.DotProduct(gradient) / (hessian * gradient).DotProduct(gradient);
			Vector<double> vector2 = (0.0 - num) * gradient;
			if (vector.L2Norm() <= delta)
			{
				HitBoundary = false;
				Pstep = vector;
			}
			else if (num * vector2.L2Norm() >= delta)
			{
				HitBoundary = true;
				Pstep = delta / vector2.L2Norm() * vector2;
			}
			else
			{
				HitBoundary = true;
				double item = Util.FindBeta(num, vector2, vector, delta).Item2;
				Pstep = num * vector2 + item * (vector - num * vector2);
			}
		}
	}
}
