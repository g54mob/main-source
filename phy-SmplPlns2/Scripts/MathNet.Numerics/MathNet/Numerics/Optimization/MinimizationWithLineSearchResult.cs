namespace MathNet.Numerics.Optimization
{
	public class MinimizationWithLineSearchResult : MinimizationResult
	{
		public int TotalLineSearchIterations { get; }

		public int IterationsWithNonTrivialLineSearch { get; }

		public MinimizationWithLineSearchResult(IObjectiveFunction functionInfo, int iterations, ExitCondition reasonForExit, int totalLineSearchIterations, int iterationsWithNonTrivialLineSearch)
			: base(functionInfo, iterations, reasonForExit)
		{
			TotalLineSearchIterations = totalLineSearchIterations;
			IterationsWithNonTrivialLineSearch = iterationsWithNonTrivialLineSearch;
		}
	}
}
