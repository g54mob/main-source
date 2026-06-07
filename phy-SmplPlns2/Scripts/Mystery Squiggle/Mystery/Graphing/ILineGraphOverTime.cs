namespace Mystery.Graphing
{
	public interface ILineGraphOverTime : ILinearLineGraph, IPlottableGraph
	{
		void CleanUpBefore(float time);

		void CleanUpAfter(float time);
	}
}
