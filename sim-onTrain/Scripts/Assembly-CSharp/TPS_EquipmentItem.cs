using HQFPSTemplate.Equipment;
using HQFPSTemplate.Items;

public class TPS_EquipmentItem : EquipmentItem
{
	public bool isEnabled;

	public override void Equip(Item item)
	{
		isEnabled = true;
	}

	public override void Unequip()
	{
		isEnabled = false;
	}
}
