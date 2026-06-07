using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public class ConjugateGradientMinimizer : IUnconstrainedMinimizer
	{
		public double GradientTolerance { get; set; }

		public int MaximumIterations { get; set; }

		public ConjugateGradientMinimizer(double gradientTolerance, int maximumIterations)
		{
			GradientTolerance = gradientTolerance;
			MaximumIterations = maximumIterations;
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objective, Vector<double> initialGuess)
		{
			return Minimum(objective, initialGuess, GradientTolerance, MaximumIterations);
		}

		public static MinimizationResult Minimum(IObjectiveFunction objective, Vector<double> initialGuess, double gradientTolerance = 1E-08, int maxIterations = 1000)
		{
			if (!objective.IsGradientSupported)
			{
				throw new IncompatibleObjectiveException("Gradient not supported in objective function, but required for ConjugateGradient minimization.");
			}
			objective.EvaluateAt(initialGuess);
			Vector<double> gradient = objective.Gradient;
			ValidateGradient(objective);
			if (gradient.Norm(2.0) < gradientTolerance)
			{
				return new MinimizationResult(objective, 0, ExitCondition.AbsoluteGradient);
			}
			WeakWolfeLineSearch weakWolfeLineSearch = new WeakWolfeLineSearch(0.0001, 0.1, 0.0001, 1000);
			Vector<double> vector = -gradient;
			Vector<double> vector2 = vector;
			double initialStep = 100.0 * gradientTolerance / (gradient * gradient);
			LineSearchResult lineSearchResult;
			try
			{
				lineSearchResult = weakWolfeLineSearch.FindConformingStep(objective, vector2, initialStep);
			}
			catch (Exception innerException)
			{
				throw new InnerOptimizationException("Line search failed.", innerException);
			}
			objective = lineSearchResult.FunctionInfoAtMinimum;
			ValidateGradient(objective);
			double finalStep = lineSearchResult.FinalStep;
			int num = 1;
			int num2 = lineSearchResult.Iterations;
			int num3 = ((lineSearchResult.Iterations <= 0) ? 1 : 0);
			int num4 = 0;
			while (objective.Gradient.Norm(2.0) >= gradientTolerance && num < maxIterations)
			{
				Vector<double> vector3 = vector;
				vector = -objective.Gradient;
				double num5 = Math.Max(0.0, vector * (vector - vector3) / (vector3 * vector3));
				vector2 = vector + num5 * vector2;
				if (vector2 * objective.Gradient >= 0.0)
				{
					vector2 = vector;
					num4++;
				}
				try
				{
					lineSearchResult = weakWolfeLineSearch.FindConformingStep(objective, vector2, finalStep);
				}
				catch (Exception innerException2)
				{
					throw new InnerOptimizationException("Line search failed.", innerException2);
				}
				num3 += ((lineSearchResult.Iterations == 0) ? 1 : 0);
				num2 += lineSearchResult.Iterations;
				finalStep = lineSearchResult.FinalStep;
				objective = lineSearchResult.FunctionInfoAtMinimum;
				num++;
			}
			if (num == maxIterations)
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({maxIterations}) reached."));
			}
			return new MinimizationWithLineSearchResult(objective, num, ExitCondition.AbsoluteGradient, num2, num3);
		}

		private static void ValidateGradient(IObjectiveFunctionEvaluation objective)
		{
			foreach (double item in (IEnumerable<double>)objective.Gradient)
			{
				if (double.IsNaN(item) || double.IsInfinity(item))
				{
					throw new EvaluationException("Non-finite gradient returned.", objective);
				}
			}
		}

		private static void ValidateObjective(IObjectiveFunctionEvaluation objective)
		{
			if (double.IsNaN(objective.Value) || double.IsInfinity(objective.Value))
			{
				throw new EvaluationException("Non-finite objective function returned.", objective);
			}
		}
	}
}
