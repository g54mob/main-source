using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public sealed class NewtonMinimizer : IUnconstrainedMinimizer
	{
		public double GradientTolerance { get; set; }

		public int MaximumIterations { get; set; }

		public bool UseLineSearch { get; set; }

		public NewtonMinimizer(double gradientTolerance, int maximumIterations, bool useLineSearch = false)
		{
			GradientTolerance = gradientTolerance;
			MaximumIterations = maximumIterations;
			UseLineSearch = useLineSearch;
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objective, Vector<double> initialGuess)
		{
			return Minimum(objective, initialGuess, GradientTolerance, MaximumIterations, UseLineSearch);
		}

		public static MinimizationResult Minimum(IObjectiveFunction objective, Vector<double> initialGuess, double gradientTolerance = 1E-08, int maxIterations = 1000, bool useLineSearch = false)
		{
			if (!objective.IsGradientSupported)
			{
				throw new IncompatibleObjectiveException("Gradient not supported in objective function, but required for Newton minimization.");
			}
			if (!objective.IsHessianSupported)
			{
				throw new IncompatibleObjectiveException("Hessian not supported in objective function, but required for Newton minimization.");
			}
			objective.EvaluateAt(initialGuess);
			ValidateGradient(objective);
			if (objective.Gradient.Norm(2.0) < gradientTolerance)
			{
				return new MinimizationResult(objective, 0, ExitCondition.AbsoluteGradient);
			}
			WeakWolfeLineSearch weakWolfeLineSearch = new WeakWolfeLineSearch(0.0001, 0.9, 0.0001, 1000);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			while (objective.Gradient.Norm(2.0) >= gradientTolerance && num < maxIterations)
			{
				ValidateHessian(objective);
				Vector<double> vector = objective.Hessian.LU().Solve(-objective.Gradient);
				if (vector * objective.Gradient >= 0.0)
				{
					vector = -objective.Gradient;
					flag = true;
				}
				if (useLineSearch || flag)
				{
					LineSearchResult lineSearchResult;
					try
					{
						lineSearchResult = weakWolfeLineSearch.FindConformingStep(objective, vector, 1.0);
					}
					catch (Exception innerException)
					{
						throw new InnerOptimizationException("Line search failed.", innerException);
					}
					num3 += ((lineSearchResult.Iterations > 0) ? 1 : 0);
					num2 += lineSearchResult.Iterations;
					objective = lineSearchResult.FunctionInfoAtMinimum;
				}
				else
				{
					objective.EvaluateAt(objective.Point + vector);
				}
				ValidateGradient(objective);
				flag = false;
				num++;
			}
			if (num == maxIterations)
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({maxIterations}) reached."));
			}
			return new MinimizationWithLineSearchResult(objective, num, ExitCondition.AbsoluteGradient, num2, num3);
		}

		private static void ValidateGradient(IObjectiveFunctionEvaluation eval)
		{
			foreach (double item in (IEnumerable<double>)eval.Gradient)
			{
				if (double.IsNaN(item) || double.IsInfinity(item))
				{
					throw new EvaluationException("Non-finite gradient returned.", eval);
				}
			}
		}

		private static void ValidateHessian(IObjectiveFunctionEvaluation eval)
		{
			Matrix<double> hessian = eval.Hessian;
			for (int i = 0; i < hessian.RowCount; i++)
			{
				for (int j = 0; j < hessian.ColumnCount; j++)
				{
					if (double.IsNaN(hessian[i, j]) || double.IsInfinity(hessian[i, j]))
					{
						throw new EvaluationException("Non-finite Hessian returned.", eval);
					}
				}
			}
		}
	}
}
