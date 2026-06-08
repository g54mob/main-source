namespace LaundryBear.PlatformServices
{
	public interface ICanDelayShutdown
	{
		bool IsUserHandlingShutdownDelay { get; set; }

		void BeginDelayShutdown();

		void EndShutdownDelay();
	}
}
