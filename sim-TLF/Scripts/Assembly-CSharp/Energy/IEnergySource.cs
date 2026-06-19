namespace Energy
{
	public interface IEnergySource
	{
		float MaxOutput { get; }

		float AvailableEnergy { get; }

		float ExtractEnergy(float amount);
	}
}
