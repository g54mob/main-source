public interface IBiomeAffectedObject
{
	int Seed { get; }

	void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration);
}
