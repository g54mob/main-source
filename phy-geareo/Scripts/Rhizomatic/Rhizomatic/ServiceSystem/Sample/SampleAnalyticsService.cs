using UnityEngine;

namespace Rhizomatic.ServiceSystem.Sample
{
	[CreateAssetMenu(fileName = "sample_analytics", menuName = "ServiceSystem/Services/SampleAnalytics")]
	public class SampleAnalyticsService : AnalyticsService
	{
		public override void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType)
		{
		}
	}
}
