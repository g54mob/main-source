using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Daily Landmarks Salvaged")]
public class DailyLandmarksSalvaged : DayEndedAchievementBase
{
	[Header("Daily Landmarks Salvaged")]
	[SerializeField]
	[Tooltip("The required amount of landmarks salvaged in a single day, to unlock the achievement")]
	private int _requirement;

	protected override void OnDayEnded(GameEvent gameEvent)
	{
		if (gameEvent is DayEvent dayEvent && dayEvent.Day.Report.LandmarksSalvaged >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
