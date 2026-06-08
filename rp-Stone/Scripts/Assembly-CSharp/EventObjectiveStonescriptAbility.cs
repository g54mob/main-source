public class EventObjectiveStonescriptAbility : EventObjectiveBase
{
	private string weaponId;

	public EventObjectiveStonescriptAbility(int goal, string weaponId, string weaponName)
		: base("script_ability", goal)
	{
		this.weaponId = weaponId;
		description = string.Format(Te.xt("tid_q_basic_mind_activate"), TranslateIfTID(weaponName));
	}

	public override void Init()
	{
		GameStates.Singleton.abilityActivationHUD.OnActivated += HandleAbilityActivated;
	}

	public override void End()
	{
		GameStates.Singleton.abilityActivationHUD.OnActivated -= HandleAbilityActivated;
	}

	private void HandleAbilityActivated(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (withStonescript && provider.GetId() == weaponId)
		{
			AddProgress();
		}
	}
}
