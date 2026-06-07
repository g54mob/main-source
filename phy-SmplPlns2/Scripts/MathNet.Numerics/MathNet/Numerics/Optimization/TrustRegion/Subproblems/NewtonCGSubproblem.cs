using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.TrustRegion.Subproblems
{
	internal class NewtonCGSubproblem : ITrustRegionSubproblem
	{
		public Vector<double> Pstep { get; private set; }

		public bool HitBoundary { get; private set; }

		public void Solve(IObjectiveModel objective, double delta)
		{
			Vector<double> gradient = objective.Gradient;
			Matrix<double> hessian = objective.Hessian;
			double num = gradient.L2Norm();
			double num2 = Math.Min(0.5, Math.Sqrt(num)) * num;
			Vector<double> vector = Vector<double>.Build.Dense(hessian.RowCount);
			Vector<double> vector2 = gradient;
			Vector<double> vector3 = -vector2;
			Vector<double> vector5;
			while (true)
			{
				Vector<double> vector4 = hessian * vector3;
				double num3 = vector3.DotProduct(vector4);
				if (num3 <= 0.0)
				{
					Pstep = vector + Util.FindBeta(1.0, vector, vector3, delta).Item1 * vector3;
					HitBoundary = true;
					return;
				}
				double num4 = vector2.DotProduct(vector2);
				double num5 = num4 / num3;
				vector5 = vector + num5 * vector3;
				if (vector5.L2Norm() >= delta)
				{
					Pstep = vector + Util.FindBeta(1.0, vector, vector3, delta).Item2 * vector3;
					HitBoundary = true;
					return;
				}
				Vector<double> vector6 = vector2 + num5 * vector4;
				double num6 = vector6.DotProduct(vector6);
				if (Math.Sqrt(num6) < num2)
				{
					break;
				}
				vector = vector5;
				vector2 = vector6;
				vector3 = -vector6 + num6 / num4 * vector3;
			}
			Pstep = vector5;
			HitBoundary = false;
		}
	}
}
