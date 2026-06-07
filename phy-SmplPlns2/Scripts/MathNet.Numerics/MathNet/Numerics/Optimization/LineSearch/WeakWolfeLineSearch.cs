using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.LineSearch
{
	public class WeakWolfeLineSearch : WolfeLineSearch
	{
		protected override ExitCondition WolfeExitCondition => ExitCondition.WeakWolfeCriteria;

		public WeakWolfeLineSearch(double c1, double c2, double parameterTolerance, int maxIterations = 10)
			: base(c1, c2, parameterTolerance, maxIterations)
		{
		}

		protected override bool WolfeCondition(double stepDd, double initialDd)
		{
			return stepDd < base.C2 * initialDd;
		}

		protected override void ValidateValue(IObjectiveFunctionEvaluation eval)
		{
			if (!IsFinite(eval.Value))
			{
				throw new EvaluationException(FormattableString.Invariant($"Non-finite value returned by objective function: {eval.Value}"), eval);
			}
		}

		protected override void ValidateInputArguments(IObjectiveFunctionEvaluation startingPoint, Vector<double> searchDirection, double initialStep, double upperBound)
		{
			if (!startingPoint.IsGradientSupported)
			{
				throw new ArgumentException("objective function does not support gradient");
			}
		}

		protected override void ValidateGradient(IObjectiveFunctionEvaluation eval)
		{
			foreach (double item in (IEnumerable<double>)eval.Gradient)
			{
				if (!IsFinite(item))
				{
					throw new EvaluationException(FormattableString.Invariant($"Non-finite value returned by gradient: {item}"), eval);
				}
			}
		}

		private static bool IsFinite(double x)
		{
			if (!double.IsNaN(x))
			{
				return !double.IsInfinity(x);
			}
			return false;
		}
	}
}
