using Unity.Entities;

public struct TrashCanCD : IComponentData, IQueryTypeParameter
{
	public int slotIndex;
}
