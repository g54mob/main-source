public class EquipmentInventoryUI : InventoryUI
{
	public PouchesWindow pouchesWindow;

	public override int MAX_ROWS => 3;

	public override int MAX_COLUMNS => 3;

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
		if (pouchesWindow != null)
		{
			itemHoverProxies.Add(pouchesWindow);
		}
		initDone = true;
	}
}
