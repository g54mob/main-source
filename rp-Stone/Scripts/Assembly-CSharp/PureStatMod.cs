public class PureStatMod : DebuffStatMod
{
	private void HandleDebuffAdded(Character c, DebuffStatMod newdebuff)
	{
		if (c == base.character && newdebuff.cleansable && newdebuff != this && newdebuff.ticDuration != 0)
		{
			newdebuff.ticDuration = 0;
			CrusaderShieldGoals.singleton.ReportPurePreventedDebuff(newdebuff);
		}
	}

	public override void Init()
	{
		base.Init();
		StatModController.OnDebuffAdded += HandleDebuffAdded;
	}

	public override void End()
	{
		StatModController.OnDebuffAdded -= HandleDebuffAdded;
		base.End();
	}
}
