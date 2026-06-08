public class ApplyDebuffWhenHitStatMod : StatModifier
{
	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == base.character && dmg.Owner != null && dmg.Owner.Alive)
		{
			ApplyDebuffOnHitStatMod.ApplyTo(this, dmg.Owner);
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.End();
	}
}
