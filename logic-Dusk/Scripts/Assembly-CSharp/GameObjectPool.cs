using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
	public static GameObjectPool Instance;

	private List<GameObject>[] pooledObjects;

	public GameObject[] prefabArray;

	public int[] initialPoolSize;

	protected GameObject container;

	private void Awake()
	{
		Instance = this;
		if (prefabArray == null)
		{
			Debug.LogError("object Pool Not Configured Correctly");
		}
		container = base.gameObject;
		int num = prefabArray.Length;
		pooledObjects = new List<GameObject>[num];
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = prefabArray[i];
			if (!(gameObject != null))
			{
				continue;
			}
			int num2 = 0;
			num2 = ((initialPoolSize != null && initialPoolSize.Length >= i) ? initialPoolSize[i] : 50);
			if (pooledObjects[i] == null)
			{
				pooledObjects[i] = new List<GameObject>(num2);
			}
			else
			{
				int count = pooledObjects[i].Count;
				if (count > num2)
				{
					num2 = count;
				}
			}
			for (int j = 0; j < num2; j++)
			{
				GameObject gameObject2 = Object.Instantiate(gameObject);
				gameObject2.name = gameObject.name;
				Object.DontDestroyOnLoad(gameObject2);
				PushObject(gameObject2);
			}
		}
	}

	public bool PushObject(GameObject obj)
	{
		if (obj == null)
		{
			return false;
		}
		int num = prefabArray.Length;
		string text = obj.name;
		char c = text[0];
		for (int i = 0; i < num; i++)
		{
			if (!(prefabArray[i] != null))
			{
				continue;
			}
			string text2 = prefabArray[i].name;
			if (text2.Length == obj.name.Length && text2[0] == c && text2 == text)
			{
				if (obj.activeSelf)
				{
					obj.SetActive(false);
				}
				if (container != null)
				{
					obj.transform.parent = container.transform;
					pooledObjects[i].Add(obj);
				}
				return true;
			}
		}
		return false;
	}

	public GameObject PopObject(string name)
	{
		if (name.Length == 0)
		{
			return null;
		}
		int num = prefabArray.Length;
		char c = name[0];
		for (int i = 0; i < num; i++)
		{
			if (!(prefabArray[i] != null))
			{
				continue;
			}
			string text = prefabArray[i].name;
			if (text.Length == name.Length && text[0] == c && text == name)
			{
				if (pooledObjects[i].Count > 0)
				{
					int index = pooledObjects[i].Count - 1;
					GameObject gameObject = pooledObjects[i][index];
					gameObject.transform.parent = null;
					gameObject.SetActive(true);
					pooledObjects[i].RemoveAt(index);
					return gameObject;
				}
				GameObject gameObject2 = Object.Instantiate(prefabArray[i]);
				gameObject2.name = name;
				gameObject2.transform.parent = null;
				gameObject2.SetActive(true);
				return gameObject2;
			}
		}
		return null;
	}
}
