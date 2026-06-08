public class BuffPotency : DebuffStatMod
{
	public int cooldownReduction = 30;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (!(c == base.character) || dmg.hitpointsLost <= 0)
		{
			return;
		}
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		Hero hero = c as Hero;
		if ((bool)hero)
		{
			ReduceCooldown(hero.LeftHand);
			ReduceCooldown(hero.RightHand);
		}
		else
		{
			Enemy enemy = c as Enemy;
			if ((bool)enemy)
			{
				ReduceCooldown(enemy.weapon);
			}
		}
		End();
	}

	private void ReduceCooldown(Weapon w)
	{
		if (w != null)
		{
			w.ReduceCooldown(cooldownReduction);
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}
}
