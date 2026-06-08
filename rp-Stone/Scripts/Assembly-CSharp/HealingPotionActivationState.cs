public class HealingPotionActivationState : BasePotionActivationState
{
	private static string HITPOINTS_ALREADY_FULL = "tid_potion_21";

	public override bool CanActivate()
	{
		if (!base.CanActivate())
		{
			return false;
		}
		Hero hero = GameStates.Singleton.hero;
		if (hero.MaxHitpoints - hero.Hitpoints <= 0)
		{
			base.errorMessage = Te.xt(HITPOINTS_ALREADY_FULL);
			return false;
		}
		return true;
	}

	public override void Activate()
	{
		base.Activate();
		TryEnableCauldronUpgrade();
		SfxController.singleton.Play("potion_healing");
	}

	protected override void SetState(State newState)
	{
		if (newState == PotionState.BottleMorphing)
		{
			ApplyPotionEffect();
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleMorphing && stateElapsedTics == 20)
		{
			SetState(State.Done);
		}
	}

	private void ApplyPotionEffect()
	{
		Hero hero = GameStates.Singleton.hero;
		int amount = hero.MaxHitpoints - hero.Hitpoints;
		Damage damage = new Damage();
		damage.amount = amount;
		damage.tags.Add("potion");
		hero.ApplyHeal(damage);
		SfxController.singleton.Play("life_gain");
	}

	private void TryEnableCauldronUpgrade()
	{
		if (!QuestController.singleton.HasCompleted("upgrade_cauldron"))
		{
			QuestController.singleton.MakeAvailable("upgrade_cauldron");
		}
	}
}
