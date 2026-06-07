public class Storm : Weapon
{
	private bool zap;

	public override void HitTrigger(Monster monster)
	{
		if (zap)
		{
			zap = false;
			Trigger trigger = new Trigger(Trigger.Ability.Collar, owner);
			trigger.source = null;
			trigger.damage = base.damage;
			trigger.ActivateTrigger(this, null, Trigger.Type.Force, owner);
		}
	}

	public override void CastSpell()
	{
		zap = true;
	}
}
