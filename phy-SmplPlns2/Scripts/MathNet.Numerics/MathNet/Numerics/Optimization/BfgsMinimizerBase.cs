using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public abstract class BfgsMinimizerBase : MinimizerBase
	{
		protected BfgsMinimizerBase(double gradientTolerance, double parameterTolerance, double functionProgressTolerance, int maximumIterations)
			: base(gradientTolerance, parameterTolerance, functionProgressTolerance, maximumIterations)
		{
		}

		protected int DoBfgsUpdate(ref ExitCondition currentExitCondition, WolfeLineSearch lineSearcher, ref Matrix<double> inversePseudoHessian, ref Vector<double> lineSearchDirection, ref IObjectiveFunction previousPoint, ref LineSearchResult lineSearchResult, ref IObjectiveFunction candidate, ref Vector<double> step, ref int totalLineSearchSteps, ref int iterationsWithNontrivialLineSearch)
		{
			int i;
			for (i = 1; i < base.MaximumIterations; i++)
			{
				lineSearchDirection = CalculateSearchDirection(ref inversePseudoHessian, out var maxLineSearchStep, out var startingStepSize, previousPoint, candidate, step);
				try
				{
					lineSearchResult = lineSearcher.FindConformingStep(candidate, lineSearchDirection, startingStepSize, maxLineSearchStep);
				}
				catch (Exception innerException)
				{
					throw new InnerOptimizationException("Line search failed.", innerException);
				}
				iterationsWithNontrivialLineSearch += ((lineSearchResult.Iterations > 0) ? 1 : 0);
				totalLineSearchSteps += lineSearchResult.Iterations;
				step = lineSearchResult.FunctionInfoAtMinimum.Point - candidate.Point;
				previousPoint = candidate;
				candidate = lineSearchResult.FunctionInfoAtMinimum;
				currentExitCondition = ExitCriteriaSatisfied(candidate, previousPoint, i);
				if (currentExitCondition != ExitCondition.None)
				{
					break;
				}
			}
			return i;
		}

		protected abstract Vector<double> CalculateSearchDirection(ref Matrix<double> inversePseudoHessian, out double maxLineSearchStep, out double startingStepSize, IObjectiveFunction previousPoint, IObjectiveFunction candidate, Vector<double> step);
	}
}
