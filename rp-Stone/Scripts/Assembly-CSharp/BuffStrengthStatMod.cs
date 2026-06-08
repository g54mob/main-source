using UnityEngine;

public class BuffStrengthStatMod : DebuffStatMod
{
	public float damageMultiply = 2f;

	public int stunTics = 30;

	public StatModifier applyToEnemies;

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c.Armor > 0f && dmg.Owner == base.character)
		{
			float num = dmg.amount;
			float armor = c.Armor;
			float b = num * damageMultiply;
			float a = armor + num - armor / damageMultiply;
			a = Mathf.Min(a, b);
			dmg.amount = Mathf.CeilToInt(a);
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.Owner == base.character && dmg.amount > 0 && c.Alive && applyToEnemies != null)
		{
			StatModifier statModifier = Object.Instantiate(applyToEnemies);
			statModifier.statData = new ItemData.Stat();
			statModifier.statData.type = ItemData.Stat.Type.Stun;
			statModifier.character = base.character;
			statModifier.sourceItem = base.sourceItem;
			statModifier.cleansable = true;
			statModifier.ticDuration = stunTics;
			statModifier.Init();
			c.AddStatModifier(statModifier);
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.End();
	}
}
