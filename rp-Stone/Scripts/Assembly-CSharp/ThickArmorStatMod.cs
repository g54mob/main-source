using UnityEngine;

public class ThickArmorStatMod : StatModifier
{
	public int damageReduction = 1;

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c == base.character && c.Armor > 0f)
		{
			int b = dmg.amount - damageReduction;
			b = Mathf.Max(0, b);
			dmg.amount = b;
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
