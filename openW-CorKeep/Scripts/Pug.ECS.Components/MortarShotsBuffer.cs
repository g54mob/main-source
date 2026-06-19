using Unity.Entities;

[InternalBufferCapacity(4)]
public struct MortarShotsBuffer : IBufferElementData
{
	public Entity entity;
}
