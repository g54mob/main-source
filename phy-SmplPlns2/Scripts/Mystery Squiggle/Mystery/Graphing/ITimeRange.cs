namespace Mystery.Graphing
{
	public interface ITimeRange : IValueRange
	{
		bool UseSharedTime { get; set; }

		new float Min { get; set; }

		new float Max { get; set; }
	}
}
