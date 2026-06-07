namespace ModApi.Flight.MapView
{
	public interface ICraftOptions
	{
		bool ContinuouslyUpdateChain { get; }

		float ThrustScale { get; }
	}
}
