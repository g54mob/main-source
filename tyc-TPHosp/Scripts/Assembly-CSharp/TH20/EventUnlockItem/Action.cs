namespace TH20.EventUnlockItem
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(ISilverUnlockable item)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnItemUnlockedEvent(item);
			});
		}
	}
}
