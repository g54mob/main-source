using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPooler : MonoBehaviour
{
	public static VFXPooler Instance;

	private Dictionary<string, Queue<GameObject>> poolDictionary;

	private Dictionary<string, VFXData> vfxDataDictionary;

	private void Awake()
	{
		Instance = this;
		poolDictionary = new Dictionary<string, Queue<GameObject>>();
		vfxDataDictionary = new Dictionary<string, VFXData>();
		VFXData[] array = Resources.LoadAll<VFXData>("");
		foreach (VFXData vFXData in array)
		{
			Queue<GameObject> queue = new Queue<GameObject>();
			for (int j = 0; j < vFXData.initialPoolSize; j++)
			{
				if (!(vFXData.prefab == null))
				{
					GameObject gameObject = Object.Instantiate(vFXData.prefab, base.transform);
					gameObject.SetActive(value: false);
					queue.Enqueue(gameObject);
				}
			}
			if (!poolDictionary.ContainsKey(vFXData.id))
			{
				poolDictionary.Add(vFXData.id, queue);
				vfxDataDictionary.Add(vFXData.id, vFXData);
			}
			else
			{
				Debug.LogWarning("VFX Pooler: Duplicate VFX ID found: '" + vFXData.id + "'. The first one was loaded.");
			}
		}
	}

	public GameObject PlayEffect(string id, Vector3 position)
	{
		if (!poolDictionary.ContainsKey(id))
		{
			Debug.LogWarning("Pool with id '" + id + "' doesn't exist.");
			return null;
		}
		if (poolDictionary[id].Count == 0)
		{
			Debug.LogWarning("Pool with id '" + id + "' is empty. Consider increasing its initial size.");
			return null;
		}
		GameObject gameObject = poolDictionary[id].Dequeue();
		gameObject.SetActive(value: true);
		gameObject.transform.position = position;
		VFXData vFXData = vfxDataDictionary[id];
		if (vFXData.disposeAfterSeconds > 0f)
		{
			StartCoroutine(AutoReturnToPool(id, gameObject, vFXData.disposeAfterSeconds));
		}
		return gameObject;
	}

	public void DisposeEffect(GameObject effectToDispose)
	{
		if (!(effectToDispose == null))
		{
			PooledVFXObject component = effectToDispose.GetComponent<PooledVFXObject>();
			if (component == null)
			{
				Debug.LogWarning("Tried to dispose an object that is not a pooled VFX! It will be destroyed instead.");
				Object.Destroy(effectToDispose);
			}
			else
			{
				ReturnToPool(component.vfxId, effectToDispose);
			}
		}
	}

	public void ReturnToPool(string id, GameObject objectToReturn)
	{
		if (!poolDictionary.ContainsKey(id))
		{
			Debug.LogWarning("Pool with id '" + id + "' doesn't exist.");
			Object.Destroy(objectToReturn);
		}
		else
		{
			objectToReturn.SetActive(value: false);
			poolDictionary[id].Enqueue(objectToReturn);
		}
	}

	private IEnumerator AutoReturnToPool(string id, GameObject objectToReturn, float delay)
	{
		yield return new WaitForSeconds(delay);
		if (objectToReturn.activeInHierarchy)
		{
			ReturnToPool(id, objectToReturn);
		}
	}
}
