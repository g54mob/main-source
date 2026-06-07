using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public class BfgsMinimizer : BfgsMinimizerBase, IUnconstrainedMinimizer
	{
		public BfgsMinimizer(double gradientTolerance, double parameterTolerance, double functionProgressTolerance, int maximumIterations = 1000)
			: base(gradientTolerance, parameterTolerance, functionProgressTolerance, maximumIterations)
		{
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objective, Vector<double> initialGuess)
		{
			if (!objective.IsGradientSupported)
			{
				throw new IncompatibleObjectiveException("Gradient not supported in objective function, but required for BFGS minimization.");
			}
			objective.EvaluateAt(initialGuess);
			ValidateGradientAndObjective(objective);
			ExitCondition currentExitCondition = ExitCriteriaSatisfied(objective, null, 0);
			if (currentExitCondition != ExitCondition.None)
			{
				return new MinimizationResult(objective, 0, currentExitCondition);
			}
			WeakWolfeLineSearch weakWolfeLineSearch = new WeakWolfeLineSearch(0.0001, 0.9, Math.Max(base.ParameterTolerance, 1E-10), 1000);
			Matrix<double> inversePseudoHessian = CreateMatrix.DenseIdentity<double>(initialGuess.Count);
			Vector<double> lineSearchDirection = -objective.Gradient;
			double initialStep = 100.0 * base.GradientTolerance / (lineSearchDirection * lineSearchDirection);
			IObjectiveFunction previousPoint = objective;
			LineSearchResult lineSearchResult;
			try
			{
				lineSearchResult = weakWolfeLineSearch.FindConformingStep(objective, lineSearchDirection, initialStep);
			}
			catch (OptimizationException innerException)
			{
				throw new InnerOptimizationException("Line search failed.", innerException);
			}
			catch (ArgumentException innerException2)
			{
				throw new InnerOptimizationException("Line search failed.", innerException2);
			}
			IObjectiveFunction candidate = lineSearchResult.FunctionInfoAtMinimum;
			ValidateGradientAndObjective(candidate);
			Vector<double> step = candidate.Point - initialGuess;
			int totalLineSearchSteps = lineSearchResult.Iterations;
			int iterationsWithNontrivialLineSearch = ((lineSearchResult.Iterations <= 0) ? 1 : 0);
			int num = DoBfgsUpdate(ref currentExitCondition, weakWolfeLineSearch, ref inversePseudoHessian, ref lineSearchDirection, ref previousPoint, ref lineSearchResult, ref candidate, ref step, ref totalLineSearchSteps, ref iterationsWithNontrivialLineSearch);
			if (num == base.MaximumIterations && currentExitCondition == ExitCondition.None)
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({base.MaximumIterations}) reached."));
			}
			return new MinimizationWithLineSearchResult(candidate, num, ExitCondition.AbsoluteGradient, totalLineSearchSteps, iterationsWithNontrivialLineSearch);
		}

		protected override Vector<double> CalculateSearchDirection(ref Matrix<double> inversePseudoHessian, out double maxLineSearchStep, out double startingStepSize, IObjectiveFunction previousPoint, IObjectiveFunction candidate, Vector<double> step)
		{
			startingStepSize = 1.0;
			maxLineSearchStep = double.PositiveInfinity;
			Vector<double> vector = candidate.Gradient - previousPoint.Gradient;
			double num = step * vector;
			inversePseudoHessian = inversePseudoHessian + (num + vector * inversePseudoHessian * vector) / Math.Pow(num, 2.0) * step.OuterProduct(step) - (inversePseudoHessian * vector.ToColumnMatrix() * step.ToRowMatrix() + step.ToColumnMatrix() * (vector.ToRowMatrix() * inversePseudoHessian)) * (1.0 / num);
			Vector<double> vector2 = -inversePseudoHessian * candidate.Gradient;
			if (vector2 * candidate.Gradient >= 0.0)
			{
				vector2 = -candidate.Gradient;
				inversePseudoHessian = CreateMatrix.DenseIdentity<double>(candidate.Point.Count);
			}
			return vector2;
		}
	}
}
