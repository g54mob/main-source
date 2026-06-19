using Unity.Entities;
using Unity.Mathematics;

public struct CavelingTerritoryCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public int size;

	public bool spawnInsideBlockedAreas;

	public float cavelingSpawnChance;

	public float cavelingShamanSpawnChance;

	public float cavelingBruteSpawnChance;
}
