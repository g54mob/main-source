public class ApplyBuffWhenHitStatMod : StatModifier
{
	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == base.character && dmg.Owner != null && dmg.Owner.Alive)
		{
			ApplyDebuffOnHitStatMod.ApplyTo(this, base.character);
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
