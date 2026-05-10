public abstract class TowerAutoAttack : AutoAttack
{
	private TowerAnimationComponent towerAnimationComponent;

	protected override void Awake()
	{
		base.Awake();
		towerAnimationComponent = abilityManager.GetComponent<TowerAnimationComponent>();
	}

	public override bool CanActivate(FActiveAbilityInputData inputData)
	{
		if (!towerAnimationComponent || !towerAnimationComponent.IsPlayingAutoAttackAnimation())
		{
			return base.CanActivate(inputData);
		}
		return false;
	}
}
