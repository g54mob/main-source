namespace ModApi.Flight.Sim
{
	public interface IGameTime
	{
		double Time { get; set; }

		double WaveTime { get; }
	}
}
