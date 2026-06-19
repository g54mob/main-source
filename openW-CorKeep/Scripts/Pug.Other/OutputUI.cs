public class OutputUI : ItemSlotsUIContainer
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
		itemSlotsRoot.SetActive(keepSlotsEnabledAfterInit);
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.Init(this);
		}
		initDone = true;
	}

	public override void ShowContainerUI()
	{
		base.ShowContainerUI();
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.UpdateSlot();
		}
	}
}
