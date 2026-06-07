using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.TrustRegion
{
	public abstract class TrustRegionMinimizerBase : NonlinearMinimizerBase
	{
		public ITrustRegionSubproblem Subproblem;

		public double RadiusTolerance { get; set; }

		public TrustRegionMinimizerBase(ITrustRegionSubproblem subproblem, double gradientTolerance = 1E-08, double stepTolerance = 1E-08, double functionTolerance = 1E-08, double radiusTolerance = 1E-08, int maximumIterations = -1)
			: base(gradientTolerance, stepTolerance, functionTolerance, maximumIterations)
		{
			Subproblem = subproblem ?? throw new ArgumentNullException("subproblem");
			RadiusTolerance = radiusTolerance;
		}

		public NonlinearMinimizationResult FindMinimum(IObjectiveModel objective, Vector<double> initialGuess, Vector<double> lowerBound = null, Vector<double> upperBound = null, Vector<double> scales = null, List<bool> isFixed = null)
		{
			return Minimum(Subproblem, objective, initialGuess, lowerBound, upperBound, scales, isFixed, base.GradientTolerance, base.StepTolerance, base.FunctionTolerance, RadiusTolerance, base.MaximumIterations);
		}

		public NonlinearMinimizationResult FindMinimum(IObjectiveModel objective, double[] initialGuess, double[] lowerBound = null, double[] upperBound = null, double[] scales = null, bool[] isFixed = null)
		{
			Vector<double> lowerBound2 = ((lowerBound == null) ? null : CreateVector.Dense(lowerBound));
			Vector<double> upperBound2 = ((upperBound == null) ? null : CreateVector.Dense(upperBound));
			Vector<double> scales2 = ((scales == null) ? null : CreateVector.Dense(scales));
			List<bool> isFixed2 = isFixed?.ToList();
			return Minimum(Subproblem, objective, CreateVector.DenseOfArray(initialGuess), lowerBound2, upperBound2, scales2, isFixed2, base.GradientTolerance, base.StepTolerance, base.FunctionTolerance, RadiusTolerance, base.MaximumIterations);
		}

		public NonlinearMinimizationResult Minimum(ITrustRegionSubproblem subproblem, IObjectiveModel objective, Vector<double> initialGuess, Vector<double> lowerBound = null, Vector<double> upperBound = null, Vector<double> scales = null, List<bool> isFixed = null, double gradientTolerance = 1E-08, double stepTolerance = 1E-08, double functionTolerance = 1E-08, double radiusTolerance = 1E-18, int maximumIterations = -1)
		{
			double val = 1000.0;
			double num = 0.0;
			if (objective == null)
			{
				throw new ArgumentNullException("objective");
			}
			ValidateBounds(initialGuess, lowerBound, upperBound, scales);
			objective.SetParameters(initialGuess, isFixed);
			ExitCondition exitCondition = ExitCondition.None;
			Vector<double> vector = ProjectToInternalParameters(initialGuess);
			double num2 = EvaluateFunction(objective, initialGuess);
			if (maximumIterations < 0)
			{
				maximumIterations = 200 * (initialGuess.Count + 1);
			}
			if (double.IsNaN(num2))
			{
				exitCondition = ExitCondition.InvalidValues;
				return new NonlinearMinimizationResult(objective, -1, exitCondition);
			}
			if (maximumIterations == 0)
			{
				exitCondition = ExitCondition.ManuallyStopped;
			}
			if (num2 <= functionTolerance)
			{
				exitCondition = ExitCondition.Converged;
			}
			var (vector2, matrix) = EvaluateJacobian(objective, vector);
			if (vector2.InfinityNorm() <= gradientTolerance)
			{
				exitCondition = ExitCondition.RelativeGradient;
			}
			if (exitCondition != ExitCondition.None)
			{
				return new NonlinearMinimizationResult(objective, -1, exitCondition);
			}
			double val2 = vector2.DotProduct(vector2) / (matrix * vector2).DotProduct(vector2);
			val2 = Math.Max(1.0, Math.Min(val2, val));
			int num3 = 0;
			while (num3 < maximumIterations && exitCondition == ExitCondition.None)
			{
				num3++;
				subproblem.Solve(objective, val2);
				Vector<double> pstep = subproblem.Pstep;
				bool hitBoundary = subproblem.HitBoundary;
				double num4 = 0.0 - vector2.DotProduct(pstep) - 0.5 * pstep.DotProduct(matrix * pstep);
				if (pstep.L2Norm() <= stepTolerance * (stepTolerance + vector.L2Norm()))
				{
					exitCondition = ExitCondition.RelativePoints;
					break;
				}
				Vector<double> vector3 = vector + pstep;
				double num5 = EvaluateFunction(objective, vector3);
				if (double.IsNaN(num5))
				{
					exitCondition = ExitCondition.InvalidValues;
					break;
				}
				double num6 = ((num4 != 0.0) ? ((num2 - num5) / num4) : 0.0);
				if (num6 > 0.75 && hitBoundary)
				{
					val2 = Math.Min(2.0 * val2, val);
				}
				else if (num6 < 0.25)
				{
					val2 *= 0.25;
					if (val2 <= radiusTolerance * (radiusTolerance + vector.DotProduct(vector)))
					{
						exitCondition = ExitCondition.LackOfProgress;
						break;
					}
				}
				if (num6 > num)
				{
					vector3.CopyTo(vector);
					num2 = num5;
					(vector2, matrix) = EvaluateJacobian(objective, vector);
					if (vector2.InfinityNorm() <= gradientTolerance)
					{
						exitCondition = ExitCondition.RelativeGradient;
					}
					if (num2 <= functionTolerance)
					{
						exitCondition = ExitCondition.Converged;
					}
				}
			}
			if (num3 >= maximumIterations)
			{
				exitCondition = ExitCondition.ExceedIterations;
			}
			return new NonlinearMinimizationResult(objective, num3, exitCondition);
		}
	}
}
