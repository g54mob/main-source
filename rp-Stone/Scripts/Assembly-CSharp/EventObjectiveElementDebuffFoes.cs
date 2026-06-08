public class EventObjectiveElementDebuffFoes : EventObjectiveBase
{
	private ItemData.Element element;

	public EventObjectiveElementDebuffFoes(int goal, ItemData.Element element, string elementName)
		: base("element_debuff_foes", goal)
	{
		this.element = element;
		description = string.Format(Te.xt("tid_q_basic_element_debuff_foes"), TranslateIfTID(elementName));
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
		if (debuff.element == element && c is Enemy && !debuff.isPositiveBuff)
		{
			AddProgress();
		}
	}
}
