using Unity.Entities;

public struct UpgradeSlotCD : IComponentData, IQueryTypeParameter
{
	public int slotIndex;
}
