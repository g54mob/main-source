using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField]
	private GameObject gameObjectPrefab;

	[SerializeField]
	private int amountToPool;

	[SerializeField]
	private Transform parentTf;

	private List<GameObject> gameObjectPool = new List<GameObject>();

	private void Awake()
	{
		if (parentTf == null)
		{
			parentTf = base.transform;
		}
		if (gameObjectPrefab == null)
		{
			gameObjectPool = new List<GameObject>();
		}
		for (int i = 0; i < amountToPool; i++)
		{
			GameObject gameObject = Object.Instantiate(gameObjectPrefab, parentTf);
			gameObject.SetActive(value: false);
			gameObjectPool.Add(gameObject);
		}
	}

	public GameObject GetPooledGameObject()
	{
		for (int i = 0; i < gameObjectPool.Count; i++)
		{
			if (!gameObjectPool[i].activeInHierarchy)
			{
				return gameObjectPool[i];
			}
		}
		return null;
	}
}
