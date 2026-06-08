public class FissureStoneWeapon : Weapon
{
	private void Update()
	{
		baseDamage = GameStates.Singleton.hero.MaxHitpoints >> 1;
		if (currentSprite != null)
		{
			bool flag = GameStates.Singleton.CurrentState < GameStates.State.Playing || !IsOnCooldown();
			currentSprite.colorOverride = (flag ? ColorConstants.white : ColorConstants.grey);
		}
	}

	public override void SetState(State newState)
	{
		base.SetState(newState);
		if (newState == State.Performing)
		{
			AchievementController.singleton.ReportFissureStoneUsed();
		}
	}
}
