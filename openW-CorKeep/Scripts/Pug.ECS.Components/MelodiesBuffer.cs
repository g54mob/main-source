using Unity.Entities;

[InternalBufferCapacity(1)]
public struct MelodiesBuffer : IBufferElementData
{
	public MelodyID melodyID;
}
