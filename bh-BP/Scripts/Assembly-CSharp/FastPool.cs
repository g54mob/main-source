using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FastPool<T> where T : FastPooledObject
{
	public delegate void ObjPoolEvent(T obj);

	public T Prefab;

	public List<T> ActiveObjs;

	public List<T> PendingRemovals;

	public List<T> Pool;

	public Transform OwnerXfm;

	public T this[int i]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int Count => 0;

	public FastPool(T prefab)
	{
	}

	public T Get(Transform parent = null)
	{
		return null;
	}

	public void LateUpdate()
	{
	}

	public void InitSize(int num, Transform parent)
	{
	}

	public void DisableAt(int index)
	{
	}

	private void InsertIntoSortedList(List<T> list, T obj)
	{
	}

	private int GetSortedListIdx(List<T> list, int poolIdx)
	{
		return 0;
	}

	private int GetSortedListIdx(List<T> list, int poolIdx, int startListIdx, int endListIdx)
	{
		return 0;
	}

	public void DisableObj(T activeObj)
	{
	}

	public void DisableAll()
	{
	}
}
