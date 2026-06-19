using Unity.Entities;

[InternalBufferCapacity(4)]
public struct ManaChangeBuffer : IBufferElementData
{
	public ManaChange manaChange;
}
