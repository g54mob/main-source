using Unity.Entities;

public struct ScannerCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectToScan;

	public bool summonInsteadOfScan;

	public Biome onlyInBiome;
}
