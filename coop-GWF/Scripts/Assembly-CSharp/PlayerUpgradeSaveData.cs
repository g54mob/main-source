using System;
using System.Collections.Generic;

[Serializable]
public class PlayerUpgradeSaveData
{
	public string steamId;

	public List<PlayerUpgradeValue> upgrades = new List<PlayerUpgradeValue>();
}
