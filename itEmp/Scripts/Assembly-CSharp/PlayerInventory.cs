using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public static PlayerInventory instance;

	[Header("Components")]
	public InventoryManager inventoryManager;

	[Header("Data")]
	public List<InventoryItem> Inventory;

	private void Awake()
	{
	}
}
