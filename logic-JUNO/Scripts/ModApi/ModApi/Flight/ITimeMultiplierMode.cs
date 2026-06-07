namespace ModApi.Flight
{
	public interface ITimeMultiplierMode
	{
		string Name { get; }

		double TimeMultiplier { get; }

		bool WarpMode { get; }
	}
}
