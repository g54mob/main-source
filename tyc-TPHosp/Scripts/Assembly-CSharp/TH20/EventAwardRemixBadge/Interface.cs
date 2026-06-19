namespace TH20.EventAwardRemixBadge
{
	public interface Interface : IGameEventCallback
	{
		void OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug);
	}
}
