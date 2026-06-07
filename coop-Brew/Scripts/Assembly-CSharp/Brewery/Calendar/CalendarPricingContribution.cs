using System;

namespace Brewery.Calendar
{
	[Serializable]
	public struct CalendarPricingContribution
	{
		public float TagsMult;

		public float BaseTypeMult;

		public float FactionMult;

		public float CatalystMult;

		public float TotalMult;

		public string[] ContributingEventIds;

		public static CalendarPricingContribution Neutral => default(CalendarPricingContribution);

		public bool IsNeutral => false;
	}
}
