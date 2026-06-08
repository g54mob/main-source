namespace Rhizomatic.ServiceSystem
{
	public abstract class AnalyticsService : Service
	{
		public abstract void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType);
	}
}
