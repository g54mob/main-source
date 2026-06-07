using System;
using System.Collections.Generic;

[Serializable]
public class MstUpgradePackEntities
{
	public eUpgradePack id;

	public string name;

	public bool isRewardTier;

	public int rewardCount;

	public int reloadMoney;

	public int reloadAddMoney;

	public List<string> skipBonus;

	public string iconPath;

	public string backGroundPath;

	public string selectedIconPath;

	public string nonSelectedIconPath;
}
