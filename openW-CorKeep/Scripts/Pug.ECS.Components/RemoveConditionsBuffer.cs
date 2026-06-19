using Unity.Entities;

[InternalBufferCapacity(0)]
public struct RemoveConditionsBuffer : IBufferElementData
{
	public ConditionID conditionId;
}
