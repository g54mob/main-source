using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
[InternalBufferCapacity(6)]
public struct SoulsConditionsBuffer : IBufferElementData
{
	[GhostField]
	public ConditionData conditionData;

	[GhostField]
	public SoulID soulID;
}
