public class OuroborosPaintScreen : UpgradeRelicScreen
{
	protected override Item GetRelic()
	{
		return OuroborosWeapon.singleton;
	}

	protected override void UpgradeRelic()
	{
		base.UpgradeRelic();
		QuestController.singleton.MakeUnavailable("upgrade_ouroboros");
	}
}
