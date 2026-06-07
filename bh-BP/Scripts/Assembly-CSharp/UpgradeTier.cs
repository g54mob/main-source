using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeTier
{
	public Dictionary<PropertyType, UpgradeChange> NewProperties;

	public void AddProperty(PropertyType pt, int val, UpgradeChangeType t = UpgradeChangeType.kAdditive)
	{
	}
}
