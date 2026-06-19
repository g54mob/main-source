using Unity.Entities;

[InternalBufferCapacity(0)]
public struct RoomObjectBuffer : IBufferElementData
{
	public ObjectDataCD Value;
}
