namespace TH20.EventAwardRemixBadge
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(LevelConfig levelConfig, bool debug)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnRemixBadgeAwardedEvent(levelConfig, debug);
			});
		}
	}
}
