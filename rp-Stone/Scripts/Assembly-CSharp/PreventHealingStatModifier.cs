public class PreventHealingStatModifier : DebuffStatMod
{
	private void HandleCharacterGoingToHeal(Character c, Damage dmg)
	{
		if (c == base.character && !done)
		{
			dmg.amount = 0;
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterGoingToBeHealed += HandleCharacterGoingToHeal;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterGoingToBeHealed -= HandleCharacterGoingToHeal;
		base.OnDestroy();
	}
}
