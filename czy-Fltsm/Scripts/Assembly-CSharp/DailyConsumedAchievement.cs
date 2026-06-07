using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Daily Consumed Achievement")]
public class DailyConsumedAchievement : DayEndedAchievementBase
{
	[Header("Daily Consumed Achievement")]
	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	[Tooltip("The minimum requirement amount to consume to trigger the achievement.")]
	private int _requirement;

	protected override void OnDayEnded(GameEvent gameEvent)
	{
		if (gameEvent is DayEvent dayEvent)
		{
			DailyReport report = dayEvent.Day.Report;
			int num = 0;
			if (report.Consumed.TryGetValue(_itemProperties, out var value))
			{
				num += value;
			}
			if (report.Processed.TryGetValue(_itemProperties, out var value2))
			{
				num += value2;
			}
			num += Mathf.CeilToInt(ItemDistributer.ReturnConsumedToday(_itemProperties));
			if (num >= _requirement && UnlockAchievement())
			{
				Uninitialize();
			}
		}
	}
}
