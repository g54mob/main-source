using Unity.Entities;

[InternalBufferCapacity(3)]
public struct EquipmentPresetsBuffer : IBufferElementData
{
	public const int MaxEquipmentPresets = 3;

	public EquipmentCD equipment;
}
