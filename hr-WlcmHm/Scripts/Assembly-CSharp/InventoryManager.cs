using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public List<string> inventoryItems = new List<string>();

	public static InventoryManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void AddItem(string item)
	{
		if (!inventoryItems.Contains(item))
		{
			inventoryItems.Add(item);
			Debug.Log("Added item: " + item);
		}
	}
}
