using UnityEngine;

public class HealWhenHitStatMod : StatModifier
{
	public int baseHealAmount = 2;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (!(c == base.character) || !(dmg.Owner != null) || !dmg.Owner.Alive)
		{
			return;
		}
		float num = ItemFactory.GetLevelDisplayValueForItem(base.sourceItem);
		if (base.abilityData.applyRarity && base.sourceItem.rarity != null)
		{
			num = ((!base.abilityData.stat.rareStatOnly) ? (num + (float)base.sourceItem.rarity.levelBonus) : ((float)base.sourceItem.rarity.levelBonus));
		}
		else if (!base.abilityData.applyRarity && base.abilityData.stat.rareStatOnly)
		{
			num = 0f;
		}
		float num2 = base.abilityData.stat.Compute(num);
		if (!(num2 > 0f))
		{
			return;
		}
		float num3 = Random.Range(0f, 100f);
		if (num3 < num2)
		{
			int num4 = baseHealAmount;
			if (num2 > 100f && num3 < num2 - 100f)
			{
				num4 += Mathf.CeilToInt((float)baseHealAmount * num3 / 100f);
			}
			Damage damage = new Damage();
			damage.Owner = c;
			damage.amount = num4;
			c.ApplyHeal(damage);
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
