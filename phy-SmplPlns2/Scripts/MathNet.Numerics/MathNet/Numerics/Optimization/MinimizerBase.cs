using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public abstract class MinimizerBase
	{
		protected const double VerySmall = 1E-15;

		public double GradientTolerance { get; set; }

		public double ParameterTolerance { get; set; }

		public double FunctionProgressTolerance { get; set; }

		public int MaximumIterations { get; set; }

		protected MinimizerBase(double gradientTolerance, double parameterTolerance, double functionProgressTolerance, int maximumIterations)
		{
			GradientTolerance = gradientTolerance;
			ParameterTolerance = parameterTolerance;
			FunctionProgressTolerance = functionProgressTolerance;
			MaximumIterations = maximumIterations;
		}

		protected ExitCondition ExitCriteriaSatisfied(IObjectiveFunctionEvaluation candidatePoint, IObjectiveFunctionEvaluation lastPoint, int iterations)
		{
			Vector<double> point = candidatePoint.Point;
			double num = 0.0;
			double num2 = Math.Max(Math.Abs(candidatePoint.Value), 1.0);
			for (int i = 0; i < point.Count; i++)
			{
				double value = GetProjectedGradient(candidatePoint, i) * Math.Max(Math.Abs(point[i]), 1.0) / num2;
				num = Math.Max(num, Math.Abs(value));
			}
			if (num < GradientTolerance)
			{
				return ExitCondition.RelativeGradient;
			}
			if (lastPoint != null)
			{
				Vector<double> point2 = lastPoint.Point;
				double num3 = 0.0;
				for (int j = 0; j < point.Count; j++)
				{
					double val = Math.Abs(point[j] - point2[j]) / Math.Max(Math.Abs(point2[j]), 1.0);
					num3 = Math.Max(num3, val);
				}
				if (num3 < ParameterTolerance)
				{
					return ExitCondition.LackOfProgress;
				}
				double num4 = candidatePoint.Value - lastPoint.Value;
				if (iterations > 500 && num4 < 0.0 && Math.Abs(num4) < FunctionProgressTolerance)
				{
					return ExitCondition.LackOfProgress;
				}
			}
			return ExitCondition.None;
		}

		protected virtual double GetProjectedGradient(IObjectiveFunctionEvaluation candidatePoint, int ii)
		{
			return candidatePoint.Gradient[ii];
		}

		protected void ValidateGradientAndObjective(IObjectiveFunctionEvaluation eval)
		{
			foreach (double item in (IEnumerable<double>)eval.Gradient)
			{
				if (double.IsNaN(item) || double.IsInfinity(item))
				{
					throw new EvaluationException("Non-finite gradient returned.", eval);
				}
			}
			if (double.IsNaN(eval.Value) || double.IsInfinity(eval.Value))
			{
				throw new EvaluationException("Non-finite objective function returned.", eval);
			}
		}
	}
}
