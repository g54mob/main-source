using System.Collections.Generic;
using ES3Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabManager : MonoBehaviour
{
	public List<GameObject> prefabInstances = new List<GameObject>();

	public List<GameObject> handObjs = new List<GameObject>();

	private int index;

	private void Awake()
	{
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		ES3Prefab.OnPrefabInstantiated += ES3Prefab_OnPrefabInstantiated;
		ES3AutoSaveMgr.OnLoaing += ES3AutoSaveMgr_OnLoaing;
		index = SceneManager.GetActiveScene().buildIndex;
		Debug.Log(index);
		LoadPrefabInstances();
	}

	private void ES3AutoSaveMgr_OnLoaing()
	{
	}

	private void OnDestroy()
	{
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
		ES3Prefab.OnPrefabInstantiated -= ES3Prefab_OnPrefabInstantiated;
		ES3AutoSaveMgr.OnLoaing -= ES3AutoSaveMgr_OnLoaing;
	}

	private void ES3Prefab_OnPrefabInstantiated(GameObject obj)
	{
		Register(obj);
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SavePrefabInstances();
	}

	public void SavePrefabInstances()
	{
		List<GameObject> list = new List<GameObject>();
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		if (FirstPersonController.S != null && FirstPersonController.S.itemOnHand != null)
		{
			hashSet.Add(FirstPersonController.S.itemOnHand);
			Transform[] componentsInChildren = FirstPersonController.S.itemOnHand.GetComponentsInChildren<Transform>(includeInactive: true);
			foreach (Transform transform in componentsInChildren)
			{
				hashSet.Add(transform.gameObject);
			}
		}
		foreach (GameObject prefabInstance in prefabInstances)
		{
			if (prefabInstance != null && !hashSet.Contains(prefabInstance))
			{
				list.Add(prefabInstance);
			}
		}
		string key = ((index == 0) ? "PrefabInstances0" : "PrefabInstances1");
		ES3AutoSaveMgr current2 = ES3AutoSaveMgr.Current;
		ES3SerializableSettings settings = ((current2 != null) ? current2.settings : null);
		if (ES3.KeyExists(key, settings))
		{
			ES3.DeleteKey(key, settings);
		}
		if (list.Count > 0)
		{
			ES3.Save(key, list, settings);
		}
	}

	public void SaveBeforeClosed()
	{
		List<GameObject> list = new List<GameObject>();
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		if (FirstPersonController.S != null && FirstPersonController.S.itemOnHand != null)
		{
			Transform[] componentsInChildren = FirstPersonController.S.itemOnHand.GetComponentsInChildren<Transform>(includeInactive: true);
			foreach (Transform transform in componentsInChildren)
			{
				hashSet.Add(transform.gameObject);
			}
		}
		foreach (GameObject handObj in handObjs)
		{
			if (handObj != null && !hashSet.Contains(handObj))
			{
				list.Add(handObj);
			}
		}
		ES3AutoSaveMgr current2 = ES3AutoSaveMgr.Current;
		ES3SerializableSettings settings = ((current2 != null) ? current2.settings : null);
		string text = ((index == 0) ? "HandObj0" : "HandObj1");
		if (ES3.KeyExists(text, settings))
		{
			ES3.DeleteKey(text, settings);
		}
		if (list.Count <= 0)
		{
			return;
		}
		List<long> list2 = new List<long>();
		foreach (GameObject item2 in list)
		{
			long item = ES3ReferenceMgrBase.Current.Get(item2);
			list2.Add(item);
			ES3.Save(text + item, item2, settings);
		}
		ES3.Save(text, list2, settings);
	}

	public void LoadPrefabInstances()
	{
		prefabInstances.Clear();
		handObjs.Clear();
		string key = ((index == 0) ? "PrefabInstances0" : "PrefabInstances1");
		ES3AutoSaveMgr current = ES3AutoSaveMgr.Current;
		ES3SerializableSettings settings = ((current != null) ? current.settings : null);
		if (ES3.KeyExists(key, settings))
		{
			prefabInstances = ES3.Load(key, new List<GameObject>(), settings);
		}
		Debug.Log($"=== Loading Scene {index} ===");
		Debug.Log($"Loaded {prefabInstances.Count} prefabs");
		foreach (GameObject prefabInstance in prefabInstances)
		{
			if (prefabInstance != null)
			{
				Debug.Log("  - " + prefabInstance.name + " (Scene: " + prefabInstance.scene.name + ")");
			}
			else
			{
				Debug.Log("  - NULL OBJECT!");
			}
		}
		if (!(FirstPersonController.S != null) || !(FirstPersonController.S.itemOnHand != null))
		{
			return;
		}
		ES3Prefab[] componentsInChildren = FirstPersonController.S.itemOnHand.GetComponentsInChildren<ES3Prefab>(includeInactive: true);
		foreach (ES3Prefab eS3Prefab in componentsInChildren)
		{
			if (!prefabInstances.Contains(eS3Prefab.gameObject))
			{
				prefabInstances.Add(eS3Prefab.gameObject);
				handObjs.Add(eS3Prefab.gameObject);
			}
		}
	}

	public void Register(GameObject go)
	{
		if (!prefabInstances.Contains(go))
		{
			prefabInstances.Add(go);
		}
	}
}
