using Unity.Entities;

public struct CavelingTerritorySpawnerCD : IComponentData, IQueryTypeParameter
{
	public int size;

	public float cavelingSpawnChance;

	public float cavelingShamanSpawnChance;

	public float cavelingBruteSpawnChance;
}
