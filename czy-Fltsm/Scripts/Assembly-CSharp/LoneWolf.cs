using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Lone Wolf")]
public class LoneWolf : DayEndedAchievementBase
{
	[Header("Lone Wolf")]
	[SerializeField]
	private int _days;

	protected override void OnDayEnded(GameEvent gameEvent)
	{
		if (!(gameEvent is DayEvent dayEvent))
		{
			return;
		}
		int i = dayEvent.Days.Count - _days;
		if (i < 0)
		{
			return;
		}
		for (; i < dayEvent.Days.Count; i++)
		{
			DailyReport report = dayEvent.Days[i].Report;
			if (report.StartAgentCount != 1 || report.HasActorRescue(ActorType.Agent))
			{
				return;
			}
		}
		if (UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
