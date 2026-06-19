using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EquipmentCD : IComponentData, IQueryTypeParameter
{
	public int helmSlotIndex;

	public int necklaceSlotIndex;

	public int breastSlotIndex;

	public int pantsSlotIndex;

	public int ring1SlotIndex;

	public int ring2SlotIndex;

	public int offHandIndex;

	public int bagIndex;

	public int lanternIndex;

	public int pouch1Index;

	public int pouch2Index;

	public int pouch3Index;

	public int pouch4Index;

	public int GetPouchSlotIndex(int index)
	{
		return index switch
		{
			0 => pouch1Index, 
			1 => pouch2Index, 
			2 => pouch3Index, 
			3 => pouch4Index, 
			_ => -1, 
		};
	}

	public void SetPouchSlotIndex(int index, int slotIndex)
	{
		switch (index)
		{
		case 0:
			pouch1Index = slotIndex;
			break;
		case 1:
			pouch2Index = slotIndex;
			break;
		case 2:
			pouch3Index = slotIndex;
			break;
		case 3:
			pouch4Index = slotIndex;
			break;
		}
	}
}
