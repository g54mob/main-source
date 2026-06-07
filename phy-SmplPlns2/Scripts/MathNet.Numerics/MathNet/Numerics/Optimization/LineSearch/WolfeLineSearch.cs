using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.LineSearch
{
	public abstract class WolfeLineSearch
	{
		protected double C1 { get; }

		protected double C2 { get; }

		protected double ParameterTolerance { get; }

		protected int MaximumIterations { get; }

		protected abstract ExitCondition WolfeExitCondition { get; }

		public WolfeLineSearch(double c1, double c2, double parameterTolerance, int maxIterations = 10)
		{
			if (c1 <= 0.0)
			{
				throw new ArgumentException(FormattableString.Invariant($"c1 {c1} should be greater than 0"));
			}
			if (c2 <= c1)
			{
				throw new ArgumentException(FormattableString.Invariant($"c1 {c1} should be less than c2 {c2}"));
			}
			if (c2 >= 1.0)
			{
				throw new ArgumentException(FormattableString.Invariant($"c2 {c2} should be less than 1"));
			}
			C1 = c1;
			C2 = c2;
			ParameterTolerance = parameterTolerance;
			MaximumIterations = maxIterations;
		}

		public LineSearchResult FindConformingStep(IObjectiveFunctionEvaluation startingPoint, Vector<double> searchDirection, double initialStep)
		{
			return FindConformingStep(startingPoint, searchDirection, initialStep, double.PositiveInfinity);
		}

		public LineSearchResult FindConformingStep(IObjectiveFunctionEvaluation startingPoint, Vector<double> searchDirection, double initialStep, double upperBound)
		{
			ValidateInputArguments(startingPoint, searchDirection, initialStep, upperBound);
			double num = 0.0;
			double num2 = initialStep;
			double value = startingPoint.Value;
			Vector<double> gradient = startingPoint.Gradient;
			double num3 = searchDirection * gradient;
			IObjectiveFunction objectiveFunction = startingPoint.CreateNew();
			ExitCondition reasonForExit = ExitCondition.None;
			int i;
			for (i = 0; i < MaximumIterations; i++)
			{
				objectiveFunction.EvaluateAt(startingPoint.Point + searchDirection * num2);
				ValidateGradient(objectiveFunction);
				ValidateValue(objectiveFunction);
				double stepDd = searchDirection * objectiveFunction.Gradient;
				if (objectiveFunction.Value > value + C1 * num2 * num3)
				{
					upperBound = num2;
					num2 = 0.5 * (num + upperBound);
				}
				else
				{
					if (!WolfeCondition(stepDd, num3))
					{
						reasonForExit = WolfeExitCondition;
						break;
					}
					num = num2;
					num2 = (double.IsPositiveInfinity(upperBound) ? (2.0 * num) : (0.5 * (num + upperBound)));
				}
				if (!double.IsInfinity(upperBound))
				{
					double num4 = 0.0;
					Vector<double> point = objectiveFunction.Point;
					for (int j = 0; j < objectiveFunction.Point.Count; j++)
					{
						double val = Math.Abs(searchDirection[j] * (upperBound - num)) / Math.Max(Math.Abs(point[j]), 1.0);
						num4 = Math.Max(num4, val);
					}
					if (num4 < ParameterTolerance)
					{
						reasonForExit = ExitCondition.LackOfProgress;
						break;
					}
				}
			}
			if (i == MaximumIterations && double.IsPositiveInfinity(upperBound))
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({MaximumIterations}) reached. Function appears to be unbounded in search direction."));
			}
			if (i == MaximumIterations)
			{
				throw new MaximumIterationsException(FormattableString.Invariant($"Maximum iterations ({MaximumIterations}) reached."));
			}
			return new LineSearchResult(objectiveFunction, i, num2, reasonForExit);
		}

		protected abstract bool WolfeCondition(double stepDd, double initialDd);

		protected virtual void ValidateGradient(IObjectiveFunctionEvaluation objective)
		{
		}

		protected virtual void ValidateValue(IObjectiveFunctionEvaluation objective)
		{
		}

		protected virtual void ValidateInputArguments(IObjectiveFunctionEvaluation startingPoint, Vector<double> searchDirection, double initialStep, double upperBound)
		{
		}
	}
}
