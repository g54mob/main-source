using System;
using System.Collections.Generic;

[Serializable]
public class GameplayStats
{
	public int questCompleted;

	public int totalDamageTaken;

	public List<BuildTowerRecord> list_BuildTowerRecord;

	public List<BuildTowerRecord> list_BuildTowerRecord_GroundOnly;

	public List<BuildTowerRecord> list_BuildTowerRecord_OnDynamicObj;

	public List<TowerElementRecord> list_TowerElementRecord;

	public int blocksBuilt;

	public float longestMazeRecord;

	public int totalCoinsEarned;

	public int totalCoinsSpent;

	public List<string> list_SavedScreenshotName;

	public int coinSpent_ancientFlameRemoveSeal;

	public int coinSpend_BuildTower;

	public int normalDamage;

	public int fireDamage;

	public int frostDamage;

	public int electricDamage;

	public int poisonDamage;

	public int arcaneDamage;

	public int GetTotalDamage()
	{
		return 0;
	}

	public int GetTotalBuiltTower()
	{
		return 0;
	}

	public void RecordBuildTower(eItemType towerType, eDamageType damageType, bool isOnGround, bool isOnDynamicObj)
	{
	}

	public void AddTowerElementRecord(eDamageType damageType)
	{
	}

	public void RemoveTowerElementRecord(eDamageType damageType)
	{
	}

	public BuildTowerRecord GetMostBuiltTowerInfo()
	{
		return null;
	}

	public BuildTowerRecord GetMostBuiltTowerInLoadoutInfo()
	{
		return null;
	}

	public int GetTowerBuiltCount(eItemType towerType)
	{
		return 0;
	}

	public void RecordMazeLength(float length)
	{
	}

	public void RecordSavedScreenshot(string name)
	{
	}
}
