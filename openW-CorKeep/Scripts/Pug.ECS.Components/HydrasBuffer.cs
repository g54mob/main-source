using Unity.Entities;

[InternalBufferCapacity(4)]
public struct HydrasBuffer : IBufferElementData
{
	public Entity hydra;
}
