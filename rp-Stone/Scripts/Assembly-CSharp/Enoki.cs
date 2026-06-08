public class Enoki : Enemy
{
	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		AchievementController.singleton.ReportAngryShroomDefeated(this);
	}
}
