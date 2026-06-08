public class PallasStage2 : Enemy
{
	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		AchievementController.singleton.ReportPallasDefeated(this);
	}
}
