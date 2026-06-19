using Unity.Entities;

[InternalBufferCapacity(2)]
public struct GivesConditionsWhenEquippedBuffer : IBufferElementData
{
	public EquipmentCondition equipmentCondition;
}
