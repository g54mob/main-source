public class StatsHolderOnlyModule : Module
{
	private new void Awake()
	{
		if ((bool)statsSO)
		{
			statsSO.upgradeEvent += base.OnUpgradeApplied;
		}
	}

	private new void Update()
	{
		statsSO.UpdateSEs();
	}

	public new float GetUpgradedStatValueByStatType(StatTypes statType)
	{
		return base.GetUpgradedStatValueByStatType(statType);
	}

	public new float GetInitialStat(StatTypes statType)
	{
		return base.GetInitialStat(statType);
	}

	protected override void StartAndPostUpgrade()
	{
	}
}
