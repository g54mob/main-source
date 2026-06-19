using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(5)]
public struct PlacementSizeByEquipmentTypeBuffer : IBufferElementData
{
	[GhostField]
	public byte sizeVariationToPlace;

	public const int EquipmentWithPlacementSize = 5;
}
