using Unity.Entities;

[InternalBufferCapacity(16)]
public struct EffectEventBuffer : IBufferElementData
{
	public EffectEventCD Value;
}
