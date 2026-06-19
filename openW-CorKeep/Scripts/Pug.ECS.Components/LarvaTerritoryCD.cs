using Unity.Entities;
using Unity.Mathematics;

public struct LarvaTerritoryCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public int size;

	public bool spawnInsideBlockedAreas;
}
