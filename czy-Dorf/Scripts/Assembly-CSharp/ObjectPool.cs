using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField]
	private GameObject prefab;

	private Queue<GameObject> objectStack;

	private int count;

	private int sizeLimit = 25;

	private void Awake()
	{
		objectStack = new Queue<GameObject>();
	}

	public GameObject GetObject()
	{
		if (objectStack.Count == 0)
		{
			CreateAndAddObject();
		}
		GameObject obj = objectStack.Dequeue();
		obj.SetActive(value: true);
		return obj;
	}

	public void StoreObject(GameObject objectToStore)
	{
		if (objectStack.Count >= sizeLimit)
		{
			objectToStore.SetActive(value: false);
			Object.Destroy(objectToStore);
		}
		else
		{
			objectToStore.SetActive(value: false);
			objectToStore.transform.parent = base.transform;
			objectStack.Enqueue(objectToStore);
		}
	}

	public void Initialize(Component objectToStore, int initialCount)
	{
		prefab = objectToStore.gameObject;
		for (int i = 0; i < initialCount; i++)
		{
			CreateAndAddObject();
		}
		base.gameObject.name = "ObjectPool | " + objectToStore.name;
	}

	private void CreateAndAddObject()
	{
		GameObject gameObject = Object.Instantiate(prefab, base.transform);
		gameObject.name = $"{prefab.name} | {count}";
		gameObject.SetActive(value: false);
		StoreObject(gameObject);
		count++;
	}
}
