public class Quest_UpgradeTower_Red : AQuestBase
{
	private int upgradeCount;

	private int requirement;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerUpgrade(ABaseTower tower, ABaseTower.eUpgradeType upgradeType)
	{
	}

	protected override void OnSetupProc()
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
