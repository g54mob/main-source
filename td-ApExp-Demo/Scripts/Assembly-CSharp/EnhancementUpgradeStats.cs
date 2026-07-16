using UnityEngine;

[CreateAssetMenu(fileName = "New Stats Upgrade", menuName = "Upgrade/Create New Stats Upgrade", order = 0)]
public class EnhancementUpgradeStats : EnhancementUpgrade
{
	[NonReorderable]
	public StatUpgrade[] statUpgrades;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		ModuleSlot cannonModuleSlot = Train.Instance.GetCannonModuleSlot();
		if ((object)cannonModuleSlot != null && cannonModuleSlot.Module is ModuleCannon moduleCannon)
		{
			moduleCannon.cannon.OnUpgraded();
		}
	}

	public override void OnRemove()
	{
		base.OnRemove();
		ModuleSlot cannonModuleSlot = Train.Instance.GetCannonModuleSlot();
		if ((object)cannonModuleSlot != null && cannonModuleSlot.Module is ModuleCannon moduleCannon)
		{
			moduleCannon.cannon.OnUpgraded();
		}
	}
}
