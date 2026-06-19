using Unity.Entities;
using Unity.Mathematics;

public struct CavelingNatureTerritoryCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public int size;

	public bool spawnInsideBlockedAreas;

	public float farmerSpawnChance;

	public float hunterSpawnChance;
}
