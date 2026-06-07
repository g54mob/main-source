using System.Collections.Generic;
using UnityEngine;

public class QuickInventoryView : QuickInventoryViewBase<CreationView, CreationModel>
{
	protected override void ActionBeforeClearAllTabsAndSlots()
	{
		quickInventorySlotsPanels.ForEach(delegate(List<QuickInventorySlotBase<CreationView, CreationModel>> panel)
		{
			panel.ForEach(delegate(QuickInventorySlotBase<CreationView, CreationModel> slot)
			{
				slot.ItemView.RecycleAllBlocksBeforeDestroying();
			});
		});
	}

	protected override void ActionBeforeRemoveSlot(QuickInventorySlotBase<CreationView, CreationModel> slot)
	{
		slot.ItemView.RecycleAllBlocksBeforeDestroying();
	}

	protected override GameObject GetNewTabObject(Transform objectParent, int tabIndex, string objectName)
	{
		return ObjectPools.Instance.GetInstanceForUI("quick_inventory_tab", objectParent, tabIndex, objectName);
	}

	protected override GameObject GetNewSlotObject(Transform objectParent, string objectName)
	{
		return ObjectPools.Instance.GetInstanceForUI("quick_inventory_slot", objectParent, -1, objectName);
	}
}
