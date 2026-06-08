public class GainBuffOnHitStatMod : StatModifier
{
	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (!(dmg.bullet != null) || !(dmg.Owner != null))
		{
			return;
		}
		if (base.abilityData != null)
		{
			if ((base.abilityData.applyTo == ItemData.Ability.ApplyTo.Character && dmg.Owner == base.character) || (base.abilityData.applyTo == ItemData.Ability.ApplyTo.Item && dmg.bullet.weapon == base.sourceItem))
			{
				ApplyDebuffOnHitStatMod.ApplyTo(this, base.character);
			}
		}
		else if (dmg.bullet.weapon == base.sourceItem)
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

	protected override void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.OnDestroy();
	}
}
