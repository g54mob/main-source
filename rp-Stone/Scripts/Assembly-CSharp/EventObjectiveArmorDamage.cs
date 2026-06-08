using UnityEngine;

public class EventObjectiveArmorDamage : EventObjectiveBase
{
	public EventObjectiveArmorDamage(int goal)
		: base("armor_damage", goal)
	{
		description = Te.xt("tid_q_basic_armor_damage");
	}

	public override void Init()
	{
		Character.OnCharacterGoingToTakeDamage += HandleGoingToTakeDamage;
	}

	public override void End()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleGoingToTakeDamage;
	}

	private void HandleGoingToTakeDamage(Character c, Damage dmg)
	{
		if (c is Enemy && c.Armor >= 0f)
		{
			if (c.Armor >= (float)dmg.amount)
			{
				AddProgress(dmg.amount);
			}
			else
			{
				AddProgress(Mathf.FloorToInt(c.Armor));
			}
		}
	}
}
