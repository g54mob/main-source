namespace Mystery.Graphing
{
	public interface ILinearPlottableGraphOverTime : IPlottableGraph
	{
		void CleanUpHistory(float beforeTime);
	}
}
