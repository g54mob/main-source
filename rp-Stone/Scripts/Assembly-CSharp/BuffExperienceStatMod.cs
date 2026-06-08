public class BuffExperienceStatMod : DebuffStatMod
{
	public int bonusKiAndXP = 1;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.Owner == base.character && dmg.amount > 0 && c.Hitpoints <= 0)
		{
			c.Money += bonusKiAndXP;
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
