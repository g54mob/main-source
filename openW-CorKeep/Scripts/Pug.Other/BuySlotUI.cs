public class BuySlotUI : InventorySlotUI
{
	public override void UpdateSlot()
	{
		darkBackground.enabled = false;
		base.UpdateSlot();
	}
}
