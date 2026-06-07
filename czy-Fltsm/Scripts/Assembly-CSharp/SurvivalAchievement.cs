using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Survival Achievement")]
public class SurvivalAchievement : DayEndedAchievementBase
{
	[Header("Survival Achievement")]
	[SerializeField]
	[Tooltip("The amount of day the player must survive to trigger the achievement.")]
	private int _requirement;

	protected override void OnDayEnded(GameEvent gameEvent)
	{
		if (GameManager.TimeManager.Days.Count >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
