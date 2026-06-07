using System;
using UnityEngine;

[Serializable]
public class LandmarkScavengeablePersistentData : ILandmarkInteractablePersistentData
{
	private InventoryPersistentData[] _inventories;

	private int[] _researchPoints;

	public LandmarkScavengeablePersistentData()
	{
	}

	public LandmarkScavengeablePersistentData(Landmark landmark)
	{
		LandmarkScavengeable[] componentsInChildren = landmark.GetComponentsInChildren<LandmarkScavengeable>();
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			_inventories = null;
			return;
		}
		_inventories = new InventoryPersistentData[componentsInChildren.Length];
		_researchPoints = new int[componentsInChildren.Length];
		for (int i = 0; i < _inventories.Length; i++)
		{
			_inventories[i] = new InventoryPersistentData(componentsInChildren[i].Inventory);
		}
	}

	public void Restore(Landmark landmark)
	{
		LandmarkScavengeable[] componentsInChildren = landmark.GetComponentsInChildren<LandmarkScavengeable>();
		int i = 0;
		if (_inventories == null)
		{
			return;
		}
		for (; i < _inventories.Length; i++)
		{
			if (i < componentsInChildren.Length)
			{
				componentsInChildren[i].RestoreInventory(_inventories[i]);
			}
		}
		for (; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
		}
	}
}
