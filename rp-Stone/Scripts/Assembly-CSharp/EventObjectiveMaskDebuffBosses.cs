public class EventObjectiveMaskDebuffBosses : EventObjectiveBase
{
	public EventObjectiveMaskDebuffBosses(int goal)
		: base("mask_debuff_bosses", goal)
	{
		description = string.Format(Te.xt("tid_q_basic_mask_debuff"), Te.xt("tid_relic_53"));
	}

	private bool HasMaskEquipped()
	{
		Hero hero = GameStates.Singleton.hero;
		if (!(hero.LeftHand != null) || !hero.LeftHand.id.Contains("cult_mask"))
		{
			if (hero.RightHand != null)
			{
				return hero.RightHand.id.Contains("cult_mask");
			}
			return false;
		}
		return true;
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
		if (c.HasTag("boss") && HasMaskEquipped())
		{
			AddProgress();
		}
	}
}
