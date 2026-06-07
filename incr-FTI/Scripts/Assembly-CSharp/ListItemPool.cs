using System.Collections.Generic;
using UnityEngine;

public class ListItemPool<T> where T : MonoBehaviour
{
	public readonly List<T> pool;

	private int itemIndex;

	private GameObject poolPrefab;

	public ListItemPool(GameObject prefab)
	{
		pool = new List<T>();
		poolPrefab = prefab;
	}

	public void Reset()
	{
		itemIndex = 0;
		foreach (T item in pool)
		{
			item.gameObject.SetActive(value: false);
		}
	}

	public T GetItem(int placementIndex, Transform targetTransform)
	{
		T val;
		if (itemIndex < pool.Count)
		{
			val = pool[itemIndex];
			if (val.transform.parent != targetTransform)
			{
				val.transform.SetParent(targetTransform);
			}
		}
		else
		{
			val = MenuManager.GetMenuObject(poolPrefab, targetTransform).GetComponent<T>();
			pool.Add(val);
		}
		val.transform.SetSiblingIndex(placementIndex);
		val.gameObject.SetActive(value: true);
		itemIndex++;
		return val;
	}
}
