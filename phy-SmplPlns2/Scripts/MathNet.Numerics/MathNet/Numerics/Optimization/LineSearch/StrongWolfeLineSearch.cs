using System;

namespace MathNet.Numerics.Optimization.LineSearch
{
	public class StrongWolfeLineSearch : WolfeLineSearch
	{
		protected override ExitCondition WolfeExitCondition => ExitCondition.StrongWolfeCriteria;

		public StrongWolfeLineSearch(double c1, double c2, double parameterTolerance, int maxIterations = 10)
			: base(c1, c2, parameterTolerance, maxIterations)
		{
		}

		protected override bool WolfeCondition(double stepDd, double initialDd)
		{
			return Math.Abs(stepDd) > base.C2 * Math.Abs(initialDd);
		}
	}
}
