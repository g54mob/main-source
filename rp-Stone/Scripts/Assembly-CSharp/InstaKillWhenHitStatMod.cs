public class InstaKillWhenHitStatMod : StatModifier
{
	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c == base.character && dmg.Owner != null && dmg.Owner.Alive && InstaKillOnHitStatMod.EvaluateInstaKill(this, dmg.Owner))
		{
			dmg.amount = 0;
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
	}

	public override void End()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		base.End();
	}
}
