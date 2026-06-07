using System.Collections.Generic;

namespace Gh.Tk
{
	public class MarketingEvent : TimeSpanEffect
	{
		public string Category { get; set; }

		public float ReputationAdjustment { get; set; }

		public string Race { get; set; }

		public int? Tier { get; set; }

		protected MarketingEvent()
		{
		}

		public MarketingEvent(float startInDayF, float durationInDays, string category, float reputationAdjustment, string titleKey, string descriptionKey)
		{
		}

		protected override void RegisterAlertBadge()
		{
		}

		protected override void UnregisterAlertBadge()
		{
		}

		public float GetReputationAdjustment(string category, int? tier, string race)
		{
			return 0f;
		}

		public static IEnumerable<MarketingEvent> GetActiveEvents()
		{
			return null;
		}
	}
}
