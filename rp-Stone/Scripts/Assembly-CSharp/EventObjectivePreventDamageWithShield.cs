public class EventObjectivePreventDamageWithShield : EventObjectiveBase
{
	public EventObjectivePreventDamageWithShield(int goal)
		: base("use_shield", goal)
	{
		description = Te.xt("tid_q_basic_use_shield");
	}

	public override void Init()
	{
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == GameStates.Singleton.hero && c.Armor >= 0f && c.Armor >= (float)dmg.amount && dmg.startHitpoints == dmg.endHitpoints)
		{
			AddProgress();
		}
	}
}
