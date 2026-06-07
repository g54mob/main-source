using UnityEngine;

public class LEQuickInventoryView : QuickInventoryViewBase<Transform, CustomLevelObjectsModel>
{
	protected override void ActionBeforeClearAllTabsAndSlots()
	{
	}

	protected override void ActionBeforeRemoveSlot(QuickInventorySlotBase<Transform, CustomLevelObjectsModel> slot)
	{
	}

	protected override GameObject GetNewTabObject(Transform objectParent, int tabIndex, string objectName)
	{
		return ObjectPools.Instance.GetInstanceForUI("le_quick_inventory_tab", objectParent, tabIndex, objectName);
	}

	protected override GameObject GetNewSlotObject(Transform objectParent, string objectName)
	{
		return ObjectPools.Instance.GetInstanceForUI("le_quick_inventory_slot", objectParent, -1, objectName);
	}
}
