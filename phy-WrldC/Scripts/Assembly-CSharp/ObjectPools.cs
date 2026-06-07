using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
	public delegate GameObject RealInstantiationMethod();

	private class Pool
	{
		private readonly RealInstantiationMethod realInstantiation;

		public string ObjectTypeId { get; }

		public GameObject PoolFolder { get; set; }

		public Queue<GameObject> InstancesQueue { get; }

		public Pool(string objectTypeId, Transform parentFolder, RealInstantiationMethod realInstantiation)
		{
			ObjectTypeId = objectTypeId;
			InstancesQueue = new Queue<GameObject>();
			PoolFolder = new GameObject(objectTypeId);
			PoolFolder.transform.SetParent(parentFolder);
			this.realInstantiation = realInstantiation;
		}

		public GameObject NewRealInstance()
		{
			GameObject gameObject = realInstantiation();
			IRecyclableObject component = gameObject.GetComponent<IRecyclableObject>();
			if (component != null)
			{
				component.ObjectTypeId = ObjectTypeId;
			}
			return gameObject;
		}

		public void RefreshInstancesCounter()
		{
			PoolFolder.name = ObjectTypeId + " [" + InstancesQueue.Count + "]";
		}
	}

	[SerializeField]
	private GameObject poolsFolder;

	private Dictionary<string, Pool> pools;

	private Queue<GameObject> toUninstantiationIntances;

	public static ObjectPools Instance => Singleton<ObjectPools>.Instance;

	private void Awake()
	{
		pools = new Dictionary<string, Pool>();
		toUninstantiationIntances = new Queue<GameObject>();
	}

	private void Update()
	{
		if (toUninstantiationIntances.Count != 0)
		{
			GameObject gameObject = toUninstantiationIntances.Dequeue();
			IRecyclableObject component = gameObject.GetComponent<IRecyclableObject>();
			component.OnUnistantiation();
			pools[component.ObjectTypeId].InstancesQueue.Enqueue(gameObject);
			pools[component.ObjectTypeId].RefreshInstancesCounter();
		}
	}

	public void CreateNewInstances(string objectTypeId, int quantity, RealInstantiationMethod realInstantiationMethod)
	{
		if (!pools.ContainsKey(objectTypeId))
		{
			pools.Add(objectTypeId, new Pool(objectTypeId, poolsFolder.transform, realInstantiationMethod));
		}
		Pool pool = pools[objectTypeId];
		for (int i = 0; i < quantity; i++)
		{
			GameObject gameObject = pool.NewRealInstance();
			gameObject.transform.SetParent(pool.PoolFolder.transform);
			gameObject.SetActive(value: false);
			pool.InstancesQueue.Enqueue(gameObject);
		}
		pool.RefreshInstancesCounter();
	}

	public GameObject GetInstance(string objectTypeId, Transform parent = null)
	{
		if (!pools.ContainsKey(objectTypeId))
		{
			return null;
		}
		GameObject gameObject = ((pools[objectTypeId].InstancesQueue.Count <= 0) ? pools[objectTypeId].NewRealInstance() : pools[objectTypeId].InstancesQueue.Dequeue());
		pools[objectTypeId].RefreshInstancesCounter();
		gameObject.transform.SetParent(parent);
		gameObject.SetActive(value: true);
		gameObject.GetComponent<IRecyclableObject>()?.OnInstantiation();
		return gameObject;
	}

	public GameObject GetInstanceForUI(string objectTypeId, Transform parent = null, int siblingIndex = -1, string objectName = "")
	{
		GameObject instance = GetInstance(objectTypeId, parent);
		instance.transform.localScale = Vector3.one;
		instance.transform.SetLocalPositionZ(0f);
		if (siblingIndex >= 0)
		{
			instance.transform.SetSiblingIndex(siblingIndex);
		}
		if (!string.IsNullOrEmpty(objectName))
		{
			instance.name = objectName;
		}
		return instance;
	}

	public void ReturnInstance(GameObject oldInstance)
	{
		string text = null;
		IRecyclableObject component = oldInstance.GetComponent<IRecyclableObject>();
		if (component != null && !string.IsNullOrEmpty(component.ObjectTypeId))
		{
			if (pools.ContainsKey(component.ObjectTypeId))
			{
				text = component.ObjectTypeId;
			}
		}
		else if (pools.ContainsKey(oldInstance.name))
		{
			text = oldInstance.name;
		}
		if (!string.IsNullOrEmpty(text))
		{
			oldInstance.transform.SetParent(pools[text].PoolFolder.transform);
			oldInstance.SetActive(value: false);
			if (component != null)
			{
				toUninstantiationIntances.Enqueue(oldInstance);
			}
			else
			{
				pools[text].InstancesQueue.Enqueue(oldInstance);
			}
		}
	}
}
