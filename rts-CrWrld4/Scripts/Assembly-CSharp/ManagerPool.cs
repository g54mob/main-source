using System.Collections.Generic;
using UnityEngine;

public class ManagerPool<T> where T : Component
{
	private GameObject objectPrefab;

	private Stack<T> inactiveManagers;

	private HashSet<T> activeManagers;

	private int limit;

	public ManagerPool(GameObject prefab, int limit = 0)
	{
	}

	public T Get()
	{
		return null;
	}

	public void Pool(T manager)
	{
	}

	public T[] GetActiveManagers()
	{
		return null;
	}
}
