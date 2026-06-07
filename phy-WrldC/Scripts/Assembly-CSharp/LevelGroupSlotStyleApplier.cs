using UnityEngine;

[RequireComponent(typeof(LevelGroupSlot))]
public class LevelGroupSlotStyleApplier : StylesApplierBase
{
	private LevelGroupSlot levelGroupSlot;

	public override void Initialize()
	{
		levelGroupSlot = GetComponent<LevelGroupSlot>();
	}

	public override void UpdateStyles()
	{
	}

	public override void UpdateTexts()
	{
		if (!(levelGroupSlot == null))
		{
			levelGroupSlot.LevelToUnlockTextBegin = languages.GetText("label.text.level.morelevelbegin", "Complete more");
			levelGroupSlot.LevelToUnlockTextEnd = languages.GetText("label.text.level.morelevelend", "levels to unlock");
			levelGroupSlot.RefreshLabels();
		}
	}
}
