public class StarStonePaintScreen : UpgradeRelicScreen
{
	protected override Item GetRelic()
	{
		return StarStoneWeapon.singleton;
	}

	protected override void UpgradeRelic()
	{
		base.UpgradeRelic();
		QuestController.singleton.MakeUnavailable("upgrade_star_stone");
	}
}
