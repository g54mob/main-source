using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
[InternalBufferCapacity(16)]
public struct SkillTalentConditionsBuffer : IBufferElementData
{
	[GhostField]
	public ConditionData conditionData;
}
