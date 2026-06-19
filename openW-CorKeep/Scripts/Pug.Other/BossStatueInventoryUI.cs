public class BossStatueInventoryUI : InventoryUI
{
	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 1;

	public override void Init()
	{
		if (initDone)
		{
			return;
		}
		base.visibleRows = MAX_ROWS;
		base.visibleColumns = MAX_COLUMNS;
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.Init(this);
		}
		base.firstSlot = itemSlots[0];
		itemSlotsRoot.SetActive(value: false);
		initDone = true;
	}
}
