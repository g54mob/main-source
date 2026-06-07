using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Info", menuName = "SimpleSiege/Level Info")]
public class LevelInfo : ScriptableObject
{
	public enum ProgressionContribution
	{
		Crowns = 0,
		Stars = 1
	}

	[Header("Basic Info")]
	public string sceneName;

	public string displayName;

	public bool useSubtitle;

	public bool useModeDescription;

	public bool allBuildingChoicesUnlocked;

	public bool ignoreSaves;

	public bool unlockedInDemo;

	public ProgressionContribution contribution;

	[Header("Unlock Requirement")]
	public LevelInfo unlockRequirement;

	[Header("Enemy Spawner")]
	public EnemySpawner enemySpawner;

	[Header("Quests")]
	public List<Quest> quests = new List<Quest>();

	[Header("Loadout")]
	public List<Equippable> fixedLoadout = new List<Equippable>();

	public int maxPerkCount = 5;

	[Header("Virtual Buildings")]
	public List<VirtualBuilding> virtualBuildings = new List<VirtualBuilding>();

	public string LocalizedDisplayName => LocalizationManager.GetTermTranslation("Map Name/" + displayName);

	public string displaySubtitle
	{
		get
		{
			if (useSubtitle)
			{
				return LocalizationManager.GetTermTranslation("Map/" + sceneName);
			}
			return "";
		}
	}

	public string displayModeDescription
	{
		get
		{
			if (useModeDescription)
			{
				return LocalizationManager.GetTermTranslation("Map Description/" + sceneName);
			}
			return "";
		}
	}

	public bool HasFixedLoadout => fixedLoadout.Count > 0;

	public LevelData LevelData => LevelProgressManager.instance.GetLevelDataForScene(sceneName);

	public bool Beaten => LevelData.beatenBest;

	public int QuestsComplete()
	{
		if (quests == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < quests.Count; i++)
		{
			Quest quest = quests[i];
			if (quest != null && quest.CheckBeaten(LevelData))
			{
				num++;
			}
		}
		return num;
	}

	public int QuestsTotal()
	{
		if (quests == null)
		{
			return 0;
		}
		return quests.Count;
	}
}
