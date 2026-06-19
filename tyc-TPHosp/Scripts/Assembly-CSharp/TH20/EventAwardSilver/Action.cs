namespace TH20.EventAwardSilver
{
	public class Action : GameEvent_Base<Interface>
	{
		public void InvokeSafe(int amount)
		{
			IterateCallbacks(delegate(Interface callback)
			{
				callback.OnSilverAwardedEvent(amount);
			});
		}
	}
}
