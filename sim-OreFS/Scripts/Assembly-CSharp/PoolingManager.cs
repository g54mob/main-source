using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
	[Serializable]
	public class PoolingRule
	{
		public LayerVFX PoolingType;

		public GameObject objectToPool;

		public int amountToPool;

		public List<GameObject> pooledObjects;
	}

	public List<PoolingRule> poolData;

	private void Start()
	{
		foreach (PoolingRule poolDatum in poolData)
		{
			for (int i = 0; i < poolDatum.amountToPool; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(poolDatum.objectToPool);
				gameObject.transform.parent = base.transform;
				gameObject.SetActive(value: false);
				poolDatum.pooledObjects.Add(gameObject);
			}
		}
	}

	public GameObject GetPooledObjectByType(LayerVFX type)
	{
		foreach (PoolingRule poolDatum in poolData)
		{
			if (poolDatum.PoolingType != type)
			{
				continue;
			}
			for (int i = 0; i < poolDatum.pooledObjects.Count; i++)
			{
				if (poolDatum.pooledObjects[i] != null && !poolDatum.pooledObjects[i].activeInHierarchy)
				{
					return poolDatum.pooledObjects[i];
				}
			}
		}
		return null;
	}
}
