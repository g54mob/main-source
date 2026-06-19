using Unity.Entities;

[InternalBufferCapacity(0)]
public struct AdaptiveEntityBuffer : IBufferElementData
{
	public AdaptiveCondition adaptiveCondition;
}
