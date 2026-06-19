namespace TH20.EventAwardSilver
{
	public interface Interface : IGameEventCallback
	{
		void OnSilverAwardedEvent(int amount);
	}
}
