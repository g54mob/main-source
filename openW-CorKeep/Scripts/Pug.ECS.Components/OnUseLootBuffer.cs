using Unity.Entities;

[InternalBufferCapacity(1)]
public struct OnUseLootBuffer : IBufferElementData
{
	public ObjectID lootDropID;

	public int amount;

	public float chance;
}
