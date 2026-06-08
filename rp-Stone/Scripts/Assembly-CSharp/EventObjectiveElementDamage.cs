public class EventObjectiveElementDamage : EventObjectiveBase
{
	private ItemData.Element element;

	public EventObjectiveElementDamage(int goal, ItemData.Element element, string elementName)
		: base("element_dmg", goal)
	{
		this.element = element;
		description = string.Format(Te.xt("tid_q_basic_element_weapon_damage"), TranslateIfTID(elementName));
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
		if (dmg.bullet != null && dmg.bullet.GetElement() == element && c is Enemy && dmg.startHitpoints > 0)
		{
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			AddProgress(num);
		}
	}
}
