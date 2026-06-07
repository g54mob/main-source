using UnityEngine;

[RequireComponent(typeof(GroupLevelDetailSlot))]
public class GroupLevelDetailSlotStyleApplier : StylesApplierBase
{
	private GroupLevelDetailSlot groupLevelDetailSlot;

	public override void Initialize()
	{
		groupLevelDetailSlot = GetComponent<GroupLevelDetailSlot>();
	}

	public override void UpdateStyles()
	{
	}

	public override void UpdateTexts()
	{
		if (!(groupLevelDetailSlot == null) && groupLevelDetailSlot.SelectedLevelModel != null)
		{
			groupLevelDetailSlot.RefreshLabels();
		}
	}
}
