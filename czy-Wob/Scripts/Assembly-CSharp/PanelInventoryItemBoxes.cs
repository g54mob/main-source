using System.Collections.Generic;
using UnityEngine;

public class PanelInventoryItemBoxes : BoxList
{
	public InventoryPanel mainPanel;

	private ObjectGrabber grabberRef;

	private InventoryManager managerRef;

	private void Awake()
	{
		boxOffsetY = 3f;
		boxesPerRow = 3;
		rowsPerScreen = 4;
		scaleInTime = 0.5f;
		scaleOutTime = 0.5f;
		scaleInOffset = 0.025f;
		scaleOutOffset = 0.01f;
	}

	public override void Preload()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		managerRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		base.Preload();
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		RemoveClickables();
		grabberRef.StopHoldingObjectForPlacement();
		needsDelayedScaleOut = true;
		callback = unloadCallback;
		OnUnloadComplete();
	}

	public override object GetSelectedObject()
	{
		return (InventoryItem)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)];
	}

	protected override GameObject GetPreviewObjectForObject(object obj)
	{
		return Object.Instantiate(((InventoryItem)obj).itemPrefab);
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return ((InventoryItem)heldObjectsOfType[index]).itemNameLocalized;
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return ((InventoryItem)heldObjectsOfType[index]).itemDescriptionLocalized;
	}

	protected override void UpdateHeldObjectsOfType()
	{
		List<InventoryItem> heldItemsOfType = managerRef.GetHeldItemsOfType(ItemType.TOY);
		heldObjectsOfType.Clear();
		for (int i = 0; i < heldItemsOfType.Count; i++)
		{
			heldObjectsOfType.Add(heldItemsOfType[i]);
		}
	}

	protected override int GetNumObjectsForIndex(int index)
	{
		return managerRef.GetNumberOfItemHeld((InventoryItem)heldObjectsOfType[index]);
	}

	protected override List<object> GetAllObjects()
	{
		List<object> list = new List<object>();
		List<InventoryItem> heldItemsOfType = managerRef.GetHeldItemsOfType(ItemType.TOY);
		for (int i = 0; i < heldItemsOfType.Count; i++)
		{
			list.Add(heldItemsOfType[i]);
		}
		return list;
	}
}
