using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostEnabledBit]
public struct DelayedFishLootCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	[GhostField]
	public ObjectID fishingLootToSpawn;

	[GhostField]
	public int amount;

	[GhostField]
	public float3 dropPosition;
}
