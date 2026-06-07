public abstract class DayEndedAchievementBase : AchievementBase
{
	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnded);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnded);
	}

	protected abstract void OnDayEnded(GameEvent gameEvent);
}
