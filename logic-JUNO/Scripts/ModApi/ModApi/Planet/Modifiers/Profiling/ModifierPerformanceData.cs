namespace ModApi.Planet.Modifiers.Profiling
{
	public class ModifierPerformanceData
	{
		public double AverageExecutionTimeNanoSeconds { get; }

		public double ExecutionCountPercentage { get; }

		public double ExecutionTimePercentage { get; }

		public double TotalExecutionTimeNanoSeconds { get; }

		public ModifierPerformanceData(long totalExecutionCount, double totalExecutionTime, long executionCount, double executionTime)
		{
			TotalExecutionTimeNanoSeconds = executionTime * 1000.0 * 1000.0;
			AverageExecutionTimeNanoSeconds = executionTime / (double)executionCount * 1000.0 * 1000.0;
			ExecutionTimePercentage = executionTime / totalExecutionTime * 100.0;
			ExecutionCountPercentage = (double)executionCount / (double)totalExecutionCount * 100.0;
		}
	}
}
