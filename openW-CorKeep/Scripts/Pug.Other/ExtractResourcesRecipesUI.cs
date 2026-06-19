public class ExtractResourcesRecipesUI : RecipesUI
{
	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 1;

	public override void ShowContainerUI()
	{
		itemSlotsRoot.gameObject.SetActive(value: true);
		if (scrollWindow != null)
		{
			scrollWindow.enabled = true;
		}
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.gameObject.SetActive(value: true);
			itemSlot.UpdateSlot();
		}
	}

	public override void HighlightRecipe(ObjectID recipe)
	{
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}
}
