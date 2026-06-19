using Unity.Entities;

public struct SlimeTerritorySpawnerCD : IComponentData, IQueryTypeParameter
{
	public int size;

	public float slimeBlobSpawnChance;
}
