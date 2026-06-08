using UnityEngine;

public class TestStorage : MonoBehaviour
{
	public TextAsset firstSave;

	public TextAsset earlyGameSave;

	private readonly string CREATED_TIME_KEY = "createdTime";

	private readonly string MODIFIED_TIME_KEY = "modifiedTime";

	public static TestStorage singleton { get; private set; }

	public string GetFirstSaveSJson()
	{
		return firstSave.text;
	}

	public string GetEarlyGameSaveSJson()
	{
		return earlyGameSave.text;
	}

	public void SetStorageToSJson(AStorage storage, string sjson)
	{
		ClearStorage(storage);
		string[] array = SlimJson.ParseArray(sjson, "STRING_KEYS");
		if (array != null)
		{
			foreach (string key in array)
			{
				string value = SlimJson.Parse(sjson, key);
				storage.SetString(key, value);
			}
		}
		array = SlimJson.ParseArray(sjson, "INT_KEYS");
		if (array != null)
		{
			foreach (string key2 in array)
			{
				int value2 = SlimJson.ParseInt(sjson, key2);
				storage.SetInt(key2, value2);
			}
		}
		array = SlimJson.ParseArray(sjson, "BOOL_KEYS");
		if (array != null)
		{
			foreach (string key3 in array)
			{
				bool value3 = SlimJson.ParseBool(sjson, key3);
				storage.SetBool(key3, value3);
			}
		}
	}

	public void ClearPlayerPrefsStorage()
	{
		PlayerPrefsStorage storage = new PlayerPrefsStorage();
		ClearStorage(storage);
	}

	public void ClearStorage(AStorage storage)
	{
		int num = storage.GetInt("save_file_last_id");
		for (int i = 0; i <= num; i++)
		{
			string key = "save_file_" + i;
			if (storage.HasKey(key))
			{
				storage.DeleteKey(key);
			}
		}
		storage.DeleteKey("save_file_last_id");
		if (storage.HasKey(CREATED_TIME_KEY))
		{
			storage.DeleteKey(CREATED_TIME_KEY);
		}
		if (storage.HasKey(MODIFIED_TIME_KEY))
		{
			storage.DeleteKey(MODIFIED_TIME_KEY);
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
