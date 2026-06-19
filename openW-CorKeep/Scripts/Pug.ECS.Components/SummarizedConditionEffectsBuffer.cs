using Unity.Entities;

[InternalBufferCapacity(0)]
public struct SummarizedConditionEffectsBuffer : IBufferElementData
{
	public int value;
}
