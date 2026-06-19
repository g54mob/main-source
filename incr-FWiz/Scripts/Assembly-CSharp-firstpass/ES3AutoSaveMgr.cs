using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[IncludeInSettings(true)]
public class ES3AutoSaveMgr : MonoBehaviour
{
	public enum LoadEvent
	{
		None = 0,
		Awake = 1,
		Start = 2
	}

	public enum SaveEvent
	{
		None = 0,
		OnApplicationQuit = 1,
		OnApplicationPause = 2
	}

	public static ES3AutoSaveMgr _current;

	public static Dictionary<Scene, ES3AutoSaveMgr> managers;

	public string key;

	public bool immediatelyCommitToFile;

	public SaveEvent saveEvent;

	public LoadEvent loadEvent;

	public ES3SerializableSettings settings;

	public HashSet<ES3AutoSave> autoSaves;

	private List<long> destroyedIds;

	public static ES3AutoSaveMgr Current => null;

	public static ES3AutoSaveMgr Instance => null;

	public void SaveItem(string key, object obj)
	{
	}

	public T LoadItem<T>(string key)
	{
		return default(T);
	}

	public void Save()
	{
	}

	public void Load()
	{
	}

	private void Start()
	{
	}

	public void Awake()
	{
	}

	public static void AddAutoSave(ES3AutoSave autoSave)
	{
	}

	public static void DestroyAutoSave(ES3AutoSave autoSave)
	{
	}

	public void GetAutoSaves()
	{
	}

	private static int GetDepth(Transform t)
	{
		return 0;
	}

	private void ManageSlots()
	{
	}
}
