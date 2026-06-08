using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class MasterObjectPool : MonoBehaviour
{
	public static MasterObjectPool Instance;

	[SerializeField]
	private int initialCount = 25;

	[SerializeField]
	private List<ElementVisual> pooledElementVisuals;

	[SerializeField]
	private List<Instanceable> pooledRecyclables;

	[SerializeField]
	private List<GameObject> otherPooledObjects;

	private Dictionary<RecyclableType, ObjectPool> objectPools;

	private int idCounter;

	protected void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		objectPools = new Dictionary<RecyclableType, ObjectPool>();
		foreach (ElementVisual pooledElementVisual in pooledElementVisuals)
		{
			if (pooledElementVisual.RecyclableId == RecyclableType.Undefined)
			{
				Debug.LogError($"{pooledElementVisual} has no RecyclableType assigned");
			}
			else
			{
				objectPools.Add(pooledElementVisual.RecyclableId, CreateObjectPool(pooledElementVisual));
			}
		}
		foreach (GameObject otherPooledObject in otherPooledObjects)
		{
			IRecyclable component = otherPooledObject.GetComponent<IRecyclable>();
			if (component == null)
			{
				Debug.LogError($"{otherPooledObject} is no RecyclableObject");
			}
			else
			{
				objectPools.Add(component.RecyclableId, CreateObjectPool((Component)component));
			}
		}
		foreach (Instanceable pooledRecyclable in pooledRecyclables)
		{
			objectPools.Add(pooledRecyclable.RecyclableId, CreateObjectPool(pooledRecyclable));
		}
	}

	private ObjectPool CreateObjectPool(Component pooledComponent)
	{
		GameObject obj = new GameObject();
		obj.transform.parent = base.transform;
		ObjectPool objectPool = obj.AddComponent<ObjectPool>();
		objectPool.Initialize(pooledComponent, 0);
		return objectPool;
	}

	public T GetObject<T>(RecyclableType recyclableType) where T : MonoBehaviour, IRecyclable
	{
		if (!objectPools.ContainsKey(recyclableType))
		{
			Debug.LogError($"no object pool for {recyclableType}");
			return null;
		}
		return objectPools[recyclableType].GetObject().GetComponent<T>();
	}

	public T GetObject<T>(T referencePrefab) where T : MonoBehaviour, IRecyclable
	{
		if (!objectPools.ContainsKey(referencePrefab.RecyclableId))
		{
			return Object.Instantiate(referencePrefab);
		}
		return objectPools[referencePrefab.RecyclableId].GetObject().GetComponent<T>();
	}

	public void StoreObject(IRecyclable objectToStore)
	{
		if (objectToStore.RecyclableId == RecyclableType.Undefined || !objectPools.ContainsKey(objectToStore.RecyclableId))
		{
			objectToStore.GameObject.SetActive(value: false);
			Object.Destroy(objectToStore.GameObject);
		}
		else
		{
			objectPools[objectToStore.RecyclableId].StoreObject(objectToStore.GameObject);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
