using System;
using System.Collections.Generic;

[Serializable]
public class SaveProfile : ISavable
{
	[Savable("id", true, false)]
	private string id;

	[Savable("displayName", true, false)]
	private string displayName;

	[Savable("metadata", true, false)]
	private Dictionary<string, object> metadata;

	public string Id => id;

	public string DisplayName
	{
		get
		{
			return displayName;
		}
		set
		{
			displayName = value;
		}
	}

	public Dictionary<string, object> Metadata => metadata;

	public SaveProfile(string id, string displayName)
	{
		this.id = id;
		DisplayName = displayName;
		metadata = new Dictionary<string, object>();
	}

	public void GenerateEmptyMetadata()
	{
		AddMetadata("lastSaveData", DateTime.Now);
		AddMetadata("completedLevels", 0);
		AddMetadata("defeatedBosses", 0);
		AddMetadata("unlockedUpgrades", 0);
	}

	public bool GenerateMetadata()
	{
		AddMetadata("lastSaveData", DateTime.Now);
		PlayerUpgradesManager playerUpgradesManager = LTFunctionLibrary.GetPlayerUpgradesManager();
		LevelsProgressionManager levelsProgressionManager = LTFunctionLibrary.GetLevelsProgressionManager();
		if (!playerUpgradesManager || !levelsProgressionManager)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < levelsProgressionManager.LevelProgressionInfos.Length && levelsProgressionManager.IsLevelComplete(levelsProgressionManager.LevelProgressionInfos[i].LevelData.Id); i++)
		{
			num++;
			if (levelsProgressionManager.IsBossDefeated(levelsProgressionManager.LevelProgressionInfos[i].LevelData.Id))
			{
				num2++;
			}
		}
		AddMetadata("completedLevels", num);
		AddMetadata("defeatedBosses", num2);
		int num3 = 0;
		foreach (PlayerUpgrade unlockedUpgrade in playerUpgradesManager.UnlockedUpgrades)
		{
			if (unlockedUpgrade.Cost > 0 && !unlockedUpgrade.UnlockedByDefault && !unlockedUpgrade.Id.Contains("_demo"))
			{
				num3++;
			}
		}
		if (playerUpgradesManager.UnlockedUpgrades.Count > 0 || !metadata.ContainsKey("unlockedUpgrades"))
		{
			AddMetadata("unlockedUpgrades", num3);
		}
		return true;
	}

	private void AddMetadata(string id, object data)
	{
		if (metadata.ContainsKey(id))
		{
			metadata[id] = data;
		}
		else
		{
			metadata.Add(id, data);
		}
	}

	private T GetMetadata<T>(string id)
	{
		if (metadata.ContainsKey(id))
		{
			return (T)metadata[id];
		}
		return default(T);
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
