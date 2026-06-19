public class BossStatueRecipesUI : RecipesUI
{
	public override int MAX_ROWS => 2;

	public override int MAX_COLUMNS => 3;

	public override bool centerLayout => true;

	public override void Init()
	{
		if (initDone)
		{
			return;
		}
		base.visibleRows = MAX_ROWS;
		base.visibleColumns = MAX_COLUMNS;
		itemSlotsRoot.SetActive(value: false);
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.Init(this);
		}
		initDone = true;
	}
}
