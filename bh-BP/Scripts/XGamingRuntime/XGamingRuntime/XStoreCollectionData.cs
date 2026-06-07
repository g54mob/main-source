using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreCollectionData
	{
		public DateTime AcquiredDate { get; private set; }

		public DateTime StartDate { get; private set; }

		public DateTime EndDate { get; private set; }

		public bool IsTrial { get; private set; }

		public uint TrialTimeRemainingInSeconds { get; private set; }

		public uint Quantity { get; private set; }

		public string CampaignId { get; private set; }

		public string DeveloperOfferId { get; private set; }

		internal XStoreCollectionData(XGamingRuntime.Interop.XStoreCollectionData interopStruct)
		{
		}
	}
}
