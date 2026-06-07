using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public class LevenbergMarquardtMinimizer : NonlinearMinimizerBase
	{
		public double InitialMu { get; set; }

		public LevenbergMarquardtMinimizer(double initialMu = 0.001, double gradientTolerance = 1E-15, double stepTolerance = 1E-15, double functionTolerance = 1E-15, int maximumIterations = -1)
			: base(gradientTolerance, stepTolerance, functionTolerance, maximumIterations)
		{
			InitialMu = initialMu;
		}

		public NonlinearMinimizationResult FindMinimum(IObjectiveModel objective, Vector<double> initialGuess, Vector<double> lowerBound = null, Vector<double> upperBound = null, Vector<double> scales = null, List<bool> isFixed = null)
		{
			return Minimum(objective, initialGuess, lowerBound, upperBound, scales, isFixed, InitialMu, base.GradientTolerance, base.StepTolerance, base.FunctionTolerance, base.MaximumIterations);
		}

		public NonlinearMinimizationResult FindMinimum(IObjectiveModel objective, double[] initialGuess, double[] lowerBound = null, double[] upperBound = null, double[] scales = null, bool[] isFixed = null)
		{
			if (objective == null)
			{
				throw new ArgumentNullException("objective");
			}
			if (initialGuess == null)
			{
				throw new ArgumentNullException("initialGuess");
			}
			Vector<double> lowerBound2 = ((lowerBound == null) ? null : CreateVector.Dense(lowerBound));
			Vector<double> upperBound2 = ((upperBound == null) ? null : CreateVector.Dense(upperBound));
			Vector<double> scales2 = ((scales == null) ? null : CreateVector.Dense(scales));
			List<bool> isFixed2 = isFixed?.ToList();
			return Minimum(objective, CreateVector.DenseOfArray(initialGuess), lowerBound2, upperBound2, scales2, isFixed2, InitialMu, base.GradientTolerance, base.StepTolerance, base.FunctionTolerance, base.MaximumIterations);
		}

		public NonlinearMinimizationResult Minimum(IObjectiveModel objective, Vector<double> initialGuess, Vector<double> lowerBound = null, Vector<double> upperBound = null, Vector<double> scales = null, List<bool> isFixed = null, double initialMu = 0.001, double gradientTolerance = 1E-15, double stepTolerance = 1E-15, double functionTolerance = 1E-15, int maximumIterations = -1)
		{
			if (objective == null)
			{
				throw new ArgumentNullException("objective");
			}
			ValidateBounds(initialGuess, lowerBound, upperBound, scales);
			objective.SetParameters(initialGuess, isFixed);
			ExitCondition exitCondition = ExitCondition.None;
			Vector<double> vector = ProjectToInternalParameters(initialGuess);
			double num = EvaluateFunction(objective, vector);
			if (maximumIterations < 0)
			{
				maximumIterations = 200 * (initialGuess.Count + 1);
			}
			if (double.IsNaN(num))
			{
				exitCondition = ExitCondition.InvalidValues;
				return new NonlinearMinimizationResult(objective, -1, exitCondition);
			}
			if (maximumIterations == 0)
			{
				exitCondition = ExitCondition.ManuallyStopped;
			}
			if (num <= functionTolerance)
			{
				exitCondition = ExitCondition.Converged;
			}
			(Vector<double> Gradient, Matrix<double> Hessian) tuple = EvaluateJacobian(objective, vector);
			Vector<double> item = tuple.Gradient;
			Matrix<double> item2 = tuple.Hessian;
			Vector<double> vector2 = item2.Diagonal();
			if (item.InfinityNorm() <= gradientTolerance)
			{
				exitCondition = ExitCondition.RelativeGradient;
			}
			if (exitCondition != ExitCondition.None)
			{
				return new NonlinearMinimizationResult(objective, -1, exitCondition);
			}
			double num2 = initialMu * vector2.Max();
			double num3 = 2.0;
			int num4 = 0;
			while (num4 < maximumIterations && exitCondition == ExitCondition.None)
			{
				num4++;
				while (true)
				{
					item2.SetDiagonal(item2.Diagonal() + num2);
					Vector<double> vector3 = item2.Solve(-item);
					if (vector3.L2Norm() <= stepTolerance * (vector.L2Norm() + stepTolerance))
					{
						exitCondition = ExitCondition.RelativePoints;
						break;
					}
					Vector<double> vector4 = vector + vector3;
					double num5 = EvaluateFunction(objective, vector4);
					if (double.IsNaN(num5))
					{
						exitCondition = ExitCondition.InvalidValues;
						break;
					}
					double num6 = vector3.DotProduct(num2 * vector3 - item);
					double num7 = ((num6 != 0.0) ? ((num - num5) / num6) : 0.0);
					if (num7 > 0.0)
					{
						vector4.CopyTo(vector);
						num = num5;
						(Vector<double> Gradient, Matrix<double> Hessian) tuple2 = EvaluateJacobian(objective, vector);
						item = tuple2.Gradient;
						item2 = tuple2.Hessian;
						vector2 = item2.Diagonal();
						if (item.InfinityNorm() <= gradientTolerance)
						{
							exitCondition = ExitCondition.RelativeGradient;
						}
						if (num <= functionTolerance)
						{
							exitCondition = ExitCondition.Converged;
						}
						num2 *= Math.Max(1.0 / 3.0, 1.0 - Math.Pow(2.0 * num7 - 1.0, 3.0));
						num3 = 2.0;
						break;
					}
					num2 *= num3;
					num3 = 2.0 * num3;
					item2.SetDiagonal(vector2);
				}
			}
			if (num4 >= maximumIterations)
			{
				exitCondition = ExitCondition.ExceedIterations;
			}
			return new NonlinearMinimizationResult(objective, num4, exitCondition);
		}
	}
}
