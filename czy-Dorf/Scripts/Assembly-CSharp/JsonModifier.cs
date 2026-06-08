using System;
using System.IO;
using UnityEngine;

public abstract class JsonModifier<T> : ScriptableObject
{
	public string folderPath;

	public string currentDataObjectPath;

	public string countPlayerPrefsKey;

	public event Action<T> OnSaveCompleted;

	protected abstract string DataObjectName(T dataObject);

	public void SaveJson(T dataObject)
	{
		Debug.Log(this?.ToString() + " Create Json");
		JsonSaver.SaveAsJson(dataObject, DataObjectPath(dataObject));
		this.OnSaveCompleted?.Invoke(dataObject);
	}

	public virtual string DataObjectPath(T dataObject)
	{
		return Path.Combine(folderPath, DataObjectName(dataObject) + ".json");
	}
}
