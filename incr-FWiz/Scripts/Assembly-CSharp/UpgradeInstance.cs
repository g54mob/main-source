using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeInstance : ICheckpoint
{
	public string ID;

	private UpgradeDef _upgradeDef;

	public int Level;

	public bool Seen;

	public bool Unlocked => false;

	public int LevelIndex => 0;

	public UpgradeLevel NextLevel => null;

	public string CheckpointID => null;

	public bool NextLevelDemoLocked => false;

	public bool Valid => false;

	public UpgradeInstance(UpgradeDef upgradeDef, int level = 1)
	{
	}

	public UpgradeInstance(string id, int level = 1)
	{
	}

	public UpgradeDef GetUpgradeDef()
	{
		return null;
	}

	public List<UpgradeDef> GetChildren()
	{
		return null;
	}

	public bool IsMaxLevel()
	{
		return false;
	}
}
