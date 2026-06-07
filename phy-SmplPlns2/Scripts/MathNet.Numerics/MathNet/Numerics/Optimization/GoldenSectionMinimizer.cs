using System;

namespace MathNet.Numerics.Optimization
{
	public class GoldenSectionMinimizer
	{
		public double XTolerance { get; set; }

		public int MaximumIterations { get; set; }

		public int MaximumExpansionSteps { get; set; }

		public double LowerExpansionFactor { get; set; }

		public double UpperExpansionFactor { get; set; }

		public GoldenSectionMinimizer(double xTolerance = 1E-05, int maxIterations = 1000, int maxExpansionSteps = 10, double lowerExpansionFactor = 2.0, double upperExpansionFactor = 2.0)
		{
			XTolerance = xTolerance;
			MaximumIterations = maxIterations;
			MaximumExpansionSteps = maxExpansionSteps;
			LowerExpansionFactor = lowerExpansionFactor;
			UpperExpansionFactor = upperExpansionFactor;
		}

		public ScalarMinimizationResult FindMinimum(IScalarObjectiveFunction objective, double lowerBound, double upperBound)
		{
			return Minimum(objective, lowerBound, upperBound, XTolerance, MaximumIterations, MaximumExpansionSteps, LowerExpansionFactor, UpperExpansionFactor);
		}

		public static ScalarMinimizationResult Minimum(IScalarObjectiveFunction objective, double lowerBound, double upperBound, double xTolerance = 1E-05, int maxIterations = 1000, int maxExpansionSteps = 10, double lowerExpansionFactor = 2.0, double upperExpansionFactor = 2.0)
		{
			if (upperBound <= lowerBound)
			{
				throw new OptimizationException("Lower bound must be lower than upper bound.");
			}
			double point = lowerBound + (upperBound - lowerBound) / 2.618033988749895;
			IScalarObjectiveFunctionEvaluation scalarObjectiveFunctionEvaluation = objective.Evaluate(lowerBound);
			IScalarObjectiveFunctionEvaluation scalarObjectiveFunctionEvaluation2 = objective.Evaluate(point);
			IScalarObjectiveFunctionEvaluation scalarObjectiveFunctionEvaluation3 = objective.Evaluate(upperBound);
			ValueChecker(scalarObjectiveFunctionEvaluation.Value);
			ValueChecker(scalarObjectiveFunctionEvaluation2.Value);
			ValueChecker(scalarObjectiveFunctionEvaluation3.Value);
			for (int i = 0; i < maxExpansionSteps; i++)
			{
				if (!(scalarObjectiveFunctionEvaluation3.Value < scalarObjectiveFunctionEvaluation2.Value) && !(scalarObjectiveFunctionEvaluation.Value < scalarObjectiveFunctionEvaluation2.Value))
				{
					break;
				}
				if (scalarObjectiveFunctionEvaluation.Value < scalarObjectiveFunctionEvaluation2.Value)
				{
					lowerBound = 0.5 * (upperBound + lowerBound) - lowerExpansionFactor * 0.5 * (upperBound - lowerBound);
					scalarObjectiveFunctionEvaluation = objective.Evaluate(lowerBound);
				}
				if (scalarObjectiveFunctionEvaluation3.Value < scalarObjectiveFunctionEvaluation2.Value)
				{
					upperBound = 0.5 * (upperBound + lowerBound) + upperExpansionFactor * 0.5 * (upperBound - lowerBound);
					scalarObjectiveFunctionEvaluation3 = objective.Evaluate(upperBound);
				}
				point = lowerBound + (upperBound - lowerBound) / 2.618033988749895;
				scalarObjectiveFunctionEvaluation2 = objective.Evaluate(point);
			}
			if (scalarObjectiveFunctionEvaluation3.Value < scalarObjectiveFunctionEvaluation2.Value || scalarObjectiveFunctionEvaluation.Value < scalarObjectiveFunctionEvaluation2.Value)
			{
				throw new OptimizationException("Lower and upper bounds do not necessarily bound a minimum.");
			}
			int num = 0;
			while (Math.Abs(scalarObjectiveFunctionEvaluation3.Point - scalarObjectiveFunctionEvaluation.Point) > xTolerance && num < maxIterations)
			{
				point = scalarObjectiveFunctionEvaluation.Point + (scalarObjectiveFunctionEvaluation3.Point - scalarObjectiveFunctionEvaluation.Point) / 2.618033988749895;
				scalarObjectiveFunctionEvaluation2 = objective.Evaluate(point);
				ValueChecker(scalarObjectiveFunctionEvaluation2.Value);
				double point2 = scalarObjectiveFunctionEvaluation.Point + (scalarObjectiveFunctionEvaluation3.Point - scalarObjectiveFunctionEvaluation2.Point);
				IScalarObjectiveFunctionEvaluation scalarObjectiveFunctionEvaluation4 = objective.Evaluate(point2);
				ValueChecker(scalarObjectiveFunctionEvaluation4.Value);
				if (scalarObjectiveFunctionEvaluation4.Point < scalarObjectiveFunctionEvaluation2.Point)
				{
					if (scalarObjectiveFunctionEvaluation4.Value > scalarObjectiveFunctionEvaluation2.Value)
					{
						scalarObjectiveFunctionEvaluation = scalarObjectiveFunctionEvaluation4;
					}
					else
					{
						scalarObjectiveFunctionEvaluation3 = scalarObjectiveFunctionEvaluation2;
					}
				}
				else if (scalarObjectiveFunctionEvaluation4.Value > scalarObjectiveFunctionEvaluation2.Value)
				{
					scalarObjectiveFunctionEvaluation3 = scalarObjectiveFunctionEvaluation4;
				}
				else
				{
					scalarObjectiveFunctionEvaluation = scalarObjectiveFunctionEvaluation2;
				}
				num++;
			}
			if (num == maxIterations)
			{
				throw new MaximumIterationsException("Max iterations reached.");
			}
			return new ScalarMinimizationResult(scalarObjectiveFunctionEvaluation2, num, ExitCondition.BoundTolerance);
		}

		private static void ValueChecker(double value)
		{
			if (double.IsNaN(value) || double.IsInfinity(value))
			{
				throw new Exception("Objective function returned non-finite value.");
			}
		}
	}
}
