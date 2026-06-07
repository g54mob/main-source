using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using UnityEngine;

public class DV_GameObjectPools : SingletonBehaviour<DV_GameObjectPools>
{
	public enum GameObjectCategory
	{
		Coal = 0,
		CoalChunksSmall = 1,
		CoalChunksLarge = 2
	}

	private const string GAME_OBJECT_POOLS_PARENT_NAME = "[GameObjectPoolParent]";

	public DV_GameObjectPoolsReferences objectPoolReferences;

	private Dictionary<GameObjectCategory, DV_GameObjectPoolsReferences.DV_GameObjectPoolData> categoryToPoolData = new Dictionary<GameObjectCategory, DV_GameObjectPoolsReferences.DV_GameObjectPoolData>();

	private Dictionary<GameObjectCategory, List<GameObject>> gameObjectPool = new Dictionary<GameObjectCategory, List<GameObject>>();

	private Dictionary<GameObjectCategory, List<Collider>> colliderCache = new Dictionary<GameObjectCategory, List<Collider>>();

	private Transform poolParent;

	protected override void Awake()
	{
		base.Awake();
		poolParent = new GameObject("[GameObjectPoolParent]").transform;
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			poolParent.parent = WorldMover.OriginShiftParent;
			poolParent.localPosition = Vector3.zero;
			poolParent.localRotation = Quaternion.identity;
		}
		GeneratePools();
	}

	private void GeneratePools()
	{
		foreach (DV_GameObjectPoolsReferences.DV_GameObjectPoolData poolDatum in objectPoolReferences.poolData)
		{
			categoryToPoolData[poolDatum.gameObjectCategory] = poolDatum;
			GameObjectCategory gameObjectCategory = poolDatum.gameObjectCategory;
			gameObjectPool[gameObjectCategory] = new List<GameObject>();
			if (poolDatum.disableCollisionsInPool)
			{
				colliderCache[poolDatum.gameObjectCategory] = new List<Collider>();
			}
			for (int i = 0; i < poolDatum.poolSize; i++)
			{
				GameObject item = InstantateGameObject(gameObjectCategory, poolDatum.disableCollisionsInPool);
				gameObjectPool[gameObjectCategory].Add(item);
			}
		}
		StartCoroutine(DisableAndAdjustTransformValues());
	}

	private GameObject InstantateGameObject(GameObjectCategory gameObjectCategory, bool disableCollisionsInPool)
	{
		DV_GameObjectPoolsReferences.DV_GameObjectPoolData dV_GameObjectPoolData = categoryToPoolData[gameObjectCategory];
		int max = dV_GameObjectPoolData.gameObjectPrefabs.Length;
		int num = Random.Range(0, max);
		GameObject gameObject = Object.Instantiate(dV_GameObjectPoolData.gameObjectPrefabs[num]);
		gameObject.AddComponent<DV_GameObjectPoolMarker>().gameObjectPoolCategory = gameObjectCategory;
		if (disableCollisionsInPool && colliderCache.TryGetValue(gameObjectCategory, out var value))
		{
			Collider componentInChildren = gameObject.GetComponentInChildren<Collider>();
			foreach (Collider item in value)
			{
				Physics.IgnoreCollision(componentInChildren, item);
			}
			value.Add(componentInChildren);
		}
		return gameObject;
	}

	private IEnumerator DisableAndAdjustTransformValues()
	{
		yield return null;
		yield return WaitFor.EndOfFrame;
		foreach (GameObject item in gameObjectPool.SelectMany((KeyValuePair<GameObjectCategory, List<GameObject>> t) => t.Value))
		{
			item.SetActive(value: false);
			item.transform.SetParent(poolParent);
			item.transform.localPosition = Vector3.zero;
			item.transform.localRotation = Quaternion.identity;
		}
	}

	public GameObject RequestObjectFromPool(GameObjectCategory gameObjectCategory)
	{
		return GetGameObjectFromPool(gameObjectCategory);
	}

	private GameObject GetGameObjectFromPool(GameObjectCategory gameObjectCategory)
	{
		if (gameObjectPool.TryGetValue(gameObjectCategory, out var value))
		{
			GameObject gameObject = FetchFromPool(value);
			if (gameObject != null)
			{
				return gameObject;
			}
			if (categoryToPoolData.TryGetValue(gameObjectCategory, out var value2))
			{
				return InstantateGameObject(gameObjectCategory, value2.disableCollisionsInPool);
			}
		}
		return null;
	}

	private GameObject FetchFromPool(List<GameObject> pool)
	{
		int num = pool.Count - 1;
		if (num >= 0)
		{
			GameObject result = pool[num];
			pool.RemoveAt(num);
			return result;
		}
		return null;
	}

	public void ReturnGameObjectToPool(GameObject go, GameObjectCategory gameObjectCategory)
	{
		if (!(go == null))
		{
			go.SetActive(value: false);
			List<GameObject> list = gameObjectPool[gameObjectCategory];
			if (!list.Contains(go))
			{
				list.Add(go);
				go.transform.SetParent(poolParent);
				go.transform.localPosition = Vector3.zero;
				go.transform.localRotation = Quaternion.identity;
			}
		}
	}

	public List<GameObject> GetEntirePool(GameObjectCategory gameObjectCategory)
	{
		return gameObjectPool[gameObjectCategory];
	}
}
