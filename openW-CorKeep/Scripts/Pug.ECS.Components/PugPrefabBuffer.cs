using Unity.Entities;

[InternalBufferCapacity(64)]
public struct PugPrefabBuffer : IBufferElementData
{
	public Entity Value;
}
