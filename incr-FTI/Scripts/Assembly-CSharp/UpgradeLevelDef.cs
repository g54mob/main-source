using System.Collections.Generic;

public class UpgradeLevelDef
{
	public readonly UpgradeType parentUpgradeType;

	public readonly List<RequirementId> unlockRequirements = new List<RequirementId>();

	public readonly ItemList levelCosts = new ItemList();

	public UpgradeLevelDef(UpgradeType parentUpgrade)
	{
		parentUpgradeType = parentUpgrade;
	}

	public void AddCost(ItemType t, double amount)
	{
		levelCosts.AddItem(t, amount);
	}

	public void AddRequirement(RequirementId r)
	{
		unlockRequirements.Add(r);
	}
}
