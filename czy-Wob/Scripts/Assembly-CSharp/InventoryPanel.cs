using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
	public GameObject panelInventoryPrefab;

	public GameObject newToyIndicator;

	private GameObject createdInventory;

	private PlayerInventory inventoryRef;

	private void Awake()
	{
		newToyIndicator.SetActive(value: false);
	}

	private void Start()
	{
		inventoryRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
	}

	public void OpenPanel()
	{
		if (!(createdInventory != null))
		{
			createdInventory = Object.Instantiate(panelInventoryPrefab);
			createdInventory.GetComponent<PanelInventoryGUIController>().SetPanelRef(this);
		}
	}

	public void ClosePanel()
	{
		if (!(createdInventory == null))
		{
			createdInventory.GetComponent<PanelInventoryGUIController>().CloseGUI();
			createdInventory = null;
		}
	}

	public void RefreshPanel(InventoryItem newItem)
	{
		if (createdInventory != null)
		{
			createdInventory.GetComponent<PanelInventoryGUIController>().boxesRef.RefreshBoxes(newItem);
		}
	}

	public void ClearNewObjects()
	{
		inventoryRef.ClearNewItems();
		SyncNewIndicator();
	}

	public void SyncNewIndicator()
	{
		if (!(newToyIndicator == null))
		{
			if (createdInventory != null)
			{
				newToyIndicator.SetActive(value: false);
			}
			else if (inventoryRef != null)
			{
				newToyIndicator.SetActive(inventoryRef.DoesInventoryHaveNewItems());
			}
		}
	}
}
