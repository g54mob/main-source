public class EventObjectiveHeal : EventObjectiveBase
{
	private bool countOverHeal;

	public EventObjectiveHeal(int goal, bool countOverHeal)
		: base("heal", goal)
	{
		this.countOverHeal = countOverHeal;
		description = Te.xt("tid_q_basic_heal");
	}

	public override void Init()
	{
		Character.OnCharacterWasHealed += HandleCharacterHealed;
	}

	public override void End()
	{
		Character.OnCharacterWasHealed -= HandleCharacterHealed;
	}

	private void HandleCharacterHealed(Character c, Damage heal)
	{
		if (countOverHeal)
		{
			if (c == GameStates.Singleton.hero)
			{
				AddProgress(heal.amount);
			}
		}
		else if (c == GameStates.Singleton.hero)
		{
			int num = c.MaxHitpoints - c.Hitpoints;
			if (num >= heal.amount)
			{
				AddProgress(heal.amount);
			}
			else
			{
				AddProgress(num);
			}
		}
	}
}
