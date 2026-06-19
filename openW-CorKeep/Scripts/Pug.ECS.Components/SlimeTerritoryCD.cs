using Unity.Entities;
using Unity.Mathematics;

public struct SlimeTerritoryCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public int size;

	public bool spawnInsideBlockedAreas;

	public float slimeBlobSpawnChance;

	public SlimeType slimeType;
}
