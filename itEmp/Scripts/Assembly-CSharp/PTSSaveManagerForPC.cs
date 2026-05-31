using System;
using System.Collections.Generic;
using UnityEngine;

public class PTSSaveManagerForPC : MonoBehaviour
{
	[Serializable]
	public class ComponentData
	{
		public string uniqueID;

		public string objectPath;

		public string componentType;
	}

	[Serializable]
	public class SaveData
	{
		public List<ComponentData> components;
	}

	private string SavePath => null;

	[ContextMenu("Save PTS Data")]
	public void SaveDataToJson()
	{
	}

	[ContextMenu("Load PTS Data")]
	public void LoadDataFromJson()
	{
	}

	private string GetFullPath(Transform t)
	{
		return null;
	}
}
