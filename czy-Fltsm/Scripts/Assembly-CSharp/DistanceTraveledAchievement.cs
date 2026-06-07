using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Distance Traveled Achievement")]
public class DistanceTraveledAchievement : AchievementBase
{
	[Header("Distance Traveled Achievement")]
	[SerializeField]
	[Tooltip("The required distance traveled")]
	private float _requirement = 42000f;

	[SerializeField]
	[Tooltip("The last day the achievement can be unlocked in. If the day limit is < 0, it is ignored.")]
	private int _dayLimit = -1;

	protected override void Initialize()
	{
		if (_dayLimit < 0 || _dayLimit >= GameManager.TimeManager.Days.Count)
		{
			GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
			if (_dayLimit >= 0)
			{
				GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnded);
			}
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnded);
	}

	private void OnTownheartMoved(GameEvent gameEvent)
	{
		if (GameManager.WorldManager.World.TownheartWorldPosition.x + WorldManager.ReturnFirstTileOffsetX() >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}

	private void OnDayEnded(GameEvent gameEvent)
	{
		if (_dayLimit < GameManager.TimeManager.Days.Count)
		{
			Uninitialize();
		}
	}
}
