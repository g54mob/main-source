using System;

[Serializable]
public struct UpgradeNodeState
{
	public UpgradeType upgradeType;

	public int currentLevel;

	public UpgradeNodeState(UpgradeType type, int level)
	{
		upgradeType = type;
		currentLevel = level;
	}
}
