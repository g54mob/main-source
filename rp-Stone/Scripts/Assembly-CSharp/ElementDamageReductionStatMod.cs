using UnityEngine;

public class ElementDamageReductionStatMod : StatModifier
{
	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c == base.character && dmg.GetElement() == ItemData.Counters(base.element))
		{
			float levelDisplayValueForItem = ItemFactory.GetLevelDisplayValueForItem(base.sourceItem);
			int num = Mathf.FloorToInt(base.statData.Compute(levelDisplayValueForItem));
			int amount = dmg.amount;
			int b = amount - num;
			b = (dmg.amount = Mathf.Max(0, b));
			if (amount > b)
			{
				Character.FireOnDamagePrevented(c, dmg, amount - b);
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
