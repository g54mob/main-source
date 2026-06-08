public class MoonStoneWeapon : Weapon
{
	public override void SetState(State newState)
	{
		base.SetState(newState);
		if (newState == State.Performing)
		{
			AchievementController.singleton.ReportMoondialUsed();
		}
	}
}
