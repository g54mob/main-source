using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
[InternalBufferCapacity(16)]
public struct SkillConditionsBuffer : IBufferElementData
{
	[GhostField]
	public ConditionData conditionData;
}
