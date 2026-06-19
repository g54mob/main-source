using UnityEngine;

public class UpgradePlayerActions : PlayerActionMode
{
	[SerializeField]
	private UpgradeTreeUI _uiUpgradeTree;

	private UpgradeStation _upgradeStation;

	public override bool PlayerCanMove => false;

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}

	public void Cancel()
	{
	}

	public void ToggleForStation(UpgradeStation upgradeStation)
	{
	}
}
