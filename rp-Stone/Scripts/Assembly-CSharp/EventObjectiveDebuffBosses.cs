public class EventObjectiveDebuffBosses : EventObjectiveBase
{
	private string debuffId;

	public EventObjectiveDebuffBosses(int goal, string debuffId, string debuffName)
		: base(debuffId + "_debuff_bosses", goal)
	{
		this.debuffId = debuffId;
		description = string.Format(Te.xt("tid_q_basic_debuff_bosses"), TranslateIfTID(debuffName));
	}

	public override void Init()
	{
		StatModController.OnDebuffAdded += HandleDebuffAdded;
		StatModController.OnDebuffReset += HandleDebuffAdded;
	}

	public override void End()
	{
		StatModController.OnDebuffAdded -= HandleDebuffAdded;
		StatModController.OnDebuffReset -= HandleDebuffAdded;
	}

	private void HandleDebuffAdded(Character c, DebuffStatMod debuff)
	{
		if (debuff.id.Contains(debuffId) && c.HasTag("boss"))
		{
			AddProgress();
		}
	}
}
