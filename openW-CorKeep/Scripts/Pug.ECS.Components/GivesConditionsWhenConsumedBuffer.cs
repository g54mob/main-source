using Unity.Entities;

[InternalBufferCapacity(1)]
public struct GivesConditionsWhenConsumedBuffer : IBufferElementData
{
	public ConditionDataContainer conditionDataContainer;
}
