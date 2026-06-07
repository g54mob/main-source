using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradeGroup", menuName = "Game/UpgradeGroupSO")]
public class UpgradeGroupSO : ScriptableObject
{
	[Header("Identity")]
	public UpgradeType upgradeType;

	[Tooltip("Localization key for upgrade name")]
	public string upgradeNameKey;

	public Sprite icon;

	public UpgradeCategory category;

	[Header("Display")]
	[Tooltip("Localization key for level prefix (e.g., 'Level', 'Genişleme')")]
	public string levelPrefixKey = "Level";

	[Header("Levels")]
	public List<UpgradeLevelData> levels = new List<UpgradeLevelData>();

	[Header("Equipment Link")]
	[Tooltip("Only for Equipments category - which ItemType level to increase")]
	public ItemType linkedItemType;

	public int MaxLevel => levels.Count;

	public string UpgradeName
	{
		get
		{
			if (string.IsNullOrEmpty(upgradeNameKey))
			{
				return "";
			}
			string translation = LocalizationManager.GetTranslation(upgradeNameKey);
			if (!string.IsNullOrEmpty(translation))
			{
				return translation;
			}
			return "NL/" + upgradeNameKey;
		}
	}

	public string LevelPrefix
	{
		get
		{
			if (string.IsNullOrEmpty(levelPrefixKey))
			{
				return "Level";
			}
			string translation = LocalizationManager.GetTranslation(levelPrefixKey);
			if (!string.IsNullOrEmpty(translation))
			{
				return translation;
			}
			return "NL/" + levelPrefixKey;
		}
	}

	public UpgradeLevelData GetLevelData(int level)
	{
		int num = level - 1;
		if (num < 0 || num >= levels.Count)
		{
			return null;
		}
		return levels[num];
	}
}
