using Unity.Entities;
using Unity.Mathematics;

public struct BossCD : IComponentData, IQueryTypeParameter
{
	public ObjectDataCD chestToSpawn;

	public bool spawnOptionalChest;

	public ObjectDataCD optionalChestVersion;

	public float3 chestSpawnOffset;

	public float3 chestSpawnPositionOverride;
}
