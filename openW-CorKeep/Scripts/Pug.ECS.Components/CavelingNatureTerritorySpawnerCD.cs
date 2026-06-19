using Unity.Entities;

public struct CavelingNatureTerritorySpawnerCD : IComponentData, IQueryTypeParameter
{
	public int size;

	public float farmerSpawnChance;

	public float hunterSpawnChance;
}
