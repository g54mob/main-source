namespace Gh.Tk
{
	public class StockUnavailableTimelineEvent : SimpleTimelineEvent
	{
		private string _templateId;

		protected StockUnavailableTimelineEvent()
		{
		}

		public StockUnavailableTimelineEvent(GameItemTemplate template, float duesInDaysF, float durationInDaysF)
		{
		}

		public static bool IsUnavailable(GameItemTemplate template)
		{
			return false;
		}
	}
}
