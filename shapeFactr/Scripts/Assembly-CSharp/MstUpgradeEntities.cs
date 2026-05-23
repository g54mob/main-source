using System;
using System.Collections.Generic;

[Serializable]
public class MstUpgradeEntities
{
	public eUpgradeId id;

	public string description;

	public int rewardRate;

	public eUpgradePack upgradePack;

	public eUpgradeCategory upgradeCategory;

	public int tier;

	public eUpgradeKind upgradeKind1;

	public List<string> param1;

	public eUpgradeKind upgradeKind2;

	public List<string> param2;

	public eUpgradeId exclusiveTree;

	public List<eUpgradeId> needTree;

	public int limitCount;

	public eArchiveCategory archiveCategory;

	public string archiveId;

	public bool isTrial;

	public bool isEarly;
}
