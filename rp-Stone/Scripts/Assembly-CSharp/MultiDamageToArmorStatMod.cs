using UnityEngine;

public class MultiDamageToArmorStatMod : StatModifier
{
	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c.Armor > 0f && dmg.bullet != null && dmg.bullet.weapon == base.sourceItem && base.sourceItem != null)
		{
			float num = ComputeStatForSourceItemLevelAndRarity();
			if (!(num <= 0f))
			{
				float num2 = dmg.amount;
				float armor = c.Armor;
				float b = num2 * num;
				float a = armor + num2 - armor / num;
				a = Mathf.Min(a, b);
				dmg.amount = Mathf.CeilToInt(a);
			}
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
