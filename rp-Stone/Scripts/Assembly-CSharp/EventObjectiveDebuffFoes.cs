public class EventObjectiveDebuffFoes : EventObjectiveBase
{
	private string debuffId;

	public EventObjectiveDebuffFoes(int goal, string debuffId, string debuffName)
		: base(debuffId + "_debuff_foes", goal)
	{
		this.debuffId = debuffId;
		description = string.Format(Te.xt("tid_q_basic_debuff_foes"), TranslateIfTID(debuffName));
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
		if (debuff.id.Contains(debuffId) && c is Enemy)
		{
			AddProgress();
		}
	}
}
