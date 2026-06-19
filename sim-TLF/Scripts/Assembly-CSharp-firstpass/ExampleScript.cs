using UnityEngine;
using UniversalInventorySystem;
using Zenject;

public class ExampleScript : MonoBehaviour
{
	[Inject]
	private InventoryHandler inventoryHandler;

	private Inventory inventory;

	public InventoryUI invUI;

	public InventoryUI invUI2;

	public Item testItem;

	public int slotAmount;

	private void Start()
	{
		inventory = new Inventory(slotAmount, true, InventoryProtection.InventoryToInventory | InventoryProtection.SlotToSlot | InventoryProtection.Add | InventoryProtection.Remove | InventoryProtection.Use | InventoryProtection.Drop, true);
		inventory.Initialize();
		invUI.SetInventory(inventory);
		invUI2.SetInventory(inventory);
		InventoryHandler obj = inventoryHandler;
		obj.OnAddItem += OnAddItem;
		obj.OnRemoveItem += OnRemoveItem;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			inventory.AddItem(inventoryHandler.GetItem(0, 0), 2);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			inventory.AddItem(inventoryHandler.GetItem(0, 1), 2);
		}
	}

	private void OnRemoveItem(object sender, InventoryHandler.RemoveItemEventArgs e)
	{
		Debug.Log("Remove (ExampleScript)");
	}

	private void OnAddItem(object sender, InventoryHandler.AddItemEventArgs e)
	{
		Debug.Log("The item " + e.itemAdded.name + " was added (ExampleScript)");
	}

	private void OnDestroy()
	{
		inventoryHandler.OnAddItem -= OnAddItem;
		inventoryHandler.OnRemoveItem -= OnRemoveItem;
	}
}
