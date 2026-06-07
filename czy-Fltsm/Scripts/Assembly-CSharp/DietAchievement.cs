using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Diet Achievement")]
public class DietAchievement : AchievementBase
{
	[Header("Diet Achievement")]
	[SerializeField]
	[Tooltip("The items the drifter is allowed to consume. Keep in mind that both food and drinks are consumed!")]
	private ItemProperties[] _diet;

	[SerializeField]
	[Tooltip("The required amount of days the diet should be consumed to trigger the achievement.")]
	private int _requirement;

	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnded);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnded);
	}

	private void OnDayEnded(GameEvent gameEvent)
	{
		if (!(gameEvent is DayEvent dayEvent))
		{
			return;
		}
		int i = dayEvent.Days.Count - _requirement;
		if (i < 0)
		{
			return;
		}
		for (; i < dayEvent.Days.Count; i++)
		{
			foreach (KeyValuePair<ItemProperties, int> item in dayEvent.Days[i].Report.Consumed)
			{
				if (item.Value != 0 && !_diet.Contains(item.Key))
				{
					return;
				}
			}
		}
		if (UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
