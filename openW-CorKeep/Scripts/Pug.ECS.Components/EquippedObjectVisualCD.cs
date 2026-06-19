using Unity.Entities;

public struct EquippedObjectVisualCD : IComponentData, IQueryTypeParameter
{
	public int equippedSlotIndex;

	public ContainedObjectsBuffer containedObject;

	public int rotationVariationToPlace;

	public int nonRotationVariationToPlace;

	public int sizeVariationToPlace;
}
