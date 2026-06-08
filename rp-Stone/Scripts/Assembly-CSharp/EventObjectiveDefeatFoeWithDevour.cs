public class EventObjectiveDefeatFoeWithDevour : EventObjectiveBase
{
	private string summonID;

	public EventObjectiveDefeatFoeWithDevour(int goal, string summonID = null, string summonName = null)
		: base("unmake_foes", goal)
	{
		this.summonID = summonID;
		if (summonName == null)
		{
			description = Te.xt("tid_q_basic_devour_foeA");
		}
		else
		{
			description = string.Format(Te.xt("tid_q_basic_devour_foeB"), TranslateIfTID(summonName));
		}
	}

	public override void Init()
	{
		Character.OnCharacterDied += HandleCharacterDied;
	}

	public override void End()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if ((reason == Character.DeathReason.Unmake || reason == Character.DeathReason.DamageTaken) && dmg.tags.Contains("Devour"))
		{
			if (summonID == null)
			{
				AddProgress();
			}
			else if (dmg.Owner != null && dmg.Owner.id == summonID)
			{
				AddProgress();
			}
		}
	}
}
