using System.Collections.Generic;
using UnityEngine;

public class ObjectUnlockController : MonoBehaviour
{
	private Dictionary<InventoryItem, bool> objectUnlockStatus = new Dictionary<InventoryItem, bool>();

	public void RegisterObject(InventoryItem item)
	{
		objectUnlockStatus[item] = false;
	}

	public bool IsObjectUnlocked(InventoryItem item)
	{
		return objectUnlockStatus[item];
	}

	public void UnlockObject(InventoryItem item)
	{
		objectUnlockStatus[item] = true;
	}
}
