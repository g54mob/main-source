using System;
using System.Collections.Generic;
using UnityEngine;

public class PTSPCSaveID : MonoBehaviour
{
	[Serializable]
	public class ComponentData
	{
		public string uniqueID;

		public string objectPath;

		public string componentType;

		public string deviceID;

		public string MAC;
	}

	[Serializable]
	public class SaveData
	{
		public List<ComponentData> components;
	}

	public string DeviceID;

	private string SavePath => null;

	private void OnValidate()
	{
	}

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
