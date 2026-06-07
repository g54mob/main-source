using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlotsamPool
{
	private List<FlotsamPropertiesPool> _pools;

	private Transform _pooledParent;

	private static FlotsamPool _instance;

	public static Transform PooledParent => Instance.ReturnPooledParent();

	public static FlotsamPool Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new FlotsamPool();
			}
			return _instance;
		}
	}

	private FlotsamPool()
	{
		_pools = new List<FlotsamPropertiesPool>();
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	~FlotsamPool()
	{
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	public int Aquire(out FlotsamBehaviour flotsam, FlotsamProperties properties, Vector3 position, bool interactable, int preferredIndex = -1)
	{
		if (properties == null)
		{
			Debug.Log("Unable to aquire interactable flotsam because the properties are null.");
			flotsam = null;
			return -1;
		}
		if (interactable)
		{
			return ReturnPool(properties).AquireInteractable(out flotsam, position, preferredIndex);
		}
		return ReturnPool(properties).AquireNonInteractable(out flotsam, position, preferredIndex);
	}

	public void Release(FlotsamBehaviour flotsam)
	{
		if (flotsam.Pooled)
		{
			Debug.LogErrorFormat("'{0}' is being released to the FlotsamPool, but it is already pooled!", flotsam.name);
		}
		else
		{
			ReturnPool(flotsam.Properties).Release(flotsam);
		}
	}

	private void OnSceneUnloaded(Scene scene)
	{
		foreach (FlotsamPropertiesPool pool in _pools)
		{
			pool.RemoveDestroyed();
		}
	}

	public FlotsamPropertiesPool ReturnPool(FlotsamProperties properties)
	{
		int count = _pools.Count;
		FlotsamPropertiesPool flotsamPropertiesPool;
		for (int i = 0; i < count; i++)
		{
			flotsamPropertiesPool = _pools[i];
			if (flotsamPropertiesPool.Properties == properties)
			{
				return flotsamPropertiesPool;
			}
		}
		flotsamPropertiesPool = new FlotsamPropertiesPool(properties);
		_pools.Add(flotsamPropertiesPool);
		return flotsamPropertiesPool;
	}

	private Transform ReturnPooledParent()
	{
		if ((bool)_pooledParent)
		{
			return _pooledParent;
		}
		_pooledParent = new GameObject().transform;
		_pooledParent.name = "Pool";
		_pooledParent.transform.SetParent(GameManager.WorldManager.FlotsamParent);
		_pooledParent.position = Vector3.zero;
		return _pooledParent;
	}
}
