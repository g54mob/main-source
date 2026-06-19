using Unity.Entities;

[InternalBufferCapacity(0)]
public struct NewConditionsBuffer : IBufferElementData
{
	public ConditionData conditionData;
}
