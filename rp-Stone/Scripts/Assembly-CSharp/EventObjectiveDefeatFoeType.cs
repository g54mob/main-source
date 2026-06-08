public class EventObjectiveDefeatFoeType : EventObjectiveBase
{
	private string foeType;

	private int bossPoints;

	public EventObjectiveDefeatFoeType(int goal, string foeType, string typeName, int bossPoints = 1)
		: base("kill_foe_type", goal)
	{
		this.foeType = foeType;
		this.bossPoints = bossPoints;
		description = string.Format(Te.xt("tid_q_basic_kill_foesB"), TranslateIfTID(typeName));
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
		if (c.HasTag(foeType) && (reason == Character.DeathReason.Unmake || reason == Character.DeathReason.DamageTaken))
		{
			if (c.HasTag("boss"))
			{
				AddProgress(bossPoints);
			}
			else
			{
				AddProgress();
			}
		}
	}
}
