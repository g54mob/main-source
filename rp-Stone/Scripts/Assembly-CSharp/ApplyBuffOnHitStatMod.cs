public class ApplyBuffOnHitStatMod : StatModifier
{
	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.bullet != null && dmg.bullet.weapon == base.sourceItem && base.character != null && base.character.Alive)
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
