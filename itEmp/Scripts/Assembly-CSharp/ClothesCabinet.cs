using System.Collections.Generic;
using UnityEngine;

public class ClothesCabinet : MonoBehaviour
{
	public static ClothesCabinet Instance;

	[Header("Components")]
	public PlayerInventory playerInventory;

	public InventoryManager inventoryManager;

	[Header("Detection")]
	public DetectionManager detectionManager;

	public DoorControllerPro doorController;

	[Header("Data")]
	public List<InventoryItem> Inventory;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private void OpenLockerInventory(KeyCode key, object[] param)
	{
	}
}
