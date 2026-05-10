using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveComponent : MonoBehaviour
{
	[SerializeField]
	private string id = "";

	[SerializeField]
	private bool customSaveGroup;

	[SerializeField]
	private string saveGroup = "main";

	[SerializeField]
	private bool saveTransform;

	public string Id
	{
		get
		{
			if (!(id != ""))
			{
				return Guid.NewGuid().ToString();
			}
			return id;
		}
		set
		{
			id = value;
		}
	}

	public string SaveGroup
	{
		get
		{
			if (!CustomSaveGroup)
			{
				return "main";
			}
			return saveGroup;
		}
		set
		{
			saveGroup = value;
		}
	}

	public bool SaveTransform
	{
		get
		{
			return saveTransform;
		}
		set
		{
			saveTransform = value;
		}
	}

	public bool CustomSaveGroup
	{
		get
		{
			return customSaveGroup;
		}
		set
		{
			customSaveGroup = value;
		}
	}

	public void GenerateId()
	{
		Id = Guid.NewGuid().ToString();
	}

	private void Start()
	{
		SaveSystem.instance.onSave += OnSave;
		SaveSystem.instance.onLoad += OnLoad;
		if (SaveSystem.instance.HasLoadedData(saveGroup))
		{
			OnLoad(SaveGroup);
		}
	}

	private void OnDestroy()
	{
		SaveSystem.instance.onSave -= OnSave;
		SaveSystem.instance.onLoad -= OnLoad;
	}

	private void OnSave(string saveGroup)
	{
		if (saveGroup.ToLower() == SaveGroup.ToLower())
		{
			SaveSystem.instance.SetDataById(Id, SaveSystem.GetDataToSaveFromObject(base.gameObject, saveGroup), saveGroup);
		}
	}

	public void OnLoad(string saveGroup)
	{
		if (saveGroup.ToLower() == SaveGroup.ToLower())
		{
			SaveSystem.LoadObjectData(base.gameObject, SaveSystem.instance.SavedData.ContainsKey(saveGroup.ToLower()) ? (SaveSystem.instance.GetDataById(Id, SaveSystem.instance.SavedData[saveGroup.ToLower()] as Dictionary<string, object>) as Dictionary<string, object>) : null);
		}
	}
}
