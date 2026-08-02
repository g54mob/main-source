using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingSystem : Singleton<PoolingSystem>
{
	public List<SourceObjects> SourceObjects = new List<SourceObjects>();

	private List<AudioSource> pooledAudioSources = new List<AudioSource>();

	public int DefaultCount = 10;

	[HideInInspector]
	public Vector3 initScale;

	private const int INSTANTIATES_PER_FRAME = 5;

	private void Awake()
	{
		InitilizeAudioSources();
		StartCoroutine(InitilizeGameObjectsAsync());
	}

	public void InitilizePool()
	{
		InitilizeAudioSources();
		StartCoroutine(InitilizeGameObjectsAsync());
	}

	private IEnumerator InitilizeGameObjectsAsync()
	{
		int instantiateCount = 0;
		for (int i = 0; i < SourceObjects.Count; i++)
		{
			int copyNumber = DefaultCount;
			if (SourceObjects[i].MinNumberOfObject != 0)
			{
				copyNumber = SourceObjects[i].MinNumberOfObject;
			}
			for (int j = 0; j < copyNumber; j++)
			{
				GameObject gameObject = Object.Instantiate(SourceObjects[i].SourcePrefab, base.transform);
				gameObject.SetActive(value: false);
				if (SourceObjects[i].AutoDestroy)
				{
					gameObject.AddComponent<PoolObject>();
				}
				SourceObjects[i].clones.Add(gameObject);
				instantiateCount++;
				if (instantiateCount >= 5)
				{
					instantiateCount = 0;
					yield return null;
				}
			}
		}
	}

	private void InitilizeAudioSources()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "AudioHolder";
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.position = Vector3.zero;
		for (int i = 0; i < 20; i++)
		{
			GameObject obj = new GameObject();
			obj.name = "PooledSource";
			obj.transform.position = Vector3.zero;
			obj.transform.SetParent(gameObject.transform);
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.playOnAwake = false;
			audioSource.loop = false;
			pooledAudioSources.Add(audioSource);
		}
	}

	public void LoadAllPlaceableItems()
	{
		ClearItems();
		CollectableItemData[] array = (from collectableItemData2 in Resources.LoadAll<CollectableItemData>("")
			where (collectableItemData2.itemType == ItemType.Placeable || collectableItemData2.itemType == ItemType.Wagon || collectableItemData2.itemType == ItemType.BuildItem) && collectableItemData2.itemPrefab != null
			select collectableItemData2).ToArray();
		int num = 0;
		CollectableItemData[] array2 = array;
		foreach (CollectableItemData collectableItemData in array2)
		{
			string itemID = collectableItemData.itemName;
			if (!SourceObjects.Any((SourceObjects so) => so.ID == itemID))
			{
				SourceObjects item = new SourceObjects
				{
					ID = itemID,
					SourcePrefab = collectableItemData.itemPrefab,
					MinNumberOfObject = 0,
					AllowGrow = true,
					AutoDestroy = true,
					clones = new List<GameObject>()
				};
				SourceObjects.Add(item);
				num++;
				Debug.Log($"Item eklendi: {itemID} (Type: {collectableItemData.itemType})");
			}
			else
			{
				Debug.Log("Item zaten mevcut: " + itemID);
			}
		}
		Debug.Log($"Toplam {num} yeni item PoolingSystem'e eklendi!");
		Debug.Log($"Bulunan toplam item sayısı: {array.Length}");
		InitilizeNewObjects();
	}

	private void ClearItems()
	{
		HashSet<string> hashSet = (from item in Resources.LoadAll<CollectableItemData>("")
			where item.itemType == ItemType.Placeable || item.itemType == ItemType.Wagon || item.itemType == ItemType.BuildItem
			select item.itemName).ToHashSet();
		int num = 0;
		for (int num2 = SourceObjects.Count - 1; num2 >= 0; num2--)
		{
			if (hashSet.Contains(SourceObjects[num2].ID))
			{
				foreach (GameObject clone in SourceObjects[num2].clones)
				{
					if (clone != null)
					{
						Object.DestroyImmediate(clone);
					}
				}
				SourceObjects.RemoveAt(num2);
				num++;
			}
		}
		Debug.Log($"{num} item PoolingSystem'den temizlendi.");
	}

	private void InitilizeNewObjects()
	{
		foreach (SourceObjects sourceObject in SourceObjects)
		{
			if (sourceObject.clones.Count != 0 || !(sourceObject.SourcePrefab != null))
			{
				continue;
			}
			int num = DefaultCount;
			if (sourceObject.MinNumberOfObject != 0)
			{
				num = sourceObject.MinNumberOfObject;
			}
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = Object.Instantiate(sourceObject.SourcePrefab, base.transform);
				gameObject.SetActive(value: false);
				if (sourceObject.AutoDestroy)
				{
					gameObject.AddComponent<PoolObject>();
				}
				sourceObject.clones.Add(gameObject);
			}
			Debug.Log($"Pool initialized for: {sourceObject.ID} with {num} objects");
		}
	}

	public void ShowCurrentItems()
	{
		CollectableItemData[] source = Resources.LoadAll<CollectableItemData>("");
		HashSet<string> targetItemNames = (from item in source
			where item.itemType == ItemType.Placeable || item.itemType == ItemType.Wagon || item.itemType == ItemType.BuildItem
			select item.itemName).ToHashSet();
		List<SourceObjects> list = SourceObjects.Where((SourceObjects so) => targetItemNames.Contains(so.ID)).ToList();
		Debug.Log($"PoolingSystem'de toplam {list.Count} item var:");
		foreach (SourceObjects item in list)
		{
			Debug.Log(string.Format("- {0} | Prefab: {1} | Clone Count: {2}", item.ID, (item.SourcePrefab != null) ? item.SourcePrefab.name : "NULL", item.clones.Count));
		}
	}

	private void ClearPlaceableItems()
	{
		HashSet<string> hashSet = (from item in Resources.LoadAll<CollectableItemData>("")
			where item.itemType == ItemType.Placeable
			select item.itemName).ToHashSet();
		int num = 0;
		for (int num2 = SourceObjects.Count - 1; num2 >= 0; num2--)
		{
			if (hashSet.Contains(SourceObjects[num2].ID))
			{
				foreach (GameObject clone in SourceObjects[num2].clones)
				{
					if (clone != null)
					{
						Object.DestroyImmediate(clone);
					}
				}
				SourceObjects.RemoveAt(num2);
				num++;
			}
		}
		Debug.Log($"{num} placeable item PoolingSystem'den temizlendi.");
	}

	private void ClearWagonItems()
	{
		HashSet<string> hashSet = (from item in Resources.LoadAll<CollectableItemData>("")
			where item.itemType == ItemType.Wagon
			select item.itemName).ToHashSet();
		int num = 0;
		for (int num2 = SourceObjects.Count - 1; num2 >= 0; num2--)
		{
			if (hashSet.Contains(SourceObjects[num2].ID))
			{
				foreach (GameObject clone in SourceObjects[num2].clones)
				{
					if (clone != null)
					{
						Object.DestroyImmediate(clone);
					}
				}
				SourceObjects.RemoveAt(num2);
				num++;
			}
		}
		Debug.Log($"{num} wagon item PoolingSystem'den temizlendi.");
	}

	private void InitilizeNewPlaceableObjects()
	{
		foreach (SourceObjects sourceObject in SourceObjects)
		{
			if (sourceObject.clones.Count != 0 || !(sourceObject.SourcePrefab != null))
			{
				continue;
			}
			int num = DefaultCount;
			if (sourceObject.MinNumberOfObject != 0)
			{
				num = sourceObject.MinNumberOfObject;
			}
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = Object.Instantiate(sourceObject.SourcePrefab, base.transform);
				gameObject.SetActive(value: false);
				if (sourceObject.AutoDestroy)
				{
					gameObject.AddComponent<PoolObject>();
				}
				sourceObject.clones.Add(gameObject);
			}
			Debug.Log($"Pool initialized for: {sourceObject.ID} with {num} objects");
		}
	}

	private void InitilizeNewWagonObjects()
	{
		HashSet<string> hashSet = (from item in Resources.LoadAll<CollectableItemData>("")
			where item.itemType == ItemType.Wagon
			select item.itemName).ToHashSet();
		foreach (SourceObjects sourceObject in SourceObjects)
		{
			if (!hashSet.Contains(sourceObject.ID) || sourceObject.clones.Count != 0 || !(sourceObject.SourcePrefab != null))
			{
				continue;
			}
			int num = DefaultCount;
			if (sourceObject.MinNumberOfObject != 0)
			{
				num = sourceObject.MinNumberOfObject;
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				GameObject gameObject = Object.Instantiate(sourceObject.SourcePrefab, base.transform);
				gameObject.SetActive(value: false);
				if (sourceObject.AutoDestroy)
				{
					gameObject.AddComponent<PoolObject>();
				}
				sourceObject.clones.Add(gameObject);
			}
			Debug.Log($"Wagon pool initialized for: {sourceObject.ID} with {num} objects");
		}
	}

	public GameObject InstantiateAPS(string Id)
	{
		for (int i = 0; i < SourceObjects.Count; i++)
		{
			if (!string.Equals(SourceObjects[i].ID, Id))
			{
				continue;
			}
			for (int num = SourceObjects[i].clones.Count - 1; num >= 0; num--)
			{
				if (SourceObjects[i].clones[num] == null)
				{
					SourceObjects[i].clones.RemoveAt(num);
				}
				else if (!SourceObjects[i].clones[num].activeInHierarchy)
				{
					SourceObjects[i].clones[num].SetActive(value: true);
					SourceObjects[i].clones[num].GetComponent<IPoolable>()?.Initilize();
					return SourceObjects[i].clones[num];
				}
			}
			if (SourceObjects[i].AllowGrow)
			{
				GameObject gameObject = Object.Instantiate(SourceObjects[i].SourcePrefab, base.transform);
				SourceObjects[i].clones.Add(gameObject);
				gameObject.GetComponent<IPoolable>()?.Initilize();
				if (SourceObjects[i].AutoDestroy)
				{
					gameObject.AddComponent<PoolObject>();
				}
				return gameObject;
			}
		}
		return null;
	}

	public GameObject InstantiateAPS(string iD, Vector3 position)
	{
		GameObject gameObject = InstantiateAPS(iD);
		if ((bool)gameObject)
		{
			gameObject.transform.position = position;
			return gameObject;
		}
		return null;
	}

	public GameObject InstantiateAPS(string iD, Vector3 position, Quaternion rotation)
	{
		GameObject gameObject = InstantiateAPS(iD);
		if ((bool)gameObject)
		{
			gameObject.transform.position = position;
			gameObject.transform.rotation = rotation;
			return gameObject;
		}
		return null;
	}

	public GameObject InstantiateAPS(GameObject sourcePrefab)
	{
		for (int i = 0; i < SourceObjects.Count; i++)
		{
			if ((object)SourceObjects[i].SourcePrefab != sourcePrefab)
			{
				continue;
			}
			for (int num = SourceObjects[i].clones.Count - 1; num >= 0; num--)
			{
				if (SourceObjects[i].clones[num] == null)
				{
					SourceObjects[i].clones.RemoveAt(num);
				}
				else if (!SourceObjects[i].clones[num].activeInHierarchy)
				{
					SourceObjects[i].clones[num].SetActive(value: true);
					return SourceObjects[i].clones[num];
				}
			}
			if (SourceObjects[i].AllowGrow)
			{
				GameObject gameObject = Object.Instantiate(SourceObjects[i].SourcePrefab, base.transform);
				SourceObjects[i].clones.Add(gameObject);
				return gameObject;
			}
		}
		return null;
	}

	public GameObject InstantiateAPS(GameObject sourcePrefab, Vector3 position)
	{
		GameObject gameObject = InstantiateAPS(sourcePrefab);
		if ((bool)gameObject)
		{
			gameObject.transform.position = position;
			return gameObject;
		}
		return null;
	}

	public AudioSource GetAudioSource()
	{
		for (int i = 0; i < pooledAudioSources.Count; i++)
		{
			if (!pooledAudioSources[i].isPlaying)
			{
				return pooledAudioSources[i];
			}
		}
		Transform parent = base.transform.Find("AudioHolder");
		GameObject obj = new GameObject();
		obj.name = "PooledSource";
		obj.transform.position = Vector3.zero;
		obj.transform.SetParent(parent);
		AudioSource audioSource = obj.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.loop = false;
		pooledAudioSources.Add(audioSource);
		return audioSource;
	}

	public void DestroyAPS(GameObject clone)
	{
		if (!(clone == null))
		{
			clone.transform.position = base.transform.position;
			clone.transform.rotation = base.transform.rotation;
			clone.transform.SetParent(base.transform);
			clone.GetComponent<IPoolable>()?.Dispose();
			clone.SetActive(value: false);
		}
	}

	public void DestroyAPS(GameObject clone, float waitTime)
	{
		StartCoroutine(DestroyAPSCo(clone, waitTime));
	}

	private IEnumerator DestroyAPSCo(GameObject clone, float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		DestroyAPS(clone);
	}
}
