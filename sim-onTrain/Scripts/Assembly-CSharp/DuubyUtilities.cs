using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DuubyUtilities
{
	public static Transform FindClosestObject(Vector3 target, List<Transform> objectsToSearch)
	{
		if (objectsToSearch.Count == 0)
		{
			Debug.LogWarning("No objects to search.");
			return null;
		}
		return objectsToSearch.OrderBy((Transform obj) => Vector3.Distance(obj.position, target)).FirstOrDefault();
	}

	public static SnapPointPositionData FindClosestSnapData(Vector3 target, List<SnapPointPositionData> objectsToSearch)
	{
		if (objectsToSearch.Count == 0)
		{
			Debug.LogWarning("No objects to search.");
			return new SnapPointPositionData();
		}
		return objectsToSearch.OrderBy((SnapPointPositionData obj) => Vector3.Distance(obj.transform.position, target)).FirstOrDefault();
	}

	public static IEnumerator WaitEndOfFixedUpdate(Action action)
	{
		yield return new WaitForFixedUpdate();
		action();
	}

	public static IEnumerator WaitForEndOfTheFrame(Action action)
	{
		yield return new WaitForEndOfFrame();
		action();
	}

	public static bool ItNeededItemsExit(CollectableItemData collectableItemData, PlayerInventory inventory)
	{
		List<CostData> costData = collectableItemData.costData;
		if (costData.Count == 0)
		{
			return true;
		}
		bool result = true;
		foreach (CostData neededItem in costData)
		{
			if ((inventory.inventoryData.Find((PlayerInventoryData x) => neededItem.item == x.item)?.itemCollectedCount ?? 0) < neededItem.cost)
			{
				result = false;
				break;
			}
		}
		return result;
	}
}
