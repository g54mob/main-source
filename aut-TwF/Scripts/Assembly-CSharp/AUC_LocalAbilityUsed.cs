using UnityEngine;

public class AUC_LocalAbilityUsed : AbilityUnlockCondition
{
	[SerializeField]
	public Ability abilityToUse;

	private string abilityId = "";

	protected override void Awake()
	{
		base.Awake();
		if ((bool)abilityToUse)
		{
			abilityId = abilityToUse.Id;
		}
	}

	protected override void Start()
	{
		Ability abilityById = ability.AbilityManager.GetAbilityById(abilityId);
		if ((bool)abilityById)
		{
			abilityById.onAbilityEnds += OnAbilityEnds;
		}
		else
		{
			ability.AbilityManager.onAbilityAdded += OnAbilityAdded;
		}
		base.Start();
	}

	protected override void CheckCondition()
	{
		base.Accomplished = ability.AbilityManager.HasUsedLocalAbility(abilityId);
	}

	private void OnAbilityEnds(Ability ability, bool canceled)
	{
		if (!canceled)
		{
			CheckCondition();
		}
	}

	private void OnAbilityAdded(Ability ability)
	{
		ability.onAbilityEnds += OnAbilityEnds;
	}
}
