using System;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
	[Header("Components")]
	public PlayerInventory playerInventory;

	public InventoryManager inventoryManager;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Data")]
	public List<InventoryItem> Inventory;

	private void OnValidate()
	{
	}

	private void FindAndSetComponent<T>(ref T componentField, Action act = null) where T : UnityEngine.Object
	{
	}

	private bool CheckAndAddCollider(Transform obj)
	{
		return false;
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

	private void OpenTrash(KeyCode key, object[] param)
	{
	}
}
