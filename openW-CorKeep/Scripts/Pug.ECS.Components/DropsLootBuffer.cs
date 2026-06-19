using Pug.UnityExtensions;
using Unity.Entities;

[InternalBufferCapacity(0)]
public struct DropsLootBuffer : IBufferElementData
{
	public ObjectID lootDropID;

	public int amount;

	public float multiplayerAmountAdditionScaling;

	public OptionalValue<ObjectID> skipIfScanned;

	public OptionalValue<DataBlockAddress> requiredContentBundle;
}
