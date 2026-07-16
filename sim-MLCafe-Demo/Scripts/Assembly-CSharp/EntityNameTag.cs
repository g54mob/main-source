using System;
using MLCN_Localization;
using UnityEngine;

[Serializable]
public class EntityNameTag
{
	[SerializeField]
	private bool usePreLocalizedName;

	private string name;

	private string localizationKey;

	private Color nameColor;

	private int id;

	public EntityNameTag(string localizationKey, Color nameColor, bool usePreLocalization = false, string name = "LocalizedName")
	{
		this.localizationKey = localizationKey;
		this.name = name;
		this.nameColor = nameColor;
		usePreLocalizedName = usePreLocalization;
		id = default(Guid).GetHashCode();
	}

	public int GetID()
	{
		return id;
	}

	public void SetID(int newId)
	{
		id = newId;
	}

	public string GetName()
	{
		if (!usePreLocalizedName)
		{
			return LocalizationManager.GetLocalizedString(localizationKey, LocalizationDataTable.Tables.Dialogs);
		}
		return name;
	}

	public Color GetNameColor()
	{
		return nameColor;
	}

	public bool HasName()
	{
		if (!usePreLocalizedName)
		{
			return localizationKey != "";
		}
		return name != "";
	}
}
