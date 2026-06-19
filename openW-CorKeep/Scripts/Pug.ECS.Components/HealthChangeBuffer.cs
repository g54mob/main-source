using Unity.Entities;

[InternalBufferCapacity(16)]
public struct HealthChangeBuffer : IBufferElementData
{
	public HealthChange healthChange;
}
