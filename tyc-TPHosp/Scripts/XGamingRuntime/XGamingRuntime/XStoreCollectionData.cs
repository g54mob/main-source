using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreCollectionData
	{
		public DateTime AcquiredDate { get; }

		public DateTime StartDate { get; }

		public DateTime EndDate { get; }

		public bool IsTrial { get; }

		public uint TrialTimeRemainingInSeconds { get; }

		public uint Quantity { get; }

		public string CampaignId { get; }

		public string DeveloperOfferId { get; }

		internal XStoreCollectionData(XGamingRuntime.Interop.XStoreCollectionData rawCollectionData)
		{
			AcquiredDate = rawCollectionData.acquiredDate.DateTime;
			StartDate = rawCollectionData.startDate.DateTime;
			EndDate = rawCollectionData.endDate.DateTime;
			IsTrial = rawCollectionData.isTrial;
			TrialTimeRemainingInSeconds = rawCollectionData.trialTimeRemainingInSeconds;
			Quantity = rawCollectionData.quantity;
			CampaignId = rawCollectionData.campaignId.GetString();
			DeveloperOfferId = rawCollectionData.developerOfferId.GetString();
		}
	}
}
