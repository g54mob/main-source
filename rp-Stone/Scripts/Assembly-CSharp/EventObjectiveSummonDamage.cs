public class EventObjectiveSummonDamage : EventObjectiveBase
{
	private string summonID;

	public EventObjectiveSummonDamage(int goal, string summonID, string summonName)
		: base("summon_dmg", goal)
	{
		this.summonID = summonID;
		description = string.Format(Te.xt("tid_q_basic_summon_damage"), TranslateIfTID(summonName));
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
		if (dmg.Owner != null && dmg.Owner.id == summonID && dmg.tags.Contains("summon_basic") && c is Enemy && dmg.startHitpoints > 0)
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
