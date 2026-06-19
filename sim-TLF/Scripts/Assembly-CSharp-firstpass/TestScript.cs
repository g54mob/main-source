using UnityEngine;
using UniversalInventorySystem;
using Zenject;

[RequireComponent(typeof(InventoryUI))]
public class TestScript : MonoBehaviour
{
	[Inject]
	private InventoryHandler inventoryHandler;

	private Inventory inventory;

	private InventoryUI invUI;

	private void Start()
	{
		invUI = GetComponent<InventoryUI>();
		inventory = invUI.GetInventory();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			inventory.AddItem(inventoryHandler.GetItem(0, 0), 12);
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			inventory.AddItem(inventoryHandler.GetItem(0, 2), 1);
		}
	}
}
