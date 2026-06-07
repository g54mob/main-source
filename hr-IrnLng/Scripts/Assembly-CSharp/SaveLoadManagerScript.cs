using System;
using System.Collections.Generic;
using System.IO;
using FullSerializer;
using UnityEngine;

public class SaveLoadManagerScript : MonoBehaviour
{
	public class SaveDataClass
	{
		public Dictionary<string, object> Data = new Dictionary<string, object>();
	}

	private static readonly fsSerializer _serializer = new fsSerializer();

	private PersistScript persist;

	private FadeInCanvasGroup CheckpointPrompt;

	public string SavePath;

	private void Start()
	{
		persist = GameObject.Find("PERSIST").GetComponent<PersistScript>();
		CheckpointPrompt = GameObject.Find("CheckpointPrompt").GetComponent<FadeInCanvasGroup>();
	}

	private void Update()
	{
		if (persist.DoLoad)
		{
			DoLoad(persist.LoadName);
			persist.DoLoad = false;
		}
		Input.GetKeyDown(KeyCode.F5);
		Input.GetKeyDown(KeyCode.F9);
	}

	public void ActivateCheckpoint()
	{
		CheckpointPrompt.ResetThis();
		DoSave("progress");
	}

	public void TriggerLoad(string name)
	{
		persist.DoLoad = true;
		persist.LoadName = name;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void DoSave(string name)
	{
		File.WriteAllText(Application.dataPath + "/../" + SavePath + "/" + name, Serialize(value: PopulateSaveData(), type: typeof(SaveDataClass)));
	}

	public void DoLoad(string name)
	{
		string path = Application.dataPath + "/../" + SavePath + "/" + name;
		SaveDataClass saveDataClass = new SaveDataClass();
		string serializedState = File.ReadAllText(path);
		saveDataClass = Deserialize(typeof(SaveDataClass), serializedState) as SaveDataClass;
		MonoBehaviour[] array = (MonoBehaviour[])UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour));
		foreach (MonoBehaviour monoBehaviour in array)
		{
			if (monoBehaviour is ISaveObject)
			{
				ISaveObject component = monoBehaviour.GetComponent<ISaveObject>();
				if (saveDataClass.Data.ContainsKey(component.MyID))
				{
					component.LoadData(saveDataClass.Data[component.MyID]);
				}
			}
		}
		MonoBehaviour.print("data loaded from " + name);
	}

	public SaveDataClass PopulateSaveData()
	{
		MonoBehaviour[] obj = (MonoBehaviour[])UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour));
		SaveDataClass saveDataClass = new SaveDataClass();
		MonoBehaviour[] array = obj;
		foreach (MonoBehaviour monoBehaviour in array)
		{
			if (monoBehaviour is ISaveObject)
			{
				ISaveObject component = monoBehaviour.GetComponent<ISaveObject>();
				saveDataClass.Data[component.MyID] = component.SaveData();
			}
		}
		return saveDataClass;
	}

	public static string Serialize(Type type, object value)
	{
		_serializer.TrySerialize(type, value, out var data).AssertSuccessWithoutWarnings();
		return fsJsonPrinter.PrettyJson(data);
	}

	public static object Deserialize(Type type, string serializedState)
	{
		fsData data = fsJsonParser.Parse(serializedState);
		object result = null;
		_serializer.TryDeserialize(data, type, ref result).AssertSuccessWithoutWarnings();
		return result;
	}
}
