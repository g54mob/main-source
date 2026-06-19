using Unity.Entities;
using Unity.NetCode;

public struct ActiveAffixConditionsBuffer : IBufferElementData
{
	[GhostField]
	public ConditionData conditionData;
}
