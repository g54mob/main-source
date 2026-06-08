public class BladeOfGodActivatedAbility : WeaponActivatedAbility
{
	private Data.Quest lastQuest;

	private bool conditionalResult;

	public override bool IsAvailable()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (lastQuest != questData && questData != null)
		{
			lastQuest = questData;
			conditionalResult = !questData.id.StartsWith("undead_crypt_boss") && !questData.id.StartsWith("wildride") && !questData.id.StartsWith("titanic_accord");
		}
		return conditionalResult;
	}

	public override SuperAbilityActivationState ActivateAbility()
	{
		if (EventController.singleton.IsEventActiveAndStarted("titan_trial_2") && BladeOfGodGoals.singleton.goal.GetValue() == 3)
		{
			clock.cannotBeCleared = true;
		}
		else
		{
			clock.cannotBeCleared = false;
		}
		return base.ActivateAbility();
	}
}
