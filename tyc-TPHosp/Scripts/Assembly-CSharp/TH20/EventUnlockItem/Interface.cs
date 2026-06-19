namespace TH20.EventUnlockItem
{
	public interface Interface : IGameEventCallback
	{
		void OnItemUnlockedEvent(ISilverUnlockable item);
	}
}
