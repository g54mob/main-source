using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization.LineSearch;

namespace MathNet.Numerics.Optimization
{
	public class LimitedMemoryBfgsMinimizer : MinimizerBase, IUnconstrainedMinimizer
	{
		public int Memory { get; set; }

		public LimitedMemoryBfgsMinimizer(double gradientTolerance, double parameterTolerance, double functionProgressTolerance, int memory, int maximumIterations = 1000)
			: base(gradientTolerance, parameterTolerance, functionProgressTolerance, maximumIterations)
		{
			Memory = memory;
		}

		public MinimizationResult FindMinimum(IObjectiveFunction objective, Vector<double> initialGuess)
		{
			if (!objective.IsGradientSupported)
			{
				throw new IncompatibleObjectiveException("Gradient not supported in objective function, but required for L-BFGS minimization.");
			}
			objective.EvaluateAt(initialGuess);
			ValidateGradientAndObjective(objective);
			ExitCondition exitCondition = ExitCriteriaSatisfied(objective, null, 0);
			if (exitCondition != ExitCondition.None)
			{
				return new MinimizationResult(objective, 0, exitCondition);
			}
			WeakWolfeLineSearch weakWolfeLineSearch = new WeakWolfeLineSearch(0.0001, 0.9, Math.Max(base.ParameterTolerance, 1E-10), 1000);
			Vector<double> vector = -objective.Gradient;
			double initialStep = 100.0 * base.GradientTolerance / (vector * vector);
			IObjectiveFunction objectiveFunction = objective;
			LineSearchResult lineSearchResult;
			try
			{
				lineSearchResult = weakWolfeLineSearch.FindConformingStep(objective, vector, initialStep);
			}
			catch (OptimizationException innerException)
			{
				throw new InnerOptimizationException("Line search failed.", innerException);
			}
			catch (ArgumentException innerException2)
			{
				throw new InnerOptimizationException("Line search failed.", innerException2);
			}
			IObjectiveFunction functionInfoAtMinimum = lineSearchResult.FunctionInfoAtMinimum;
			ValidateGradientAndObjective(functionInfoAtMinimum);
			Vector<double> vector2 = functionInfoAtMinimum.Point - initialGuess;
			Vector<double> vector3 = functionInfoAtMinimum.Gradient - objectiveFunction.Gradient;
			List<Vector<double>> list = new List<Vector<double>> { vector3 };
			List<Vector<double>> list2 = new List<Vector<double>> { vector2 };
			List<double> list3 = new List<double> { 1.0 / vector3.DotProduct(vector2) };
			int num = 1;
			int num2 = lineSearchResult.Iterations;
			int num3 = ((lineSearchResult.Iterations <= 0) ? 1 : 0);
			objectiveFunction = functionInfoAtMinimum;
			while (num++ < base.MaximumIterations && objectiveFunction.Gradient.Norm(2.0) >= base.GradientTolerance)
			{
				vector = -ApplyLbfgsUpdate(objectiveFunction, list, list2, list3);
				if (objectiveFunction.Gradient.DotProduct(vector) > 0.0)
				{
					throw new InnerOptimizationException("Direction is not a descent direction.");
				}
				try
				{
					lineSearchResult = weakWolfeLineSearch.FindConformingStep(objectiveFunction, vector, 1.0);
				}
				catch (OptimizationException innerException3)
				{
					throw new InnerOptimizationException("Line search failed.", innerException3);
				}
				catch (ArgumentException innerException4)
				{
					throw new InnerOptimizationException("Line search failed.", innerException4);
				}
				num3 += ((lineSearchResult.Iterations > 0) ? 1 : 0);
				num2 += lineSearchResult.Iterations;
				functionInfoAtMinimum = lineSearchResult.FunctionInfoAtMinimum;
				exitCondition = ExitCriteriaSatisfied(functionInfoAtMinimum, objectiveFunction, num);
				if (exitCondition != ExitCondition.None)
				{
					break;
				}
				vector2 = functionInfoAtMinimum.Point - objectiveFunction.Point;
				vector3 = functionInfoAtMinimum.Gradient - objectiveFunction.Gradient;
				list.Add(vector3);
				list2.Add(vector2);
				list3.Add(1.0 / vector3.DotProduct(vector2));
				objectiveFunction = functionInfoAtMinimum;
				if (list.Count > Memory)
				{
					list.RemoveAt(0);
					list2.RemoveAt(0);
					list3.RemoveAt(0);
				}
			}
			if (num == base.MaximumIterations && exitCondition == ExitCondition.None)
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({base.MaximumIterations}) reached."));
			}
			return new MinimizationWithLineSearchResult(functionInfoAtMinimum, num, ExitCondition.AbsoluteGradient, num2, num3);
		}

		private Vector<double> ApplyLbfgsUpdate(IObjectiveFunction previousPoint, List<Vector<double>> ykhistory, List<Vector<double>> skhistory, List<double> rhokhistory)
		{
			Vector<double> vector = previousPoint.Gradient.Clone();
			Stack<double> stack = new Stack<double>();
			for (int num = ykhistory.Count - 1; num >= 0; num--)
			{
				double num2 = rhokhistory[num] * vector.DotProduct(skhistory[num]);
				stack.Push(num2);
				vector -= num2 * ykhistory[num];
			}
			Vector<double> vector2 = ykhistory.Last();
			Vector<double> other = skhistory.Last();
			vector *= vector2.DotProduct(other) / vector2.DotProduct(vector2);
			for (int i = 0; i < ykhistory.Count; i++)
			{
				double num3 = rhokhistory[i] * ykhistory[i].DotProduct(vector);
				vector += skhistory[i] * (stack.Pop() - num3);
			}
			return vector;
		}
	}
}
