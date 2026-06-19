using UnityEngine;

public class Inventory_DynamicTest : MonoBehaviour
{
	private ElementStatus currentStatus = ElementStatus.UNLOADED;

	private bool needsLoad;

	private bool needsUnload;

	private UIElementContainer inventoryContainer;

	private void Update()
	{
		if (needsLoad && currentStatus == ElementStatus.UNLOADED)
		{
			needsLoad = false;
			LoadInventory();
		}
		else if (needsUnload && currentStatus == ElementStatus.LOADED)
		{
			needsUnload = false;
			UnloadInventory();
		}
	}

	public void LoadInventory()
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			needsLoad = true;
			needsUnload = false;
		}
		else
		{
			currentStatus = ElementStatus.LOADING;
		}
	}

	public void UnloadInventory()
	{
		if (currentStatus != ElementStatus.LOADED)
		{
			needsUnload = true;
			needsLoad = false;
		}
		else
		{
			currentStatus = ElementStatus.UNLOADING;
			inventoryContainer.Unload(InventoryUnloadedCallback);
		}
	}

	private void InventoryLoadedCallback()
	{
		currentStatus = ElementStatus.LOADED;
	}

	private void InventoryUnloadedCallback()
	{
		currentStatus = ElementStatus.UNLOADED;
		inventoryContainer = null;
	}
}
